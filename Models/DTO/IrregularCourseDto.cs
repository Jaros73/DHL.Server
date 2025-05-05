// File: Models/DTO/IrregularCourseDto.cs
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO model pro mimořádný kurz.
    /// </summary>
    public class IrregularCourseDto
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;

        public DateTime DepartureTime { get; set; }

        public string? Driver { get; set; }

        public string? VehiclePlate { get; set; }

        public string? Reason { get; set; }
    }
}
