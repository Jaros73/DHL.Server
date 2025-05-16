using DHL.Server.Data;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Features.Ciselniky.Models;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace DHL.Server.Features.Ciselniky.Services
{
    public class CiselnikyService : IKlicService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CiselnikyService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<List<KlicDto>> GetAllAsync()
        {
            return GetAllAsync(CancellationToken.None);
        }


        public async Task<KlicDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Klics.FindAsync(id);
            return entity is null ? null : _mapper.Map<KlicDto>(entity);
        }

        public async Task<KlicDto> CreateAsync(KlicDto dto)
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";

            var entity = _mapper.Map<KlicEntity>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = string.IsNullOrWhiteSpace(dto.CreatedBy) ? userName : dto.CreatedBy;
            entity.Updated = DateTime.UtcNow;

            _context.Klics.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<KlicDto>(entity);
        }

        public async Task<KlicDto?> UpdateAsync(int id, KlicDto dto)
        {
            var entity = await _context.Klics.FindAsync(id);
            if (entity is null)
                return null;

            _mapper.Map(dto, entity);
            entity.Updated = DateTime.UtcNow; 

            await _context.SaveChangesAsync();
            return _mapper.Map<KlicDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Klics.FindAsync(id);
            if (entity is null)
                return false;

            _context.Klics.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        public Task<List<KlicDto>> GetAll()
        {
            return GetAllAsync();
        }
        public async Task<List<KlicDto>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _context.Klics
                .Where(k => k.IsActive)
                .OrderBy(k => k.Name)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<KlicDto>>(entities);
        }

    }
}
