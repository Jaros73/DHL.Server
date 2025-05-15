using DHL.Server.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DHL.Server.Data;
using DHL.Server.Features.Dispatching.Models;


namespace DHL.Server.Features.Dispatching.Interfaces
{
    public interface IDispatchService
    {
        Task<List<DispatchModelEntity>> GetDispatchesAsync(CancellationToken cancellationToken = default);
        Task<DispatchModelEntity?> GetDispatchByIdAsync(int id);
        Task<List<DispatchModelEntity>> GetFilteredDispatchesAsync(DispatchFilter filter);
        Task CreateDispatchAsync(DispatchModelEntity newDispatch);
        Task DeleteDispatchAsync(int id);
        Task<DispatchMeta> GetMetadataAsync();
        Task<List<DispatchModelDto>> GetAllDispatchesDtoAsync();
        Task<DispatchModelDto?> GetDispatchDtoByIdAsync(int id);
        Task<DispatchModelDto> CreateDispatchDtoAsync(DispatchModelDto dto);
        Task<DispatchModelDto?> UpdateDispatchDtoAsync(int id, DispatchModelDto dto);
        

    }
}
