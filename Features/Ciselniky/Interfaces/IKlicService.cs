using DHL.Server.Features.Ciselniky.Models;

namespace DHL.Server.Features.Ciselniky.Interfaces
{
    public interface IKlicService
    {
        Task<List<KlicDto>> GetAll();
        Task<List<KlicDto>> GetAllAsync();
        Task<List<KlicDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<KlicDto?> GetByIdAsync(int id);
        Task<KlicDto> CreateAsync(KlicDto dto);
        Task<KlicDto?> UpdateAsync(int id, KlicDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
