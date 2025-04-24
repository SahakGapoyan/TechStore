using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.Category;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor.Apis
{
    public class CategoryApi : ICategoryApi
    {
        private readonly HttpClient _httpclient;

        public CategoryApi(HttpClient httpclient,IOptions<ApiSettings> options)
        {
            _httpclient = httpclient;
            _httpclient.BaseAddress = new Uri(options.Value.BaseUri);
        }
        public async Task AddCategory(CategoryAddDto categoryAddDto)
        {
            var response = await _httpclient.PostAsJsonAsync("api/Categories", categoryAddDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }

        public async Task DeleteCategory(int id)
        {
            var response = await _httpclient.DeleteAsync($"api/Categories/id/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var response = await _httpclient.GetAsync("api/Categories");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<CategoryDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task<CategoryDto> GetCategory(int id)
        {
            var response = await _httpclient.GetAsync($"api/Categories/id/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<CategoryDto>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task UpdateCategory(int id, CategoryUpdateDto categoryUpdateDto)
        {
            var response = await _httpclient.PutAsJsonAsync($"api/Categories/id/{id}", categoryUpdateDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }
    }
}