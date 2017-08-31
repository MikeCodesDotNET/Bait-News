using System;
using System.Net.Http;
using Fusillade;
using ModernHttpClient;
using Refit;

namespace BaitNews.Services.Headlines
{
    public class HeadlineApiService : IApiService
    {
        public const string ApiBaseAddress = Helpers.Keys.ApiEndpoint;

        public HeadlineApiService(string apiBaseAddress = null)
        {
            Func<HttpMessageHandler, IRefit> createClient = messageHandler =>
            {
                var client = new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri(apiBaseAddress ?? ApiBaseAddress)
                };

                return RestService.For<IRefit>(client);
            };

            background = new Lazy<IRefit>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Background)));

            userInitiated = new Lazy<IRefit>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.UserInitiated)));

            speculative = new Lazy<IRefit>(() => createClient(new RateLimitedHttpMessageHandler(new NativeMessageHandler(), Priority.Speculative)));
        }

	    Lazy<IRefit> background;
	    Lazy<IRefit> userInitiated;
        Lazy<IRefit> speculative;

		public IRefit Background
		{
			get { return background.Value; }
		}

		public IRefit UserInitiated
		{
			get { return userInitiated.Value; }
		}

		public IRefit Speculative
		{
			get { return speculative.Value; }
		}
		
    }
}
