// File: Models/Entities/StopEntity.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita pro zastávku (např. Brno, Praha).
    /// </summary>
    public class StopEntity
    {
        /// <summary>Primární klíč záznamu.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Název zastávky.</summary>
        [MaxLength(255)]
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>Stav zastávky (aktivní/neaktivní).</summary>
        public bool IsActive { get; set; }

        /// <summary>Datum vytvoření záznamu.</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Autor vytvoření záznamu.</summary>
        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty;
    }
}
