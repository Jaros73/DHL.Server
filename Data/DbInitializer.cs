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

            if (!await context.DispatchTypes.AnyAsync() && File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Seed", "dispatchtypes.csv")))
            {
                var types = await LoadDispatchTypesAsync();
                await context.DispatchTypes.AddRangeAsync(types);
                await context.SaveChangesAsync();
            }

            if (!await context.DispatchKeys.AnyAsync() && File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Seed", "dispatchkeys.csv")))
            {
                var keys = await LoadDispatchKeysAsync();
                await context.DispatchKeys.AddRangeAsync(keys);
                await context.SaveChangesAsync();
            }
        }


        private static async Task<List<LocationEntity>> LoadLocationsAsync()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Seed", "locations.csv");
            var lines = await File.ReadAllLinesAsync(filePath);

            var result = new List<LocationEntity>();

            foreach (var line in lines)
            {
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

        private static async Task<List<DispatchTypeEntity>> LoadDispatchTypesAsync()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Seed", "dispatchtypes.csv");
            var lines = await File.ReadAllLinesAsync(filePath);
            return lines.Skip(1)
                .Select(line => line.Split(','))
                .Select(parts => new DispatchTypeEntity
                {
                    Id = int.Parse(parts[0], CultureInfo.InvariantCulture),
                    Name = parts[1]
                })
                .ToList();
        }

        private static async Task<List<DispatchKeyEntity>> LoadDispatchKeysAsync()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Seed", "dispatchkeys.csv");
            var lines = await File.ReadAllLinesAsync(filePath);
            return lines.Skip(1)
                .Select(line => line.Split(','))
                .Select(parts => new DispatchKeyEntity
                {
                    Id = int.Parse(parts[0], CultureInfo.InvariantCulture),
                    Name = parts[1]
                })
                .ToList();
        }
    }
}
