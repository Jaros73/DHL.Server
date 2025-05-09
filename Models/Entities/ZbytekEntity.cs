// File: Models/Entities/RemainderEntity.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita pro evidenci zbytků zásilek nebo manipulací.
    /// </summary>
    public class ZbytekEntity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>Datum vzniku zbytku.</summary>
        public DateTime Date { get; set; }

        /// <summary>Popis zbytku.</summary>
        [Required]
        public string Popis { get; set; } = string.Empty;

        /// <summary>ID místa, kde vznikl zbytek.</summary>
        public int LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
        public LocationEntity Location { get; set; } = default!;


        /// <summary>Počet nebo hmotnost zbytku.</summary>
        public double Pocet { get; set; }
    }
}
