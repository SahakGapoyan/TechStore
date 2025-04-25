using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.Color;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor.Apis
{
    public class ColorApi:IColorApi
    {
        private readonly HttpClient _httpClient;

        public ColorApi(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUri);
        }

        public async Task<ColorDto> GetColor(int id)
        {
            var response = await _httpClient.GetAsync($"api/Colors/id/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ColorDto>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<ColorDto>> GetColors()
        {
            var response = await _httpClient.GetAsync("api/Colors");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ColorDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }
    }
}
