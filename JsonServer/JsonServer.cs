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

    public JsonServer(string baseUrl)
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(baseUrl);
        // _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
    }

    public async Task<bool> CreateCarAsync(Car car)
    {
        var json = JsonSerializer.Serialize(car);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("cars", content);

        return response.IsSuccessStatusCode;
    }

    public async Task<Car> GetCarAsync(string id)
    {
        var response = await _httpClient.GetAsync($"cars/{id}");

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Car>(json);
        }

        return null;
    }

    public async Task<bool> UpdateCarAsync(string id, Car car)
    {
        var json = JsonSerializer.Serialize(car);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"cars/{id}", content);

        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteCarAsync(string id)
    {
        var response = await _httpClient.DeleteAsync($"cars/{id}");

        return response.IsSuccessStatusCode;
    }
}

}

