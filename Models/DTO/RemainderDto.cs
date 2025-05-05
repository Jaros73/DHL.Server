// File: Models/DTO/RemainderDto.cs
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO model pro zbytek.
    /// </summary>
    public class RemainderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;

        public string LocationId { get; set; } = string.Empty;

        public double Quantity { get; set; }
    }
}
