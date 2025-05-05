// File: Models/Entities/TransporterEntity.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita pro přepravce (např. C.S.Cargo, Česká Pošta).
    /// </summary>
    public class TransporterEntity
    {
        /// <summary>Primární klíč záznamu.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Název přepravce.</summary>
        [MaxLength(255)]
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>Stav (aktivní/neaktivní).</summary>
        public bool IsActive { get; set; }

        /// <summary>Datum založení.</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Uživatel, který přepravce založil.</summary>
        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty;
    }
}
