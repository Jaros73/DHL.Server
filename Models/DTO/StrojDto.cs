namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro Stroj.
    /// </summary>
    public class StrojDto
    {
        /// <summary><summary>Identifikátor výkonu (FK na Machining).</summary></summary>
        public int StrojId { get; set; }

        /// <summary><summary>Identifikátor stroje.</summary></summary>
        public string StrojValue { get; set; } = string.Empty;

        /// <summary><summary>Hodnota výkonu stroje.</summary></summary>
        public string Value { get; set; } = string.Empty;

        /// <summary><summary>Poznámka k výkonu stroje.</summary></summary>
        public string? Poznamka { get; set; }

    }
}