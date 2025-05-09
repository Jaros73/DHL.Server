namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro Zastavka.
    /// </summary>
    public class ZastavkaDto
    {
        /// <summary><summary>Primární klíč záznamu.</summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Název zastávky.</summary></summary>
        public string Name { get; set; } = string.Empty;

        /// <summary><summary>Stav zastávky (aktivní/neaktivní).</summary></summary>
        public bool IsActive { get; set; }

        /// <summary><summary>Datum vytvoření záznamu.</summary></summary>
        public DateTime CreatedAt { get; set; }

        /// <summary><summary>Autor vytvoření záznamu.</summary></summary>
        public string CreatedBy { get; set; } = string.Empty;

    }
}