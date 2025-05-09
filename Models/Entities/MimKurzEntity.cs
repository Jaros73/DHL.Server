// File: Models/Entities/IrregularCourseEntity.cs
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita představující mimořádný kurz (např. ad-hoc svoz/rozvoz).
    /// </summary>
    public class MimKurzEntity
    {
        /// <summary>Primární klíč.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Kód kurzu.</summary>
        [Required]
        public string Code { get; set; } = string.Empty;

        /// <summary>Datum a čas odjezdu.</summary>
        public DateTime OdjezdTime { get; set; }

        /// <summary>Řidič.</summary>
        public string? Ridic { get; set; }

        /// <summary>SPZ vozidla.</summary>
        public string? RZ { get; set; }

        /// <summary>Důvod mimořádnosti.</summary>
        public string? Duvod { get; set; }
    }
}
