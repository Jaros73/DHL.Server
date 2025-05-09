﻿using AutoMapper;
using DHL.Server.Data;
using DHL.Server.Models.Entities;
using DHL.Server.Models.DTO;
using Microsoft.EntityFrameworkCore;
using DHL.Server.Features.Dispatching.Interfaces;

namespace DHL.Server.Features.Dispatching.Services
{
    public class DispatchService : IDispatchService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper; 

        public DispatchService(ApplicationDbContext context, IMapper mapper) 
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task CreateDispatchAsync(DispatchModelEntity newDispatch)
        {
            _context.DispatchModels.Add(newDispatch);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDispatchAsync(int id)
        {
            var dispatch = await _context.DispatchModels.FindAsync(id);
            if (dispatch != null)
            {
                _context.DispatchModels.Remove(dispatch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DispatchMeta> GetMetadataAsync()
        {
            var locations = await _context.Locations.ToListAsync();
            var types = await _context.DispatchTypes.ToListAsync();
            var keys = await _context.DispatchKeys.ToListAsync();

            return new DispatchMeta
            {
                Locations = _mapper.Map<List<Location>>(locations),
                Types = _mapper.Map<List<DispatchType>>(types),
                Keys = _mapper.Map<List<DispatchKey>>(keys)
            };
        }

        public async Task<DispatchModelEntity?> GetDispatchByIdAsync(int id)
        {
            return await _context.DispatchModels.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<DispatchModelEntity>> GetFilteredDispatchesAsync(DispatchFilter filter)
        {
            var query = _context.DispatchModels.AsQueryable();

            if (filter.CreatedAt != null)
            {
                if (filter.CreatedAt.From.HasValue)
                    query = query.Where(d => d.CreatedAt >= filter.CreatedAt.From.Value);

                if (filter.CreatedAt.To.HasValue)
                    query = query.Where(d => d.CreatedAt <= filter.CreatedAt.To.Value);
            }

            if (filter.LocationIds != null && filter.LocationIds.Any())
                query = query.Where(d => filter.LocationIds.Contains(d.LocationId.ToString()));

            if (filter.TypeEnumIds != null && filter.TypeEnumIds.Any())
                query = query.Where(d => filter.TypeEnumIds.Contains(d.TypeEnumId));

            if (filter.KeyEnumIds != null && filter.KeyEnumIds.Any())
                query = query.Where(d => filter.KeyEnumIds.Contains(d.KeyEnumId));

            return await query.ToListAsync();
        }

        public async Task<List<DispatchModelEntity>> GetDispatchesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.DispatchModels.ToListAsync(cancellationToken);
        }

    }
}
