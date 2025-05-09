﻿using DHL.Server.Models.DTO;
using DHL.Server.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DHL.Server.Data;


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
    }
}
