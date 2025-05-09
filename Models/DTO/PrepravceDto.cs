namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro Prepravce.
    /// </summary>
    public class PrepravceDto
    {
        /// <summary><summary>Primární klíč záznamu.</summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Název přepravce.</summary></summary>
        public string Name { get; set; } = string.Empty;

        /// <summary><summary>Stav (aktivní/neaktivní).</summary></summary>
        public bool IsActive { get; set; }

        /// <summary><summary>Datum založení.</summary></summary>
        public DateTime CreatedAt { get; set; }

        /// <summary><summary>Uživatel, který přepravce založil.</summary></summary>
        public string CreatedBy { get; set; } = string.Empty;

    }
}