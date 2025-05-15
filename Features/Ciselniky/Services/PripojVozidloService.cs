// Service: Features/Ciselniky/Services/PripojVozidloService.cs
using AutoMapper;
using DHL.Server.Data;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Features.Ciselniky.Models;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DHL.Server.Features.Ciselniky.Services
{
    public class PripojVozidloService : IPripojVozidloService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PripojVozidloService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<PripojVozidloDto>> GetAllAsync()
        {
            var entities = await _context.PripojVozidlos.OrderBy(x => x.RZ).ToListAsync();
            return _mapper.Map<List<PripojVozidloDto>>(entities);
        }

        public async Task<PripojVozidloDto?> GetByIdAsync(int id)
        {
            var entity = await _context.PripojVozidlos.FindAsync(id);
            return entity == null ? null : _mapper.Map<PripojVozidloDto>(entity);
        }

        public async Task<PripojVozidloDto> CreateAsync(PripojVozidloDto dto)
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";
            var entity = _mapper.Map<PripojVozidloEntity>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = userName;

            _context.PripojVozidlos.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<PripojVozidloDto>(entity);
        }

        public async Task<PripojVozidloDto?> UpdateAsync(int id, PripojVozidloDto dto)
        {
            var entity = await _context.PripojVozidlos.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<PripojVozidloDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.PripojVozidlos.FindAsync(id);
            if (entity == null) return false;

            _context.PripojVozidlos.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
