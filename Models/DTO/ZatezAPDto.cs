// File: Models/DTO/ZatezAPDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO model pro zatížení na AP.
    /// </summary>
    public class ZatezAPDto
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string TC { get; set; } = string.Empty;

        [MaxLength(6)]
        public string AP { get; set; } = string.Empty;

        [MaxLength(13)]
        public string UK { get; set; } = string.Empty;

        public int PocetKS { get; set; }

        public DateTime DatumU { get; set; }
    }
}
