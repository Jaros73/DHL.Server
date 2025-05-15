// File: Services/ZastavkaService.cs
using AutoMapper;
using DHL.Server.Data;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Features.Ciselniky.Models;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DHL.Server.Features.Ciselniky.Services
{
    public class ZastavkaService : IZastavkaService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ZastavkaService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ZastavkaDto>> GetAllAsync()
        {
            var entities = await _context.Zastavkas.OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<ZastavkaDto>>(entities);
        }

        public async Task<ZastavkaDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Zastavkas.FindAsync(id);
            return entity == null ? null : _mapper.Map<ZastavkaDto>(entity);
        }

        public async Task<ZastavkaDto> CreateAsync(ZastavkaDto dto)
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";
            var entity = _mapper.Map<ZastavkaEntity>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = userName;

            _context.Zastavkas.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<ZastavkaDto>(entity);
        }

        public async Task<ZastavkaDto?> UpdateAsync(int id, ZastavkaDto dto)
        {
            var entity = await _context.Zastavkas.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<ZastavkaDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Zastavkas.FindAsync(id);
            if (entity == null) return false;

            _context.Zastavkas.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
