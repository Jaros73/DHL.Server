// File: Features/Ciselniky/Services/PrepravceService.cs
using DHL.Server.Data;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Features.Ciselniky.Models;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace DHL.Server.Features.Ciselniky.Services
{
    public class PrepravceService : IPrepravceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PrepravceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PrepravceDto>> GetAllAsync()
        {
            var entities = await _context.Prepravces.OrderBy(k => k.Name).ToListAsync();
            return _mapper.Map<List<PrepravceDto>>(entities);
        }

        public async Task<PrepravceDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Prepravces.FindAsync(id);
            if (entity == null) return null;

            return new PrepravceDto
            {
                Id = entity.Id,
                Name = entity.Name,
                IsActive = entity.IsActive,
                CreatedAt = entity.CreatedAt,
                CreatedBy = entity.CreatedBy
            };
        }

        public async Task<PrepravceDto> CreateAsync(PrepravceDto dto)
        {
            var entity = new PrepravceEntity
            {
                Name = dto.Name,
                IsActive = dto.IsActive,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = string.IsNullOrWhiteSpace(dto.CreatedBy) ? "system" : dto.CreatedBy
            };

            _context.Prepravces.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            dto.CreatedAt = entity.CreatedAt;
            return dto;
        }

        public async Task<PrepravceDto?> UpdateAsync(int id, PrepravceDto dto)
        {
            var entity = await _context.Prepravces.FindAsync(id);
            if (entity == null) return null;

            entity.Name = dto.Name;
            entity.IsActive = dto.IsActive;
            await _context.SaveChangesAsync();

            return dto;
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
