// File: Services/ZpozdeniKurzuService.cs
using AutoMapper;
using AutoMapper.QueryableExtensions;
using DHL.Server.Data;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Features.Ciselniky.Models;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DHL.Server.Features.Ciselniky.Services
{
    public class ZpozdeniKurzuService : IZpozdeniKurzuService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public ZpozdeniKurzuService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<List<ZpozdeniKurzuDto>> GetAllAsync()
        {
            var entities = await _context.ZpozdeniKurzus.OrderBy(k => k.Duvod).ToListAsync();
            return _mapper.Map<List<ZpozdeniKurzuDto>>(entities);
        }

        public async Task<ZpozdeniKurzuDto?> GetByIdAsync(int id)
        {
            var entity = await _context.ZpozdeniKurzus.FindAsync(id);
            return entity is null ? null : _mapper.Map<ZpozdeniKurzuDto>(entity);
        }

        public async Task<ZpozdeniKurzuDto> CreateAsync(ZpozdeniKurzuDto dto)
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "systemA";

            var entity = _mapper.Map<ZpozdeniKurzuEntity>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = string.IsNullOrWhiteSpace(dto.CreatedBy) ? userName : dto.CreatedBy;

            _context.ZpozdeniKurzus.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<ZpozdeniKurzuDto>(entity);
        }

        public async Task<ZpozdeniKurzuDto?> UpdateAsync(int id, ZpozdeniKurzuDto dto)
        {
            var entity = await _context.ZpozdeniKurzus.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity); 
            await _context.SaveChangesAsync();

            return _mapper.Map<ZpozdeniKurzuDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.ZpozdeniKurzus.FindAsync(id);
            if (entity == null) return false;

            _context.ZpozdeniKurzus.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
