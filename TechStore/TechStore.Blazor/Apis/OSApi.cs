using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.Brand;
using TechStore.Blazor.DtoModels.OS;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor.Apis
{
    public class OSApi : IOSApi
    {
        private readonly HttpClient _httpClient;

        public OSApi(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUri);
        }
        public async Task<OSDto> GetOS(int id)
        {
            var response = await _httpClient.GetAsync($"api/OSes/id/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<OSDto>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<OSDto>> GetOSes()
        {
            var response = await _httpClient.GetAsync("api/OSes");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<OSDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<OSDto>> GetOsesByCategoryId(int? categoryId)
        {
            var response = await _httpClient.GetAsync($"api/OSes/categoryId/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<OSDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }
    }
}
