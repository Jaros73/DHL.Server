using DHL.Server.Models.DTO;

namespace DHL.Server.Interfaces
{
    public interface IObalService
    {
        Task<List<ObalDto>> GetAllAsync();
        Task<ObalDto?> GetByIdAsync(int id);
        Task<ObalDto> CreateAsync(ObalDto obal);
        Task UpdateAsync(ObalDto obal);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<ObalDto>> GetBySourceAsync(string sourceType, int sourceId);
    }
}
