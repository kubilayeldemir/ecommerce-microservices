using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Clients.Interfaces;

namespace Clients.Utilities
{
    public class Client : IDisposable, IClient
    {
        private readonly HttpClient _httpClient;


        public Client(HttpClient client)
        {
            //client.BaseAddress = new Uri(Environment.GetEnvironmentVariable("")); //not working
            //client.BaseAddress = new Uri("http://localhost:8080/api/");
            client.BaseAddress = new Uri("http://urinull/api/");
            client.Timeout = TimeSpan.FromSeconds(30);
            _httpClient = client;
        }

        public void SetBaseAddress(string baseAddress)
        {
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        public async Task<T> GetAsync<T>(string endpoint)
        {
            var res = await _httpClient.GetAsync(endpoint);
            if (!res.IsSuccessStatusCode)
            {
                throw new KeyNotFoundException("Not Found");
            }

            return await res.Content.ReadAsAsync<T>();
        }

        public async Task<T> PostAsync<T>(string endpoint, object body)
        {
            var httpContent =
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var res = await _httpClient.PostAsync(endpoint, httpContent);
            if (!res.IsSuccessStatusCode)
            {
                return default;
            }
            return await res.Content.ReadAsAsync<T>();
        }

        public async Task<T> DeleteAsync<T>(string endpoint)
        {
            var res = await _httpClient.DeleteAsync(endpoint);
            if (!res.IsSuccessStatusCode)
            {
                throw new KeyNotFoundException("Not Found");
            }

            return await res.Content.ReadAsAsync<T>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}