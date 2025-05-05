// File: Models/DTO/CourseDto.cs
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO model pro přepravní kurz.
    /// </summary>
    public class CourseDto
    {
        /// <summary>Primární klíč kurzu.</summary>
        public int Id { get; set; }

        /// <summary>Kód kurzu.</summary>
        [Required]
        public string Code { get; set; } = string.Empty;

        /// <summary>Datum kurzu.</summary>
        public DateTime Date { get; set; }

        /// <summary>Směr.</summary>
        public string Direction { get; set; } = string.Empty;

        /// <summary>Odkud.</summary>
        public string FromLocationId { get; set; } = string.Empty;

        /// <summary>Kam.</summary>
        public string ToLocationId { get; set; } = string.Empty;

        /// <summary>Řidič.</summary>
        public string? Driver { get; set; }

        /// <summary>SPZ vozidla.</summary>
        public string? VehiclePlate { get; set; }
    }
}
