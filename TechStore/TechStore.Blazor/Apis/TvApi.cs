using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.Result;
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

        public async Task<ApiResult<bool>> AddTv(TvAddDto tvAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Tvs", tvAddDto);
            if (response.IsSuccessStatusCode)
            {
                return new ApiResult<bool> { Success = true, Data = true };
            }

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var errorContent = await response.Content.ReadFromJsonAsync<Dictionary<string, object>>();
                if (errorContent != null && errorContent.ContainsKey("errors"))
                {
                    var validationErrors = JsonSerializer.Deserialize<List<ValidationError>>(
                        errorContent["errors"].ToString(),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                    return new ApiResult<bool>
                    {
                        Success = false,
                        ValidationErrors = validationErrors
                    };
                }
            }

            return new ApiResult<bool>
            {
                Success = false,
                ErrorMessage = await response.Content.ReadAsStringAsync()
            };
        }

        public async Task DeleteTv(int tvId)
        {
            var response = await _httpClient.DeleteAsync($"api/TVs/id/{tvId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }

        public async Task<TvDto> GetTv(int id)
        {
            var response = await _httpClient.GetAsync($"api/TVs/id/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TvDto>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<TvDto>> GetTvs()
        {
            var response = await _httpClient.GetAsync("api/TVs");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<TvDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<TvDto>> GetTvsByBrandId(int brandId)
        {
            var response = await _httpClient.GetAsync($"api/TVs/brandId/{brandId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<TvDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<TvDto>> GetTvsByColorId(int colorId)
        {
            var response = await _httpClient.GetAsync($"api/TVs/colorId/{colorId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<TvDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<TvDto>> GetTvsByModelId(int modelId)
        {
            var response = await _httpClient.GetAsync($"api/TVs/modelId/{modelId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<TvDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task UpdateTv(int tvId, TvUpdateDto tvUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/TVs/id/{tvId}", tvUpdateDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }
    }
}
