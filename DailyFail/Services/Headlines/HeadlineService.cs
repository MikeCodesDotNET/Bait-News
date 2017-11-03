﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Reactive.Linq;
using System.Threading.Tasks;

using Akavache;
using Fusillade;
using Plugin.Connectivity;
using Polly;

using BaitNews.Models;
using BaitNews.Services.Headlines.Abstractions;

namespace BaitNews.Services.Headlines
{
    public class HeadlineService : IHeadlineService
    {
        IApiService<IHeadlineRefit> _apiService;

        public HeadlineService()
        {
            _apiService = new ApiService<IHeadlineRefit>();
        }

        public async Task<List<Headline>> GetHeadlines(Priority priority)
        {       
            var cache = BlobCache.LocalMachine;
            var cachedHeadlines = cache.GetAndFetchLatest("headlines", () => GetRemoteHeadlinesAsync(priority),
                offset =>
                {
                    //If there is no network connection available, always return false so that the user will get cached data if available
                    if (CrossConnectivity.Current.IsConnected)
                    {
                        TimeSpan elapsed = DateTimeOffset.Now - offset;
                        return elapsed > Helpers.Constants.CacheInvalidationAge;
                    }
                    else
                        return false;
                });

            var headlines = await cachedHeadlines.FirstOrDefaultAsync();
            return headlines;
        }

        public async Task<Headline> GetHeadline(Priority priority, string id)
        {
            var cachedHeadlines = BlobCache.LocalMachine.GetAndFetchLatest(id, () => GetRemoteHeadline(priority, id), offset =>
            {
                //If there is no network connection available, always return false so that the user will get cached data if available
                if (CrossConnectivity.Current.IsConnected)
                {
                    TimeSpan elapsed = DateTimeOffset.Now - offset;
                    return elapsed > Helpers.Constants.CacheInvalidationAge;
                }
                else
                    return false;
            });

            var headline = await cachedHeadlines.FirstOrDefaultAsync();
            return headline;
        }

        async Task<List<Headline>> GetRemoteHeadlinesAsync(Priority priority)
        {
            List<Headline> headlines = null;
            Task<List<Headline>> getHeadlinesTask;
            switch (priority)
            {
                case Priority.Background:
                    getHeadlinesTask = _apiService.Background.GetHeadlines();
                    break;
                case Priority.UserInitiated:
                    getHeadlinesTask = _apiService.UserInitiated.GetHeadlines();
                    break;
                case Priority.Speculative:
                    getHeadlinesTask = _apiService.Speculative.GetHeadlines();
                    break;
                default:
                    getHeadlinesTask = _apiService.UserInitiated.GetHeadlines();
                    break;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                headlines = await getHeadlinesTask;
            }
            return headlines;
        }

        public async Task<Headline> GetRemoteHeadline(Priority priority, string id)
        {
            Headline headline = null;

            Task<Headline> getConferenceTask;
            switch (priority)
            {
                case Priority.Background:
                    getConferenceTask = _apiService.Background.GetHeadline(id);
                    break;
                case Priority.UserInitiated:
                    getConferenceTask = _apiService.UserInitiated.GetHeadline(id);
                    break;
                case Priority.Speculative:
                    getConferenceTask = _apiService.Speculative.GetHeadline(id);
                    break;
                default:
                    getConferenceTask = _apiService.UserInitiated.GetHeadline(id);
                    break;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                headline = await Policy
                    .Handle<Exception>()
                    .RetryAsync(retryCount: 5)
                    .ExecuteAsync(async () => await getConferenceTask);
            }
            return headline;
        }
    }
}