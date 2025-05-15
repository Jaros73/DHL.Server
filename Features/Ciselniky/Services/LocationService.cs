// Interface: ILocationService.cs
using DHL.Server.Features.Ciselniky.Models;

namespace DHL.Server.Features.Ciselniky.Interfaces
{
    public interface ILocationService
    {
        Task<List<LocationDto>> GetAllAsync();
        Task<LocationDto?> GetByIdAsync(int id);
        Task<LocationDto> CreateAsync(LocationDto dto);
        Task<LocationDto?> UpdateAsync(int id, LocationDto dto);
        Task<bool> DeleteAsync(int id);
    }
}