using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models
{
    /// <summary>
    /// Model pro ukládání dispečerských záznamů.
    /// </summary>
    public class DispatchModel
    {
        /// <summary>
        /// Primární klíč záznamu.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Datum a čas vytvoření.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Uživatel, který vytvořil záznam.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string CreatedBy { get; set; } = "System";

        /// <summary>
        /// Celé jméno uživatele, který vytvořil záznam.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string CreatedByFullName { get; set; } = "Neznámý uživatel";

        /// <summary>
        /// Identifikátor lokace (např. dispečerského střediska).
        /// </summary>
        [Required]
        public int LocationId { get; set; } = 1; 

        /// <summary>
        /// Název lokace (např. název dispečerského střediska).
        /// </summary>
        [Required]
        [StringLength(255)]
        public string LocationName { get; set; } = "Neznámá lokalita";

        /// <summary>
        /// Datum a čas uživatelské operace.
        /// </summary>
        [Required]
        public DateTime UserTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// ID typu operace (např. dispečerský typ).
        /// </summary>
        [Required]
        public int TypeEnumId { get; set; } = 1; 

        /// <summary>
        /// Název typu operace.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string TypeEnumName { get; set; } = "Neznámý typ";

        /// <summary>
        /// ID klíče operace (např. dispečerský klíč).
        /// </summary>
        [Required]
        public int KeyEnumId { get; set; } = 1; 

        /// <summary>
        /// Název klíče operace.
        /// </summary>
        [Required]
        [StringLength(255)]
        public string KeyEnumName { get; set; } = "Neznámý klíč";

        /// <summary>
        /// Popis operace.
        /// </summary>
        [StringLength(1000)]
        public string? Description { get; set; } = "-";

        /// <summary>
        /// Datum a čas poslední aktualizace.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
