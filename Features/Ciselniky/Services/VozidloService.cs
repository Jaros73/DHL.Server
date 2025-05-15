using AutoMapper;
using DHL.Server.Data;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Features.Ciselniky.Models;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DHL.Server.Features.Ciselniky.Services
{
    public class VozidloService : IVozidloService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public VozidloService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<VozidloDto>> GetAllAsync()
        {
            var entities = await _context.Vozidlos.OrderBy(x => x.RZ).ToListAsync();
            return _mapper.Map<List<VozidloDto>>(entities);
        }

        public async Task<VozidloDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Vozidlos.FindAsync(id);
            return entity == null ? null : _mapper.Map<VozidloDto>(entity);
        }

        public async Task<VozidloDto> CreateAsync(VozidloDto dto)
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";

            var entity = _mapper.Map<VozidloEntity>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = userName;

            _context.Vozidlos.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<VozidloDto>(entity);
        }

        public async Task<VozidloDto?> UpdateAsync(int id, VozidloDto dto)
        {
            var entity = await _context.Vozidlos.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<VozidloDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Vozidlos.FindAsync(id);
            if (entity == null) return false;

            _context.Vozidlos.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
