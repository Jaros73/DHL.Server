// File: Models/Entities/VehicleEntity.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita pro evidenci vozidla dle RZ (registrační značky).
    /// </summary>
    public class VozidloEntity
    {
        /// <summary>Primární klíč záznamu.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Registrační značka vozidla.</summary>
        [MaxLength(20)]
        [Required]
        public string RZ { get; set; } = string.Empty;

        /// <summary>Stav aktivace záznamu.</summary>
        public bool IsActive { get; set; }

        /// <summary>Datum založení.</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Uživatel, který záznam založil.</summary>
        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty;
    }
}
