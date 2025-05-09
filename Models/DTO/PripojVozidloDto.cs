namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro PripojVozidlo.
    /// </summary>
    public class PripojVozidloDto
    {
        /// <summary><summary>Primární klíč záznamu.</summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Registrační značka přívěsu.</summary></summary>
        public string RZ { get; set; } = string.Empty;

        /// <summary><summary>Stav (aktivní/neaktivní).</summary></summary>
        public bool IsActive { get; set; }

        /// <summary><summary>Datum založení.</summary></summary>
        public DateTime CreatedAt { get; set; }

        /// <summary><summary>Autor založení.</summary></summary>
        public string CreatedBy { get; set; } = string.Empty;

    }
}