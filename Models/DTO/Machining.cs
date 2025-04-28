using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// Model pro záznam výkonu mechanizace (Machinings).
    /// </summary>
    public class Machining
    {
        /// <summary>Primární klíč výkonu.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Datum, ke kterému se výkon vztahuje.</summary>
        [Required]
        public DateTime DateFor { get; set; } = DateTime.UtcNow;

        /// <summary>Identifikátor lokace výkonu.</summary>
        [Required]
        public int LocationId { get; set; }

        /// <summary>Uživatel, který záznam vytvořil.</summary>
        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>Uživatel, který záznam aktualizoval.</summary>
        public string? UpdatedBy { get; set; }
    }
}
