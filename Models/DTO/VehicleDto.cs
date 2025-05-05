// File: Models/DTO/VehicleDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro evidenci vozidla.
    /// </summary>
    public class VehicleDto
    {
        public int Id { get; set; }

        [MaxLength(20)]
        public string PlateNumber { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        [MaxLength(100)]
        public string CreatedBy { get; set; } = string.Empty;
    }
}
