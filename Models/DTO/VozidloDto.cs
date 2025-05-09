namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro Vozidlo.
    /// </summary>
    public class VozidloDto
    {
        /// <summary><summary>Primární klíč záznamu.</summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Registrační značka vozidla.</summary></summary>
        public string RZ { get; set; } = string.Empty;

        /// <summary><summary>Stav aktivace záznamu.</summary></summary>
        public bool IsActive { get; set; }

        /// <summary><summary>Datum založení.</summary></summary>
        public DateTime CreatedAt { get; set; }

        /// <summary><summary>Uživatel, který záznam založil.</summary></summary>
        public string CreatedBy { get; set; } = string.Empty;

    }
}