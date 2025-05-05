// File: Models/Entities/ZatezAPEntity.cs
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita pro záznam zatížení na výpravném místě (AP).
    /// </summary>
    public class ZatezAPEntity
    {
        /// <summary>Primární klíč záznamu.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Kód trasy (TC).</summary>
        [MaxLength(255)]
        public string TC { get; set; } = string.Empty;

        /// <summary>Výpravní místo (AP).</summary>
        [MaxLength(6)]
        public string AP { get; set; } = string.Empty;

        /// <summary>Unikátní kód zásilky (UK).</summary>
        [MaxLength(13)]
        public string UK { get; set; } = string.Empty;

        /// <summary>Počet kusů.</summary>
        public int PocetKS { get; set; }

        /// <summary>Datum aktualizace.</summary>
        public DateTime DatumU { get; set; }
    }
}
