using TechStore.Blazor.DtoModels.SmartPhone;

namespace TechStore.Blazor.Interfaces
{
    public interface ISmartPhoneApi
    {
        Task<IEnumerable<SmartPhoneDto>> GetSmartPhones();
        Task<SmartPhoneDto> GetSmartPhone(int id);
        Task AddSmartPhone(SmartPhoneAddDto smartPhoneAddDto);
        Task Update(int id,SmartPhoneUpdateDto smartPhoneUpdateDto);
        Task Delete(int id);
    }
}
