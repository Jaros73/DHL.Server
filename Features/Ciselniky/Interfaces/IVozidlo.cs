using DHL.Server.Features.Ciselniky.Models;

namespace DHL.Server.Features.Ciselniky.Interfaces
{
    public interface IVozidloService
    {
        Task<List<VozidloDto>> GetAllAsync();
        Task<VozidloDto?> GetByIdAsync(int id);
        Task<VozidloDto> CreateAsync(VozidloDto dto);
        Task<VozidloDto?> UpdateAsync(int id, VozidloDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
