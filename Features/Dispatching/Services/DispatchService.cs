using AutoMapper;
using DHL.Server.Data;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using DHL.Server.Features.Dispatching.Interfaces;
using DHL.Server.Features.Dispatching.Models;
using DHL.Server.Models.DTO;

namespace DHL.Server.Features.Dispatching.Services
{
    public class DispatchService : IDispatchService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DispatchService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
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

        public async Task<List<DispatchModelDto>> GetAllDispatchesDtoAsync()
        {
            var entities = await _context.DispatchModels.ToListAsync();
            return _mapper.Map<List<DispatchModelDto>>(entities);
        }

        public async Task<DispatchModelDto?> GetDispatchDtoByIdAsync(int id)
        {
            var entity = await _context.DispatchModels.FirstOrDefaultAsync(d => d.Id == id);
            return entity == null ? null : _mapper.Map<DispatchModelDto>(entity);
        }

        public async Task<DispatchModelDto?> UpdateDispatchDtoAsync(int id, DispatchModelDto dto)
        {
            var entity = await _context.DispatchModels.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return _mapper.Map<DispatchModelDto>(entity);
        }

        public async Task<DispatchModelDto> CreateDispatchDtoAsync(DispatchModelDto dto)
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";
            var entity = _mapper.Map<DispatchModelEntity>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = userName;

            _context.DispatchModels.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<DispatchModelDto>(entity);
        }
    }
}
