using Microsoft.Extensions.Options;
using System.Formats.Asn1;
using System.Net.Http.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.Laptop;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor.Apis
{
    public class LaptopApi : ILaptopApi
    {
        private readonly HttpClient _httpClient;

        public LaptopApi(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUri);
        }
        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Laptops/id/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }

        public async Task<LaptopDto> GetLaptop(int id)
        {
            var response = await _httpClient.GetAsync($"api/SmartPhones/id/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<LaptopDto>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task<IEnumerable<LaptopDto>> GetLaptops()
        {
            var response = await _httpClient.GetAsync($"api/Laptops");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<LaptopDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async  Task<IEnumerable<LaptopDto>> GetLaptopsByMemoryId(int memoryId)
        {
            var response = await _httpClient.GetAsync($"api/Laptops/memoryId/{memoryId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<LaptopDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task<IEnumerable<LaptopDto>> GetLaptopsByOSId(int osId)
        {
            var response = await _httpClient.GetAsync($"api/Laptops/osId/{osId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<LaptopDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task<IEnumerable<LaptopDto>> GetLaptopsByRamId(int ramId)
        {
            var response = await _httpClient.GetAsync($"api/Laptops/ramId/{ramId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<LaptopDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task AddLaptop(LaptopAddDto laptopAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Laptops", laptopAddDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }

        public async Task Update(int id, LaptopUpdateDto laptopUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Laptops/id/{id}", laptopUpdateDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }
    }
}
