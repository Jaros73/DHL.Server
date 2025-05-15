using DHL.Server.Data;
using DHL.Server.Models.Entities;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Features.Ciselniky.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using static MudBlazor.CategoryTypes;
using AutoMapper.QueryableExtensions;

namespace DHL.Server.Features.Ciselniky.Services
{
    /// <summary>
    /// Služba pro práci s plánovanými kurzy PE.
    /// </summary>
    public class KurzyPEService : IKurzyPEService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly AutoMapper.IConfigurationProvider _config;

        public KurzyPEService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _config = mapper.ConfigurationProvider;
        }

        public async Task<List<KurzyPEDto>> GetAllAsync()
        {
            return await _context.KurzyPEs
                .OrderBy(k => k.NazevKurzu)
                .ProjectTo<KurzyPEDto>(_config)
                .ToListAsync();
        }

        public async Task<KurzyPEDto?> GetByIdAsync(int id)
        {
            return await _context.KurzyPEs
                            .Where(k => k.Id == id)
                            .ProjectTo<KurzyPEDto>(_config)
                            .FirstOrDefaultAsync();
        }

        public async Task<KurzyPEDto> CreateAsync(KurzyPEDto dto)
        {
            var entity = _mapper.Map<KurzyPEEntity>(dto);
            _context.KurzyPEs.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<KurzyPEDto>(entity);
        }

        public async Task<KurzyPEDto?> UpdateAsync(int id, KurzyPEDto dto)
        {
            var entity = await _context.KurzyPEs.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<KurzyPEDto>(entity);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.KurzyPEs.FindAsync(id);
            if (entity == null) return false;

            _context.KurzyPEs.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<(IEnumerable<KurzyPEDto> Items, int TotalCount)> GetPageAsync(int skip, int take, string? search)
        {
            var query = _context.KurzyPEs.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(k =>
                    k.AP.Contains(search) ||
                    k.NazevKurzu.Contains(search) ||
                    k.Zastavka.Contains(search));
            }

            var total = await query.CountAsync();
            var items = await query
                .OrderBy(k => k.AP)
                .Skip(skip)
                .Take(take)
                .ProjectTo<KurzyPEDto>(_config)
                .ToListAsync();

            return (items, total);
        }
    }
}