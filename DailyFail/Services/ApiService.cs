using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using Fusillade;
using ModernHttpClient;
using Refit;

namespace BaitNews.Services.Headlines
{
    public class ApiService<T> : IApiService<T>
    {
        public const string ApiBaseAddress = Helpers.Keys.ApiEndpoint;

        public ApiService(string apiBaseAddress = null)
        {
			Func<HttpMessageHandler, T> createClient = messageHandler =>
            {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(apiBaseAddress ?? ApiBaseAddress)

                };
				client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Helpers.Keys.ApiKey);
				return RestService.For<T>(client);
            };

            background = new Lazy<T>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Background)));
            userInitiated = new Lazy<T>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.UserInitiated)));
            speculative = new Lazy<T>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Speculative)));
        }

	    Lazy<T> background;
	    Lazy<T> userInitiated;
        Lazy<T> speculative;

		public T Background
		{
			get { return background.Value; }
		}

		public T UserInitiated
		{
			get { return userInitiated.Value; }
		}

		public T Speculative
		{
			get { return speculative.Value; }
		}
		
    }
}
