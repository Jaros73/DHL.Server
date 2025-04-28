using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Model pro dispečerské záznamy (tabulka Dispatches).
    /// </summary>
    public class DispatchModelEntity
    {
        /// <summary>Primární klíč záznamu.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Datum a čas vytvoření záznamu.</summary>
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>Identifikátor uživatele, který vytvořil záznam.</summary>
        [Required]
        [StringLength(255)]
        public string CreatedBy { get; set; } = "System";

        /// <summary>Jméno uživatele, který vytvořil záznam.</summary>
        [Required]
        [StringLength(255)]
        public string CreatedByFullName { get; set; } = "Neznámý uživatel";

        /// <summary>Identifikátor lokace.</summary>
        [Required]
        public int LocationId { get; set; }

        /// <summary>Název lokace.</summary>
        [Required]
        [StringLength(255)]
        public string LocationName { get; set; } = "Neznámá lokalita";

        /// <summary>Datum a čas operace provedené uživatelem.</summary>
        [Required]
        public DateTime UserTime { get; set; } = DateTime.UtcNow;

        /// <summary>Typ operace (typ ENUM).</summary>
        [Required]
        public int TypeEnumId { get; set; }

        /// <summary>Název typu operace.</summary>
        [Required]
        [StringLength(255)]
        public string TypeEnumName { get; set; } = "Neznámý typ";

        /// <summary>Klíč operace (klíč ENUM).</summary>
        [Required]
        public int KeyEnumId { get; set; }

        /// <summary>Název klíče operace.</summary>
        [Required]
        [StringLength(255)]
        public string KeyEnumName { get; set; } = "Neznámý klíč";

        /// <summary>Popis operace (volitelné).</summary>
        [StringLength(1000)]
        public string? Description { get; set; } = "-";

        /// <summary>Datum a čas poslední aktualizace.</summary>
        public DateTime? UpdatedAt { get; set; }
    }
}
