using DHL.Server.Features.Ciselniky.Models;

namespace DHL.Server.Features.Ciselniky.Interfaces
{
    /// <summary>
    /// Rozhraní pro službu spravující plánované kurzy PE.
    /// </summary>
    public interface IKurzyPEService
    {
        Task<List<KurzyPEDto>> GetAllAsync();
        Task<KurzyPEDto?> GetByIdAsync(int id);
        Task<KurzyPEDto> CreateAsync(KurzyPEDto dto);
        Task<KurzyPEDto?> UpdateAsync(int id, KurzyPEDto dto);
        Task<bool> DeleteAsync(int id);
        Task<(IEnumerable<KurzyPEDto> Items, int TotalCount)> GetPageAsync(int skip, int take, string? search);



    }
}