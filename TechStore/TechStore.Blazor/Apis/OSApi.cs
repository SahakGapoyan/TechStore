using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.OS;
using TechStore.Blazor.DtoModels.Result;
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

        public async Task<ApiResult<bool>> AddOS(OSAddDto osAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/OSes", osAddDto);
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

        public async Task DeleteOS(int osId)
        {
            var response = await _httpClient.DeleteAsync($"api/OSes/id/{osId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
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

        public async Task<IEnumerable<OSDto>> GetOsesByCategoryId(int categoryId)
        {
            var response = await _httpClient.GetAsync($"api/OSes/categoryId/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<OSDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task UpdateOS(int osId, OSUpdateDto osUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/OSes/id/{osId}", osUpdateDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }
    }
}
