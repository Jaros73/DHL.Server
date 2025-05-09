using DHL.Server.Models.Entities;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro Zbytek.
    /// </summary>
    public class ZbytekDto
    {
        /// <summary></summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Datum vzniku zbytku.</summary></summary>
        public DateTime Date { get; set; }

        /// <summary><summary>Popis zbytku.</summary></summary>
        public string Popis { get; set; } = string.Empty;

        /// <summary><summary>ID místa, kde vznikl zbytek.</summary></summary>
        public int LocationId { get; set; }
        public LocationEntity Location { get; set; } = default!;

        /// <summary><summary>Počet nebo hmotnost zbytku.</summary></summary>
        public double Pocet { get; set; }

    }
}