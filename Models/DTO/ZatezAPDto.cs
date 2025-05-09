namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro ZatezAP.
    /// </summary>
    public class ZatezAPDto
    {
        /// <summary><summary>Primární klíč záznamu.</summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Kód trasy (TC).</summary></summary>
        public string TC { get; set; } = string.Empty;

        /// <summary><summary>Výpravní místo (AP).</summary></summary>
        public string AP { get; set; } = string.Empty;

        /// <summary><summary>Unikátní kód zásilky (UK).</summary></summary>
        public string UK { get; set; } = string.Empty;

        /// <summary><summary>Počet kusů.</summary></summary>
        public int PocetKS { get; set; }

        /// <summary><summary>Datum aktualizace.</summary></summary>
        public DateTime DatumU { get; set; }

    }
}