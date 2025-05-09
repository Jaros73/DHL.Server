using DHL.Server.Features.Ciselniky.Models;

namespace DHL.Server.Features.Ciselniky.Interfaces
{
    public interface ICiselnikyService
    {
        Task<List<KlicDto>> GetAllAsync();
        Task<KlicDto?> GetByIdAsync(int id);
        Task<KlicDto> CreateAsync(KlicDto dto);
        Task<KlicDto?> UpdateAsync(int id, KlicDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
