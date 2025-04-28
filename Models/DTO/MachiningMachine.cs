using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// Model pro použitý stroj v rámci výkonu mechanizace (MachiningMachines).
    /// </summary>
    public class MachiningMachine
    {
        /// <summary>Identifikátor výkonu (FK na Machining).</summary>
        [Required]
        public int MachiningId { get; set; }

        /// <summary>Identifikátor stroje.</summary>
        [Required]
        public string MachineValue { get; set; } = string.Empty;

        /// <summary>Hodnota výkonu stroje.</summary>
        public string Value { get; set; } = string.Empty;

        /// <summary>Poznámka k výkonu stroje.</summary>
        public string? Note { get; set; }
    }
}
