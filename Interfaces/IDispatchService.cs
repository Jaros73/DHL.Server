using DHL.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DHL.Server.Interfaces
{
    public interface IDispatchService
    {
        Task<List<DispatchModel>> GetDispatchesAsync();
        Task<DispatchModel?> GetDispatchByIdAsync(int id);
        Task<List<DispatchModel>> GetFilteredDispatchesAsync(DispatchFilter filter);
        Task CreateDispatchAsync(DispatchModel newDispatch);
        Task DeleteDispatchAsync(int id);
        Task<DispatchMeta> GetMetadataAsync();
    }
}
