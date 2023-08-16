using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using car.models;

namespace car.Services
{
    public class JsonServer
    {
        private readonly HttpClient _httpClient;

        public JsonServer(string baseUrl, string apiKey)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        public async Task<bool> SendCarToServerAsync(Car car)
        {
            var json = JsonSerializer.Serialize(car);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("cars", content);

            return response.IsSuccessStatusCode;
        }
    }

}

