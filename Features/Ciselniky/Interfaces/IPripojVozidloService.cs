// Interface: Features/Ciselniky/Interfaces/IPripojVozidloService.cs
using DHL.Server.Features.Ciselniky.Models;

namespace DHL.Server.Features.Ciselniky.Interfaces
{
    public interface IPripojVozidloService
    {
        Task<List<PripojVozidloDto>> GetAllAsync();
        Task<PripojVozidloDto?> GetByIdAsync(int id);
        Task<PripojVozidloDto> CreateAsync(PripojVozidloDto dto);
        Task<PripojVozidloDto?> UpdateAsync(int id, PripojVozidloDto dto);
        Task<bool> DeleteAsync(int id);
    }
}