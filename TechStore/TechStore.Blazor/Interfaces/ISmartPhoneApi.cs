using TechStore.Blazor.DtoModels.Product;
using TechStore.Blazor.DtoModels.Result;
using TechStore.Blazor.DtoModels.SmartPhone;

namespace TechStore.Blazor.Interfaces
{
    public interface ISmartPhoneApi
    {
        Task<IEnumerable<SmartPhoneDto>> GetSmartPhones();
        Task<SmartPhoneDto> GetSmartPhone(int id);
        Task<ApiResult<bool>> AddSmartPhone(SmartPhoneAddDto smartPhoneAddDto);
        Task<ApiResult<bool>> Update(int id,SmartPhoneUpdateDto smartPhoneUpdateDto);
        Task Delete(int id);
        Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByRamId(int ramId);
        Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByMemoryId(int memoryId);
        Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByOSId(int osId);
        Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByColorId(int colorId);
        Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByBrandId(int brandId);
        Task<IEnumerable<SmartPhoneDto>> GetSmartPhonesByModelId(int brandId);
        Task<IEnumerable<ProductSuggestionDto>> GetSmartPhoneSuggestions(string query);
    }
}
