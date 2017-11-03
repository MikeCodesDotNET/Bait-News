﻿using System;
using System.Collections.Generic;    
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Microsoft.Extensions.Configuration;

namespace BaitNews.Data.Services
{   
    public class DocumentDBRepositoryBase<T> where T : class
    {
        string Endpoint = "https://baitnews.documents.azure.com:443/";
        string Key = "My9nez8S2mT49U0mVKNuupx1Qxv23lnEilqfkDckPr3RFhgwED5KfwJbEdav8HXnloDUcUdHmERJJplFyP3KRw==";
        string DatabaseId = "BaitNews";

        string CollectionId;
        DocumentClient client;

		public void Initialize()
		{
			client = new DocumentClient(new Uri(Endpoint), Key, new ConnectionPolicy { EnableEndpointDiscovery = false });
			CreateDatabaseIfNotExistsAsync().Wait();
			CreateCollectionIfNotExistsAsync().Wait();
		}

		string GetCollectionName()
		{
            //This is a horrible hack because I named my collections as purals.
			var name = typeof(T).Name;
            if(name.ToCharArray().Last().ToString() != "s")
                return $"{name}s";
            return name;
		}


		public async Task<T> GetItemAsync(string id)
        {
            try
            {
                Document document = await client.ReadDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
                return (T)(dynamic)document;
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return null;
                }
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetItemsAsync(Expression<Func<T, bool>> predicate)
        {
            CollectionId = GetCollectionName();

			IDocumentQuery<T> query = client.CreateDocumentQuery<T>(
                UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId),
                new FeedOptions { MaxItemCount = -1 })
                .Where(predicate)
                .AsDocumentQuery();

            List<T> results = new List<T>();
            while (query.HasMoreResults)
            {
                results.AddRange(await query.ExecuteNextAsync<T>());
            }

            return results;
        }

        public async Task<Document> CreateItemAsync(T item)
        {
			CollectionId = GetCollectionName();
			return await client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId), item);
        }

        public async Task<Document> UpdateItemAsync(string id, T item)
        {
			CollectionId = GetCollectionName();
			return await client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id), item);
        }

        public async Task DeleteItemAsync(string id)
        {
			CollectionId = GetCollectionName();
			await client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(DatabaseId, CollectionId, id));
        }

        async Task CreateDatabaseIfNotExistsAsync()
        {
            try
            {
                await client.ReadDatabaseAsync(UriFactory.CreateDatabaseUri(DatabaseId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDatabaseAsync(new Database { Id = DatabaseId });
                }
                else
                {
                    throw;
                }
            }
        }

        async Task CreateCollectionIfNotExistsAsync()
        {
			CollectionId = GetCollectionName();

			try
            {
                await client.ReadDocumentCollectionAsync(UriFactory.CreateDocumentCollectionUri(DatabaseId, CollectionId));
            }
            catch (DocumentClientException e)
            {
                if (e.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    await client.CreateDocumentCollectionAsync(
                        UriFactory.CreateDatabaseUri(DatabaseId),
                        new DocumentCollection { Id = CollectionId },
                        new RequestOptions { OfferThroughput = 400 });
                }
                else
                {
                    throw;
                }
            }
        }
    }
}