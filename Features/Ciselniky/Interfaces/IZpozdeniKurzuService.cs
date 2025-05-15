
// File: Interfaces/IZpozdeniKurzuService.cs
using DHL.Server.Features.Ciselniky.Models;

namespace DHL.Server.Features.Ciselniky.Interfaces
{
    public interface IZpozdeniKurzuService
    {
        Task<List<ZpozdeniKurzuDto>> GetAllAsync();
        Task<ZpozdeniKurzuDto?> GetByIdAsync(int id);
        Task<ZpozdeniKurzuDto> CreateAsync(ZpozdeniKurzuDto dto);
        Task<ZpozdeniKurzuDto?> UpdateAsync(int id, ZpozdeniKurzuDto dto);
        Task<bool> DeleteAsync(int id);
    }
}