// File: Features/Ciselniky/Services/PrepravceService.cs
using DHL.Server.Data;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Features.Ciselniky.Models;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DHL.Server.Features.Ciselniky.Services
{
    public class PrepravceService : IPrepravceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public PrepravceService(ApplicationDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<PrepravceDto>> GetAllAsync()
        {
            var entities = await _context.Prepravces.OrderBy(k => k.Name).ToListAsync();
            return _mapper.Map<List<PrepravceDto>>(entities);
        }

        public async Task<PrepravceDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Prepravces.FindAsync(id);
            return entity is null ? null : _mapper.Map<PrepravceDto?>(entity);
        }

        public async Task<PrepravceDto> CreateAsync(PrepravceDto dto)
        {
            var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "system";
            var entity = _mapper.Map<PrepravceEntity>(dto);
            entity.Name = dto.Name;
            entity.IsActive = dto.IsActive;
            entity.CreatedAt = DateTime.UtcNow;
            entity.CreatedBy = string.IsNullOrWhiteSpace(dto.CreatedBy) ? userName : dto.CreatedBy;

            _context.Prepravces.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<PrepravceDto>(entity);
        }

        public async Task<PrepravceDto?> UpdateAsync(int id, PrepravceDto dto)
        {
            var entity = await _context.Prepravces.FindAsync(id);
            if (entity is null)
                return null;

            _mapper.Map(dto, entity);
            entity.Name = dto.Name;
            entity.IsActive = dto.IsActive;

            await _context.SaveChangesAsync();
            return _mapper.Map<PrepravceDto?>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Prepravces.FindAsync(id);
            if (entity == null) return false;

            _context.Prepravces.Remove(entity);
            await _context.SaveChangesAsync();
            return true;

        }
    }
}
