// File: Models/DTO/MachiningDto.cs
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO model pro výkon mechanizace.
    /// </summary>
    public class MachiningDto
    {
        public int Id { get; set; }

        [Required]
        public string MachineType { get; set; } = string.Empty;

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string? Description { get; set; }
    }
}
