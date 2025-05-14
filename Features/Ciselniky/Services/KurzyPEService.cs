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
                .Select(k => new KurzyPEDto
                {
                    Id = k.Id,
                    AP = k.AP,
                    NazevKurzu = k.NazevKurzu,
                    TC = k.TC,
                    PSCzastavky = k.PSCzastavky,
                    Zastavka = k.Zastavka,
                    Prijezd = k.Prijezd,
                    Odjezd = k.Odjezd,
                    DatumZ = k.DatumZ,
                    DatumU = k.DatumU
                })
                .ToListAsync();
        }

        public async Task<KurzyPEDto?> GetByIdAsync(int id)
        {
            var kurz = await _context.KurzyPEs.FindAsync(id);
            if (kurz == null) return null;

            return new KurzyPEDto
            {
                Id = kurz.Id,
                AP = kurz.AP,
                NazevKurzu = kurz.NazevKurzu,
                TC = kurz.TC,
                PSCzastavky = kurz.PSCzastavky,
                Zastavka = kurz.Zastavka,
                Prijezd = kurz.Prijezd,
                Odjezd = kurz.Odjezd,
                DatumZ = kurz.DatumZ,
                DatumU = kurz.DatumU
            };
        }

        public async Task<KurzyPEDto> CreateAsync(KurzyPEDto dto)
        {
            var entity = new KurzyPEEntity
            {
                AP = dto.AP,
                NazevKurzu = dto.NazevKurzu,
                TC = dto.TC,
                PSCzastavky = dto.PSCzastavky,
                Zastavka = dto.Zastavka,
                Prijezd = dto.Prijezd,
                Odjezd = dto.Odjezd,
                DatumZ = dto.DatumZ,
                DatumU = dto.DatumU
            };

            _context.KurzyPEs.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id;
            return dto;
        }

        public async Task<KurzyPEDto?> UpdateAsync(int id, KurzyPEDto dto)
        {
            var entity = await _context.KurzyPEs.FindAsync(id);
            if (entity == null) return null;

            entity.AP = dto.AP;
            entity.NazevKurzu = dto.NazevKurzu;
            entity.TC = dto.TC;
            entity.PSCzastavky = dto.PSCzastavky;
            entity.Zastavka = dto.Zastavka;
            entity.Prijezd = dto.Prijezd;
            entity.Odjezd = dto.Odjezd;
            entity.DatumZ = dto.DatumZ;
            entity.DatumU = dto.DatumU;

            await _context.SaveChangesAsync();
            return dto;
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
            var data = await query
                .OrderBy(k => k.AP)
                .Skip(skip)
                .Take(take)
                .Select(k => new KurzyPEDto
                {
                    Id = k.Id,
                    AP = k.AP,
                    NazevKurzu = k.NazevKurzu,
                    TC = k.TC,
                    Zastavka = k.Zastavka,
                    PSCzastavky = k.PSCzastavky,
                    Prijezd = k.Prijezd,
                    Odjezd = k.Odjezd
                })
                .ToListAsync();

            return (data, total);
        }


    }
}