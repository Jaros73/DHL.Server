// File: Models/Entities/RemainderEntity.cs
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita pro evidenci zbytků zásilek nebo manipulací.
    /// </summary>
    public class RemainderEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>Datum vzniku zbytku.</summary>
        public DateTime Date { get; set; }

        /// <summary>Popis zbytku.</summary>
        [Required]
        public string Description { get; set; } = string.Empty;

        /// <summary>ID místa, kde vznikl zbytek.</summary>
        public string LocationId { get; set; } = string.Empty;

        /// <summary>Počet nebo hmotnost zbytku.</summary>
        public double Quantity { get; set; }
    }
}
