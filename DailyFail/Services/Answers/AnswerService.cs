using System;
using System.Collections.Generic;
using System.Net;
using System.Reactive.Linq;
using System.Threading.Tasks;

using Akavache;
using Fusillade;
using Plugin.Connectivity;
using Polly;

using BaitNews.Models;
using BaitNews.Services.Answers.Abstractions;
using BaitNews.Services;

namespace BaitNews.Services.Answers
{
    public class AnswerService : IAnswerService
    {
        readonly IApiService<IAnswerRefit> _apiService;

        public AnswerService()
        {
            _apiService = new ApiService<IAnswerRefit>();
        }

        public async Task<List<Answer>> GetAnswers(Priority priority)
        {
            var cache = BlobCache.LocalMachine;
            var cachedAnswers = cache.GetAndFetchLatest("answers", () => GetRemoteAnswersAsync(priority),
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

            var answers = await cachedAnswers.FirstOrDefaultAsync();
            return answers;
        }

        public async Task<Answer> GetAnswer(Priority priority, string id)
        {
            var cachedAnswers = BlobCache.LocalMachine.GetAndFetchLatest(id, () => GetRemoteAnswer(priority, id), offset =>
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

            var answer = await cachedAnswers.FirstOrDefaultAsync();
            return answer;
        }

        async Task<List<Answer>> GetRemoteAnswersAsync(Priority priority)
        {
            List<Answer> answers = null;
            Task<List<Answer>> getAnswersTask;
            switch (priority)
            {
                case Priority.Background:
                    getAnswersTask = _apiService.Background.GetAnswers();
                    break;
                case Priority.UserInitiated:
                    getAnswersTask = _apiService.UserInitiated.GetAnswers();
                    break;
                case Priority.Speculative:
                    getAnswersTask = _apiService.Speculative.GetAnswers();
                    break;
                default:
                    getAnswersTask = _apiService.UserInitiated.GetAnswers();
                    break;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                answers = await getAnswersTask;
            }
            return answers;
        }

        public async Task<Answer> GetRemoteAnswer(Priority priority, string id)
        {
            Answer answer = null;

            Task<Answer> getAnswerTask;
            switch (priority)
            {
                case Priority.Background:
                    getAnswerTask = _apiService.Background.GetAnswer(id);
                    break;
                case Priority.UserInitiated:
                    getAnswerTask = _apiService.UserInitiated.GetAnswer(id);
                    break;
                case Priority.Speculative:
                    getAnswerTask = _apiService.Speculative.GetAnswer(id);
                    break;
                default:
                    getAnswerTask = _apiService.UserInitiated.GetAnswer(id);
                    break;
            }

            if (CrossConnectivity.Current.IsConnected)
            {
                answer = await Policy
                    .Handle<Exception>()
                    .RetryAsync(retryCount: 5)
                    .ExecuteAsync(async () => await getAnswerTask);
            }
            return answer;
        }
    }
}