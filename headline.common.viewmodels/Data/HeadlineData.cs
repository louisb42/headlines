using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

using Headline.Common.Models;

namespace Headline.Common.ViewModels.Data
{
    public class HeadlineData : IHeadlineData
    {
        private const string ApiKeyName = "XApiKey";
        private const string ApiKeyValue = "This-should-be-in-a-vault-because-it-is-Super-secret-like-the-location-of-the-batcave-in-Bronson-Caves-in-Griffith-Park-below-the-Hollywood-Sign";
        private const string ApiBaseUrl = "https://localhost:7011";

        public HeadlineData()
        {
        }

        public async Task<List<HeadlineModel>> GetDataAsync()
        {
            var url = "/headlines/";
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);
                client.DefaultRequestHeaders.Add(ApiKeyName, ApiKeyValue);

                HttpResponseMessage response = await client.GetAsync(url);
                _ = response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                List<HeadlineModel>? headlineList = JsonSerializer.Deserialize<List<HeadlineModel>>(result);
                return headlineList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public async Task PostDataAsync(HeadlineModel headline)
        {
            var url = "/headlines/";
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);
                client.DefaultRequestHeaders.Add(ApiKeyName, ApiKeyValue);

                HttpContent c = new StringContent(JsonSerializer.Serialize(headline), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, c);
                _ = response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                List<HeadlineModel>? headlineList = JsonSerializer.Deserialize<List<HeadlineModel>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public async Task PutDataAsync(HeadlineModel headline)
        {
            var url = $"/headlines/{headline.Id}";
            try
            {
                using var client = new HttpClient();
                client.BaseAddress = new Uri(ApiBaseUrl);
                client.DefaultRequestHeaders.Add(ApiKeyName, ApiKeyValue);

                HttpContent c = new StringContent(JsonSerializer.Serialize(headline), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PutAsync(url, c);
                _ = response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                List<HeadlineModel>? headlineList = JsonSerializer.Deserialize<List<HeadlineModel>>(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }
}
