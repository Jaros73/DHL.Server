using DHL.Server.Data;
using DHL.Server.Features.Ciselniky.Interfaces;
using DHL.Server.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Text;

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

            List<string> lines = new();

            // ✅ Bezpečné čtení přes StreamReader s UTF-8
            try
            {
                using var reader = new StreamReader(filePath, Encoding.UTF8);
                while (!reader.EndOfStream)
                {
                    var line = await reader.ReadLineAsync();
                    if (line != null)
                        lines.Add(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Chyba při čtení souboru: {ex.Message}");
                return 0;
            }

            Console.WriteLine($"📄 Načteno řádků: {lines.Count}");

            var result = new List<KurzyPEEntity>();

            foreach (var line in lines)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(line) || line.Trim() == ";;")
                        continue;

                    var parts = line.Split(';');
                    if (parts.Length < 9)
                    {
                        Console.WriteLine($"⚠️ Neplatný počet sloupců v řádku: '{line}'");
                        continue;
                    }

                    if (!TimeSpan.TryParse(parts[5], out var prijezd))
                    {
                        Console.WriteLine($"⚠️ Neplatný čas příjezdu v řádku: '{line}'");
                        continue;
                    }

                    if (!TimeSpan.TryParse(parts[6], out var odjezd))
                    {
                        Console.WriteLine($"⚠️ Neplatný čas odjezdu v řádku: '{line}'");
                        continue;
                    }

                    if (!DateTime.TryParse(parts[7], out var datumZ))
                    {
                        Console.WriteLine($"⚠️ Neplatné DatumZ v řádku: '{line}'");
                        continue;
                    }

                    if (!DateTime.TryParse(parts[8], out var datumU))
                    {
                        Console.WriteLine($"⚠️ Neplatné DatumU v řádku: '{line}'");
                        continue;
                    }

                    result.Add(new KurzyPEEntity
                    {
                        AP = parts[0].Trim(),
                        NazevKurzu = parts[1].Trim(),
                        TC = parts[2].Trim(),
                        PSCzastavky = parts[3].Trim(),
                        Zastavka = parts[4].Trim(),
                        Prijezd = prijezd,
                        Odjezd = odjezd,
                        DatumZ = datumZ,
                        DatumU = datumU
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"❌ Výjimka při zpracování řádku: {ex.Message}");
                }
            }

            if (result.Count == 0)
            {
                Console.WriteLine("⚠️ Žádný validní záznam nebyl nalezen.");
                return 0;
            }

            try
            {
                await _context.KurzyPEs.AddRangeAsync(result);
                var count = await _context.SaveChangesAsync();
                Console.WriteLine($"✅ Importováno záznamů: {count}");
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Chyba při ukládání do databáze: {ex.Message}");
                return 0;
            }
        }
    }
}
