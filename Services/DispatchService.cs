using DHL.Server.Models;
using DHL.Server.Data;
using DHL.Server.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace DHL.Server.Services
{
    public class DispatchService : IDispatchService
    {
        private readonly ApplicationDbContext _context;

        public DispatchService(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<DispatchModel>> GetDispatchesAsync()
        {
            return await _context.Dispatches.ToListAsync();
        }

        public async Task CreateDispatchAsync(DispatchModel newDispatch)
        {
            _context.Dispatches.Add(newDispatch);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDispatchAsync(int id)
        {
            var dispatch = await _context.Dispatches.FindAsync(id);
            if (dispatch != null)
            {
                _context.Dispatches.Remove(dispatch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<DispatchMeta> GetMetadataAsync()
        {
            return new DispatchMeta
            {
                Locations = await _context.Locations.ToListAsync(),
                Types = await _context.DispatchTypes.ToListAsync(),
                Keys = await _context.DispatchKeys.ToListAsync()
            };
        }

        public async Task<DispatchModel?> GetDispatchByIdAsync(int id)
        {
            return await _context.Dispatches.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<DispatchModel>> GetFilteredDispatchesAsync(DispatchFilter filter)
        {
            var query = _context.Dispatches.AsQueryable();

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
    }
}
