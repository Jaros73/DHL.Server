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

        public CiselnikyService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<KlicDto>> GetAllAsync()
        {
            var entities = await _context.Klics.OrderBy(k => k.Name).ToListAsync();
            return _mapper.Map<List<KlicDto>>(entities);
        }

        public async Task<KlicDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Klics.FindAsync(id);
            return entity is null ? null : _mapper.Map<KlicDto>(entity);
        }

        public async Task<KlicDto> CreateAsync(KlicDto dto)
        {
            var entity = _mapper.Map<KlicEntity>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            entity.Updated = DateTime.UtcNow;

            _context.Klics.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<KlicDto>(entity);
        }

        public async Task<KlicDto?> UpdateAsync(int id, KlicDto dto)
        {
            Console.WriteLine($"Update received IsActive = {dto.IsActive}");

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
    }
}
