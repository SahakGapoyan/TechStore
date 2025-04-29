using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.Brand;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor.Apis
{
    public class BrandApi : IBrandApi
    {
        private readonly HttpClient _httpClient;

        public BrandApi(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUri);
        }
        public async Task AddBrand(BrandAddDto brandAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Brands", brandAddDto);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error" + response.ReasonPhrase);
            }
        }

        public async Task DeleteBrand(int brandId)
        {
            var response = await _httpClient.DeleteAsync($"api/Brands/id/{brandId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error" + response.ReasonPhrase);
            }
        }

        public async Task<BrandDto?> GetBrand(int brandId)
        {
            var response = await _httpClient.GetAsync($"api/Brands/id/{brandId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<BrandDto>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<BrandDto>> GetBrands()
        {
            var response = await _httpClient.GetAsync("api/Brands");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<BrandDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<BrandDto>> GetBrandsByCategoryId(int categoryId)
        {
            var response = await _httpClient.GetAsync($"api/Brands/categoryId/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<BrandDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task UpdateBrand(int brandId, BrandUpdateDto brandUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Brands/id/{brandId}", brandUpdateDto);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error" + response.ReasonPhrase);
            }
        }
    }
}
