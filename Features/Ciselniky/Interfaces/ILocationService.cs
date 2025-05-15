//Service: LocationService.cs
using AutoMapper;
using DHL.Server.Data;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Features.Ciselniky.Models;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DHL.Server.Features.Ciselniky.Services
{
    public class LocationService : ILocationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public LocationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LocationDto>> GetAllAsync()
        {
            var entities = await _context.Locations.OrderBy(x => x.Name).ToListAsync();
            return _mapper.Map<List<LocationDto>>(entities);
        }

        public async Task<LocationDto?> GetByIdAsync(int id)
        {
            var entity = await _context.Locations.FindAsync(id);
            return entity == null ? null : _mapper.Map<LocationDto>(entity);
        }

        public async Task<LocationDto> CreateAsync(LocationDto dto)
        {
            var entity = _mapper.Map<LocationEntity>(dto);
            _context.Locations.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<LocationDto>(entity);
        }

        public async Task<LocationDto?> UpdateAsync(int id, LocationDto dto)
        {
            var entity = await _context.Locations.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<LocationDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Locations.FindAsync(id);
            if (entity == null) return false;

            _context.Locations.Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
