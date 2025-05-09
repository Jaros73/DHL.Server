namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro Kurz.
    /// </summary>
    public class KurzDto
    {
        /// <summary><summary>Primární klíč kurzu.</summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Kód kurzu (např. RO1234).</summary></summary>
        public string Code { get; set; } = string.Empty;

        /// <summary><summary>Datum kurzu.</summary></summary>
        public DateTime Date { get; set; }

        /// <summary><summary>Směr (např. rozvoz, svoz).</summary></summary>
        public string Direction { get; set; } = string.Empty;

        /// <summary><summary>ID lokace odkud kurz vyjíždí.</summary></summary>
        public string OdjezdZ { get; set; } = string.Empty;

        /// <summary><summary>ID lokace kam kurz směřuje.</summary></summary>
        public string SmerKurzu { get; set; } = string.Empty;

        /// <summary><summary>Řidič odpovědný za kurz.</summary></summary>
        public string? Ridic { get; set; }

        /// <summary><summary>SPZ vozidla.</summary></summary>
        public string? RZ { get; set; }

    }
}