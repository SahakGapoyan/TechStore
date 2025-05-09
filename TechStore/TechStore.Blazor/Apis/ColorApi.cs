using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.Color;
using TechStore.Blazor.DtoModels.Result;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor.Apis
{
    public class ColorApi:IColorApi
    {
        private readonly HttpClient _httpClient;

        public ColorApi(HttpClient httpClient, IOptions<ApiColorSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUri);
        }

        public async Task<ApiResult<bool>> AddColor(ColorAddDto colorAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Colors", colorAddDto);
            if (response.IsSuccessStatusCode)
            {
                return new ApiResult<bool> { Success = true, Data = true };
            }
            return await ApiResult<bool>.FromHttpResponseAsync(response);
        }

        public async Task DeleteColor(int colorId)
        {
            var response = await _httpClient.DeleteAsync($"api/Colors/id/{colorId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
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

        public async Task<IEnumerable<ColorDto>> GetColorsByCategoryId(int categoryId)
        {
            var response = await _httpClient.GetAsync($"api/Colors/categoryId/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<ColorDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<ApiResult<bool>> UpdateColor(int colorId, ColorUpdateDto colorUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Colors/id/{colorId}", colorUpdateDto);
            if (response.IsSuccessStatusCode)
            {
                return new ApiResult<bool> { Success = true, Data = true };
            }
            return await ApiResult<bool>.FromHttpResponseAsync(response);
        }
    }
}
