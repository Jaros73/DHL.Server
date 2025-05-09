// File: Models/Entities/MachiningEntity.cs
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita pro výkon mechanizace (např. vozíky, třídicí linky).
    /// </summary>
    public class VykonStrojEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>Typ zařízení nebo činnosti.</summary>
        [Required]
        public string MachineType { get; set; } = string.Empty;

        /// <summary>Začátek výkonu.</summary>
        public DateTime StartTime { get; set; }

        /// <summary>Konec výkonu.</summary>
        public DateTime EndTime { get; set; }

        /// <summary>Popis provedené činnosti.</summary>
        public string? Description { get; set; }
    }
}
