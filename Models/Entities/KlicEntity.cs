// File: Models/Entities/KlicEntity.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita pro klíč  technologické skupiy.
    /// </summary>
    public class KlicEntity
    {
        /// <summary>Primární klíč záznamu.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Klíč.</summary>

        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>Stav aktivace záznamu.</summary>
        public bool IsActive { get; set; }

        /// <summary>Datum založení.</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Uživatel, který záznam založil.</summary>
        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>Datum změny.</summary>
        public DateTime Updated { get; set; }
    }
}
