using DHL.Server.Features.Kurzy.Models;

namespace DHL.Server.Features.Kurzy.Interfaces
{
    public interface IKurzyDispatchService
    {
        Task<IEnumerable<KurzyDispatchDto>> GetAllAsync();
        Task<KurzyDispatchDto?> GetByIdAsync(int id);
        Task<KurzyDispatchDto> CreateAsync(KurzyDispatchDto dto);
        Task<KurzyDispatchDto?> UpdateAsync(int id, KurzyDispatchDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
