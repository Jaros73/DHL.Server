// File: Models/Entities/CourseEntity.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita představující přepravní kurz.
    /// </summary>
    public class KurzEntity
    {
        /// <summary>Primární klíč kurzu.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Kód kurzu (např. RO1234).</summary>
        [Required]
        public string Code { get; set; } = string.Empty;

        /// <summary>Datum kurzu.</summary>
        public DateTime Date { get; set; }

        /// <summary>Směr (např. rozvoz, svoz).</summary>
        public string Direction { get; set; } = string.Empty;

        /// <summary>ID lokace odkud kurz vyjíždí.</summary>
        public string OdjezdZ { get; set; } = string.Empty;

        /// <summary>ID lokace kam kurz směřuje.</summary>
        public string SmerKurzu { get; set; } = string.Empty;

        /// <summary>Řidič odpovědný za kurz.</summary>
        public string? Ridic { get; set; }

        /// <summary>SPZ vozidla.</summary>
        public string? RZ { get; set; }
    }
}
