using AutoMapper;
using DHL.Server.Data;
using DHL.Server.Features.Kurzy.Interfaces;
using DHL.Server.Features.Kurzy.Models;
using Microsoft.EntityFrameworkCore;



namespace DHL.Server.Features.Kurzy.Services
{
    public class KurzyDispatchService : IKurzyDispatchService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public KurzyDispatchService(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<IEnumerable<KurzyDispatchDto>> GetAllAsync()
        {
            var entities = await _db.KurzyDispatch.ToListAsync();
            return _mapper.Map<IEnumerable<KurzyDispatchDto>>(entities);
        }

        public async Task<KurzyDispatchDto?> GetByIdAsync(int id)
        {
            var entity = await _db.KurzyDispatch.FindAsync(id);
            return entity == null ? null : _mapper.Map<KurzyDispatchDto>(entity);
        }

        public async Task<KurzyDispatchDto> CreateAsync(KurzyDispatchDto dto)
        {
            var entity = _mapper.Map<KurzyDispatchEntity>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            _db.KurzyDispatch.Add(entity);
            await _db.SaveChangesAsync();

            return _mapper.Map<KurzyDispatchDto>(entity);
        }

        public async Task<KurzyDispatchDto?> UpdateAsync(int id, KurzyDispatchDto dto)
        {
            var entity = await _db.KurzyDispatch.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return _mapper.Map<KurzyDispatchDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _db.KurzyDispatch.FindAsync(id);
            if (entity == null) return false;

            _db.KurzyDispatch.Remove(entity);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
