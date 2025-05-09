// File: Models/Dto/KurzyPEDto.cs
using System;

namespace DHL.Server.Features.Ciselniky.Models
{
    /// <summary>
    /// DTO pro záznam plánovaných kurzů PE.
    /// </summary>
    public class KurzyPEDto
    {
        public int Id { get; set; }

        public string AP { get; set; } = string.Empty;

        public string NazevKurzu { get; set; } = string.Empty;

        public string TC { get; set; } = string.Empty;

        public string PSCzastavky { get; set; } = string.Empty;

        public string Zastavka { get; set; } = string.Empty;

        public TimeSpan Prijezd { get; set; }

        public TimeSpan Odjezd { get; set; }

        public DateTime DatumZ { get; set; }

        public DateTime DatumU { get; set; }
    }
}
