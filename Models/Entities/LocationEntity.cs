using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Model pro lokace (tabulka LocationEntity).
    /// </summary>
    public class LocationEntity
    {
        /// <summary>Identifikátor lokace.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Název lokace.</summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>Typ poštovní pobočky.</summary>
        [Required]
        public string PostOfficeType { get; set; } = string.Empty;

        /// <summary>Poštovní směrovací číslo (PSČ).</summary>
        public int Psc { get; set; }
    }
}
