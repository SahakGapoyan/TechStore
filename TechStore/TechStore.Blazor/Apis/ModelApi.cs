using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.Model;
using TechStore.Blazor.DtoModels.Result;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor.Apis
{
    public class ModelApi : IModelApi
    {
        private readonly HttpClient _httpClient;

        public ModelApi(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUri);
        }

        public async Task<ApiResult<bool>> AddModel(ModelAddDto modelAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Models", modelAddDto);
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

        public async Task DeleteModel(int modelId)
        {
            var response = await _httpClient.DeleteAsync($"api/Models/id/{modelId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }

        public async Task<ModelDto> GetModel(int id)
        {
            var response = await _httpClient.GetAsync($"api/Models/id/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ModelDto>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<ModelDto>> GetModels()
        {
            var response = await _httpClient.GetAsync("api/Models");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ModelDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<ModelDto>> GetModelsByCategoryId(int categoryId)
        {
            var response = await _httpClient.GetAsync($"api/Models/categoryId/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ModelDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task UpdateModel(int modelId, ModelUpdateDto modelUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Models/id/{modelId}", modelUpdateDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }
    }
}
