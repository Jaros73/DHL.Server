// File: Models/DTO/KurzyPEDto.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO model pro kurz PE.
    /// </summary>
    public class KurzyPEDto
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string TC { get; set; } = string.Empty;

        [MaxLength(6)]
        public string AP { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Zastavka { get; set; } = string.Empty;

        public TimeSpan Odjez { get; set; }

        public DateTime DatumZ { get; set; }

        public DateTime DatumU { get; set; }
    }
}
