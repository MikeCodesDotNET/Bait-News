using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BaitNews.Forms.Models;
using Newtonsoft.Json;

namespace BaitNews.Forms.Services
{
    public class HeadlineService
    {
        public async Task<List<Headline>> GetAll()
        {
            if (_client == null)
                _client = new HttpClient();

            List<Headline> model;

            var url = string.Format("https://baitnews.io/api/headline");
            var response = await _client.GetAsync(url);

            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            model = JsonConvert.DeserializeObject<List<Headline>>(jsonString.Result);

            return model;
        }

        HttpClient _client;
    }
}
