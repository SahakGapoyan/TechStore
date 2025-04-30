using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.Ram;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor.Apis
{
    public class RamApi : IRamApi
    {
        private readonly HttpClient _httpClient;

        public RamApi(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUri);
        }

        public async Task AddRam(RamAddDto ramAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Rams", ramAddDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }

        public async Task DeleteRam(int ramId)
        {
            var response = await _httpClient.DeleteAsync($"api/Rams/id/{ramId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }

        public async Task<RamDto> GetRam(int id)
        {
            var response = await _httpClient.GetAsync($"api/Rams/id/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<RamDto>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<RamDto>> GetRams()
        {
            var response = await _httpClient.GetAsync("api/Rams");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<RamDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<RamDto>> GetRamsByCategoryId(int categoryId)
        {
            var response = await _httpClient.GetAsync($"api/Rams/categoryId/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<RamDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task UpdateRam(int ramId, RamUpdateDto ramUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Rams/id/{ramId}", ramUpdateDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }
    }
}
