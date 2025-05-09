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

        /// <summary>Číslo kurzu (AP).</summary>
        [MaxLength(6)]
        public string AP { get; set; } = string.Empty;

        /// <summary>Název kurzu.</summary>
        [MaxLength(255)]
        public string NazevKurzu { get; set; } = string.Empty;

        /// <summary>(TC).</summary>
        [MaxLength(255)]
        public string TC { get; set; } = string.Empty;

        /// <summary>PSČ zastávky.</summary>
        [MaxLength(5)]
        public string PSCzastavky { get; set; } = string.Empty;

        /// <summary>Název zastávky.</summary>
        [MaxLength(255)]
        public string Zastavka { get; set; } = string.Empty;

        /// <summary>Čas příjezdu (hh:mm).</summary>
        public TimeSpan Prijezd { get; set; }

        /// <summary>Čas odjezdu (hh:mm).</summary>
        public TimeSpan Odjezd { get; set; }

        /// <summary>Datum vytvoření.</summary>
        public DateTime DatumZ { get; set; }

        /// <summary>Datum ukončení.</summary>
        public DateTime DatumU { get; set; }
    }
}
