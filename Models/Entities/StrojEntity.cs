using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Model pro použitý stroj v rámci výkonu mechanizace (MachiningMachines).
    /// </summary>
    public class StrojEntity
    {
        /// <summary>Identifikátor výkonu (FK na Machining).</summary>
        [Required]
        public int StrojId { get; set; }

        /// <summary>Identifikátor stroje.</summary>
        [Required]
        public string StrojValue { get; set; } = string.Empty;

        /// <summary>Hodnota výkonu stroje.</summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>Poznámka k výkonu stroje.</summary>
        public string? Poznamka { get; set; }
    }
}
