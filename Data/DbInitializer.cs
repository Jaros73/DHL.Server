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
            // Zajistí, že je databáze fyzicky vytvořena
            await context.Database.EnsureCreatedAsync();

            // Lokace
            if (!await context.Locations.AnyAsync())
            {
                var locations = await LoadLocationsAsync();
                await context.Locations.AddRangeAsync(locations);
                await context.SaveChangesAsync();
            }

            // Typy operací
            if (!await context.DispatchTypes.AnyAsync())
            {
                var types = await LoadDispatchTypesAsync();
                await context.DispatchTypes.AddRangeAsync(types);
                await context.SaveChangesAsync();
            }

            // Klíče operací
            if (!await context.DispatchKeys.AnyAsync())
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
            return lines.Skip(1) // Přeskočí hlavičku
                .Select(line => line.Split(','))
                .Select(parts => new LocationEntity
                {
                    Id = int.Parse(parts[0], CultureInfo.InvariantCulture),
                    Name = parts[1]
                })
                .ToList();
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
