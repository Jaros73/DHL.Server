namespace DHL.Server.Features.Ciselniky.Models
{
    /// <summary>
    /// DTO pro ZpozdeniKurzu.
    /// </summary>
    public class ZpozdeniKurzuDto
    {
        public int Id { get; set; }

        /// <summary><summary>Název důvodu zpoždění.</summary></summary>
        public string Duvod { get; set; } = string.Empty;

        /// <summary><summary>Stav aktivace záznamu.</summary></summary>
        public bool IsActive { get; set; }

        /// <summary><summary>Datum vytvoření záznamu.</summary></summary>
        public DateTime CreatedAt { get; set; }

        /// <summary><summary>Autor záznamu.</summary></summary>
        public string CreatedBy { get; set; } = string.Empty;

    }
}