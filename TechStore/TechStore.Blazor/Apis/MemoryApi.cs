using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.Memory;
using TechStore.Blazor.DtoModels.Result;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor.Apis
{
    public class MemoryApi : IMemoryApi
    {
        private readonly HttpClient _httpClient;

        public MemoryApi(HttpClient httpClient, IOptions<ApiLaptopSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUri);
        }
        public async Task<IEnumerable<MemoryDto>> GetMemories()
        {
            var response = await _httpClient.GetAsync("api/Memories");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<MemoryDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<MemoryDto> GetMemory(int id)
        {
            var response = await _httpClient.GetAsync($"api/Memories/id/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<MemoryDto>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<IEnumerable<MemoryDto>> GetMemoriesByCategoryId(int categoryId)
        {
            var response = await _httpClient.GetAsync($"api/Memories/categoryId/{categoryId}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<MemoryDto>>();
            }

            throw new Exception("Error" + response.ReasonPhrase);
        }

        public async Task<ApiResult<bool>> AddMemory(MemoryAddDto memoryAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Memories", memoryAddDto);
            if (response.IsSuccessStatusCode)
            {
                return new ApiResult<bool> { Success = true, Data = true };
            }
            return await ApiResult<bool>.FromHttpResponseAsync(response);
        }

        public async Task<ApiResult<bool>> UpdateMemory(int memoryId, MemoryUpdateDto memoryUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Memories/id/{memoryId}", memoryUpdateDto);
            if (response.IsSuccessStatusCode)
            {
                return new ApiResult<bool> { Success = true, Data = true };
            }
            return await ApiResult<bool>.FromHttpResponseAsync(response);
        }

        public async Task DeleteMemory(int memoryId)
        {
            var response = await _httpClient.DeleteAsync($"api/Memories/id/{memoryId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }
    }
}
