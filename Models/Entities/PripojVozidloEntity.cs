// File: Models/Entities/TrailerEntity.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita pro přípojné vozidlo (např. přívěs, návěs).
    /// </summary>
    public class PripojVozidloEntity
    {
        /// <summary>Primární klíč záznamu.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Registrační značka přívěsu.</summary>
        [MaxLength(20)]
        [Required]
        public string RZ { get; set; } = string.Empty;

        /// <summary>Stav (aktivní/neaktivní).</summary>
        public bool IsActive { get; set; }

        /// <summary>Datum založení.</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Autor založení.</summary>
        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty;
    }
}
