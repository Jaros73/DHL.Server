using DHL.Server.Data;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace DHL.Server.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationDbContext context)
        {
            await context.Database.EnsureCreatedAsync();

            if (!await context.Locations.AnyAsync())
            {
                var locations = await LoadLocationsAsync();
                await context.Locations.AddRangeAsync(locations);
                await context.SaveChangesAsync();
            }

            if (!await context.Klics.AnyAsync())
            {
                var klics = await LoadKlicsAsync();
                await context.Klics.AddRangeAsync(klics);
                await context.SaveChangesAsync();
            }

            if (!await context.KurzyPEs.AnyAsync())
            {
                var kurzs = await LoadKurzyPEsAsync();
                await context.KurzyPEs.AddRangeAsync(kurzs);
                await context.SaveChangesAsync();
            }

            if (!await context.Zastavkas.AnyAsync())
            {
                var zastavkas = await LoadZastavkasAsync();
                await context.Zastavkas.AddRangeAsync(zastavkas);
                await context.SaveChangesAsync();
            }
        }

        private static async Task<List<LocationEntity>> LoadLocationsAsync()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Seed", "Locations.csv");
            var lines = await File.ReadAllLinesAsync(filePath);
            var result = new List<LocationEntity>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim() == ";;")
                    continue;

                var parts = line.Split(';');

                if (parts.Length != 3 || string.IsNullOrWhiteSpace(parts[2]))
                {
                    Console.WriteLine($"⚠️ Neplatný řádek: '{line}'");
                    continue;
                }

                if (!int.TryParse(parts[2], NumberStyles.None, CultureInfo.InvariantCulture, out var psc))
                {
                    Console.WriteLine($"⚠️ Neplatné PSČ: '{parts[2]}' v řádku: '{line}'");
                    continue;
                }

                result.Add(new LocationEntity
                {
                    Name = parts[0],
                    PostOfficeType = parts[1],
                    Psc = psc
                });
            }

            return result;
        }

        private static async Task<List<KlicEntity>> LoadKlicsAsync()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Seed", "Klic.csv");
            var lines = await File.ReadAllLinesAsync(filePath);
            var result = new List<KlicEntity>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim() == ";;")
                    continue;

                var parts = line.Split(';');

                result.Add(new KlicEntity
                {
                    Name = parts[0],
                    IsActive = true,
                    CreatedAt = DateTime.Parse("01.01.2025"),
                    CreatedBy = "Režňák Roman"
                });
            }

            return result;
        }

        private static async Task<List<KurzyPEEntity>> LoadKurzyPEsAsync()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Seed", "Kurz.csv");
            var lines = await File.ReadAllLinesAsync(filePath);
            var result = new List<KurzyPEEntity>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim() == ";;")
                    continue;

                var parts = line.Split(';');

                result.Add(new KurzyPEEntity
                {
                    AP = parts[0],
                    NazevKurzu = parts[1],
                    TC = parts[2],
                    PSCzastavky = parts[3],
                    Zastavka = parts[4],
                    Prijezd = TimeSpan.Parse(parts[5]),
                    Odjezd = TimeSpan.Parse(parts[6]),
                    DatumZ = DateTime.Parse("01.05.2025"),
                    DatumU = DateTime.Parse("31.12.2050")
                });
            }

            return result;
        }

        private static async Task<List<ZastavkaEntity>> LoadZastavkasAsync()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Seed", "Zastavka.csv");
            var lines = await File.ReadAllLinesAsync(filePath);
            var result = new List<ZastavkaEntity>();

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.Trim() == ";;")
                    continue;

                var parts = line.Split(';');

                result.Add(new ZastavkaEntity
                {
                    Name = parts[0],
                    IsActive = true,
                    CreatedAt = DateTime.Parse("01.05.2025"),
                    CreatedBy = "Režňák Roman"
                });
            }

            return result;
        }
    }
}
