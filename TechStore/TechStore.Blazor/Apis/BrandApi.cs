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
            throw new NotImplementedException();
        }

        public Task DeleteBrand(int brandId)
        {
            throw new NotImplementedException();
        }

        public Task<BrandDto?> GetBrand(int brandId)
        {
            throw new NotImplementedException();
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

        public Task UpdateBrand(int brandId, BrandUpdateDto brandUpdateDto)
        {
            throw new NotImplementedException();
        }
    }
}
