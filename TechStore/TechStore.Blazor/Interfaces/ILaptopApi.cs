using TechStore.Blazor.DtoModels.Laptop;

namespace TechStore.Blazor.Interfaces
{
    public interface ILaptopApi
    {
        Task<IEnumerable<LaptopDto>> GetLaptops();
        Task<LaptopDto> GetLaptop(int id);
        Task AddLaptop(LaptopAddDto laptopAddDto);
        Task Update(int id, LaptopUpdateDto laptopUpdateDto);
        Task Delete(int id);
        Task<IEnumerable<LaptopDto>> GetLaptopsByRamId(int ramId);
        Task<IEnumerable<LaptopDto>> GetLaptopsByMemoryId(int memoryId);
        Task<IEnumerable<LaptopDto>> GetLaptopsByOSId(int osId);
        Task<IEnumerable<LaptopDto>> GetLaptopsByBrandId(int brandId);
        Task<IEnumerable<LaptopDto>> GetLaptopsByColorId(int colorId);
        Task<IEnumerable<LaptopDto>> GetLaptopsByModelId(int modelId);
    }
}
