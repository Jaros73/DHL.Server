// File: Features/Ciselniky/Interfaces/IPrepravecService.cs
using DHL.Server.Features.Ciselniky.Models;

namespace DHL.Server.Features.Ciselniky.Interfaces
{
    public interface IPrepravceService
    {
        Task<List<PrepravceDto>> GetAllAsync();
        Task<PrepravceDto?> GetByIdAsync(int id);
        Task<PrepravceDto> CreateAsync(PrepravceDto dto);
        Task<PrepravceDto?> UpdateAsync(int id, PrepravceDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
