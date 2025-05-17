using DHL.Server.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using DHL.Server.Interfaces;
using DHL.Server.Models.DTO;
using DHL.Server.Models.Entities;

namespace DHL.Server.Services
{
    public class ObalService : IObalService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ObalService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<List<ObalDto>> GetAllAsync()
        {
            var entities = await _db.Obals.AsNoTracking().ToListAsync();
            return _mapper.Map<List<ObalDto>>(entities);
        }

        public async Task<ObalDto?> GetByIdAsync(int id)
        {
            var entity = await _db.Obals.FindAsync(id);
            return entity == null ? null : _mapper.Map<ObalDto>(entity);
        }

        public async Task<ObalDto> CreateAsync(ObalDto dto)
        {
            var entity = _mapper.Map<ObalEntity>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            _db.Obals.Add(entity);
            await _db.SaveChangesAsync();

            return _mapper.Map<ObalDto>(entity);
        }

        public async Task UpdateAsync(ObalDto dto)
        {
            var entity = await _db.Obals.FindAsync(dto.Id);
            if (entity == null) return;

            _mapper.Map(dto, entity);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.Obals.FindAsync(id);
            if (entity == null) return false;

            _db.Obals.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ObalDto>> GetBySourceAsync(string sourceType, int sourceId)
        {
            var entities = await _db.Obals
                .Where(x => x.SourceType == sourceType && x.SourceId == sourceId)
                .ToListAsync();

            return _mapper.Map<IEnumerable<ObalDto>>(entities);
        }
    }
}
