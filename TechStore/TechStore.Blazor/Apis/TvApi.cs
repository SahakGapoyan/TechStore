using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.Tv;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor.Apis
{
    public class TvApi : ITvApi
    {
        private readonly HttpClient _httpClient;

        public TvApi(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUri);
        }
        public async Task<TvDto> GetTv(int id)
        {
            var response = await _httpClient.GetAsync($"api/Tvs/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TvDto>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<TvDto>> GetTvs()
        {
            var response = await _httpClient.GetAsync("api/Tvs");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<TvDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<TvDto>> GetTvsByBrandId(int brandId)
        {
            var response = await _httpClient.GetAsync($"api/Tvs/{brandId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<TvDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<TvDto>> GetTvsByColorId(int colorId)
        {
            var response = await _httpClient.GetAsync($"api/Tvs/{colorId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<TvDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<TvDto>> GetTvsByModelId(int modelId)
        {
            var response = await _httpClient.GetAsync($"api/Tvs/{modelId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<TvDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }
    }
}
