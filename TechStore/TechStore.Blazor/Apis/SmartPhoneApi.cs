using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using TechStore.Blazor.Configuration;
using TechStore.Blazor.DtoModels.SmartPhone;
using TechStore.Blazor.Interfaces;

namespace TechStore.Blazor.Apis
{
    public class SmartPhoneApi : ISmartPhoneApi
    {
        private readonly HttpClient _httpClient;

        public SmartPhoneApi(HttpClient httpClient, IOptions<ApiSettings> options)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(options.Value.BaseUri);
        }
        public async Task AddSmartPhone(SmartPhoneAddDto smartPhoneAddDto)
        {
            var response = await _httpClient.PostAsJsonAsync("api/SmartPhones", smartPhoneAddDto);
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }

        public async Task Delete(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/SmartPhones/id/{id}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }

        public async Task<SmartPhoneDto> GetSmartPhone(int id)
        {
            var response = await _httpClient.GetAsync($"api/SmartPhones/id/{id}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<SmartPhoneDto>();
            }
            throw new Exception("Error " + response.ReasonPhrase);

        }

        public async Task<IEnumerable<SmartPhoneDto>> GetSmartPhones()
        {
            var response = await _httpClient.GetAsync("api/SmartPhones");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SmartPhoneDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByBrandId(int brandId)
        {
            var response = await _httpClient.GetAsync($"api/SmartPhones/brandId/{brandId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SmartPhoneDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByColorId(int colorId)
        {
            var response = await _httpClient.GetAsync($"api/SmartPhones/colorId/{colorId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SmartPhoneDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }
        public async Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByModelId(int modelId)
        {
            var response = await _httpClient.GetAsync($"api/SmartPhones/modelId/{modelId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SmartPhoneDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByMemoryId(int memoryId)
        {
            var response = await _httpClient.GetAsync($"api/SmartPhones/memoryId/{memoryId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SmartPhoneDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByOSId(int osId)
        {
            var response = await _httpClient.GetAsync($"api/SmartPhones/osId/{osId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SmartPhoneDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByRamId(int ramId)
        {
            var response = await _httpClient.GetAsync($"api/SmartPhones/ramId/{ramId}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<IEnumerable<SmartPhoneDto>>();
            }
            throw new Exception("Error " + response.ReasonPhrase);
        }

        public async Task Update(int id,SmartPhoneUpdateDto smartPhoneUpdateDto)
        {
            var response = await _httpClient.PutAsJsonAsync("api/SmartPhones/id/{id}", smartPhoneUpdateDto);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error " + response.ReasonPhrase);
            }
        }


    }
}
