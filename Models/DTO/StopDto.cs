// File: Models/DTO/StopDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro zastávku.
    /// </summary>
    public class StopDto
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty;
    }
}
