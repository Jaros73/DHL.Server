// File: Models/Entities/KurzyPEEntity.cs
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita pro záznam plánovaných kurzů PE.
    /// </summary>
    public class KurzyPEEntity
    {
        /// <summary>Primární klíč záznamu.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Kód trasy (TC).</summary>
        [MaxLength(255)]
        public string TC { get; set; } = string.Empty;

        /// <summary>Číslo výpravního místa (AP).</summary>
        [MaxLength(6)]
        public string AP { get; set; } = string.Empty;

        /// <summary>Název zastávky.</summary>
        [MaxLength(255)]
        public string Zastavka { get; set; } = string.Empty;

        /// <summary>Čas odjezdu (hh:mm).</summary>
        public TimeSpan Odjez { get; set; }

        /// <summary>Datum vytvoření.</summary>
        public DateTime DatumZ { get; set; }

        /// <summary>Datum aktualizace.</summary>
        public DateTime DatumU { get; set; }
    }
}
