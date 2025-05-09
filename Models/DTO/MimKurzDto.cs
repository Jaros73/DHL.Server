namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro MimKurz.
    /// </summary>
    public class MimKurzDto
    {
        /// <summary><summary>Primární klíč.</summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Kód kurzu.</summary></summary>
        public string Code { get; set; } = string.Empty;

        /// <summary><summary>Datum a čas odjezdu.</summary></summary>
        public DateTime OdjezdTime { get; set; }

        /// <summary><summary>Řidič.</summary></summary>
        public string? Ridic { get; set; }

        /// <summary><summary>SPZ vozidla.</summary></summary>
        public string? RZ { get; set; }

        /// <summary><summary>Důvod mimořádnosti.</summary></summary>
        public string? Duvod { get; set; }

    }
}