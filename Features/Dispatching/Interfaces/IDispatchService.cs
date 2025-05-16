using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DHL.Server.Features.Dispatching.Models;
using DHL.Server.Models.DTO;
using DHL.Server.Models.Entities;

namespace DHL.Server.Features.Dispatching.Interfaces
{
    public interface IDispatchService
    {
        // Entity-based
        Task<List<DispatchModelEntity>> GetDispatchesAsync(CancellationToken cancellationToken = default);
        Task<DispatchModelEntity?> GetDispatchByIdAsync(int id);
        Task<List<DispatchModelEntity>> GetFilteredDispatchesAsync(DispatchFilter filter);
        Task CreateDispatchAsync(DispatchModelEntity newDispatch);
        Task DeleteDispatchAsync(int id);

        // DTO-based
        Task<List<DispatchModelDto>> GetAllDispatchesDtoAsync();
        Task<DispatchModelDto?> GetDispatchDtoByIdAsync(int id);
        Task<DispatchModelDto> CreateDispatchDtoAsync(DispatchModelDto dto);
        Task<DispatchModelDto?> UpdateDispatchDtoAsync(int id, DispatchModelDto dto);

        // Metadata
        Task<DispatchMeta> GetMetadataAsync();
    }
}
