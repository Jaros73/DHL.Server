using DHL.Server.Data;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DHL.Server.Features.Ciselniky.Services
{
    public class KurzyPEImportService
    {
        private readonly ApplicationDbContext _context;

        public KurzyPEImportService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> ImportFromCsvAsync(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Soubor '{filePath}' neexistuje.");

            var lines = await File.ReadAllLinesAsync(filePath);
            var result = new List<KurzyPEEntity>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim() == ";;")
                    continue;

                var parts = line.Split(';');

                if (parts.Length < 7)
                {
                    Console.WriteLine($"⚠️ Neplatný řádek: '{line}'");
                    continue;
                }

                if (!TimeSpan.TryParse(parts[5], out var prijezd) || !TimeSpan.TryParse(parts[6], out var odjezd))
                {
                    Console.WriteLine($"⚠️ Neplatný čas v řádku: '{line}'");
                    continue;
                }

                result.Add(new KurzyPEEntity
                {
                    AP = parts[0],
                    NazevKurzu = parts[1],
                    TC = parts[2],
                    PSCzastavky = parts[3],
                    Zastavka = parts[4],
                    Prijezd = prijezd,
                    Odjezd = odjezd,
                    DatumZ = DateTime.Parse(parts[7]),
                    DatumU = DateTime.Parse(parts[8])
                });
            }

            await _context.KurzyPEs.AddRangeAsync(result);
            return await _context.SaveChangesAsync();
        }
    }
}
