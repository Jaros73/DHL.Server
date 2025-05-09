namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro VykonStroj.
    /// </summary>
    public class VykonStrojDto
    {
        /// <summary></summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Typ zařízení nebo činnosti.</summary></summary>
        public string MachineType { get; set; } = string.Empty;

        /// <summary><summary>Začátek výkonu.</summary></summary>
        public DateTime StartTime { get; set; }

        /// <summary><summary>Konec výkonu.</summary></summary>
        public DateTime EndTime { get; set; }

        /// <summary><summary>Popis provedené činnosti.</summary></summary>
        public string? Description { get; set; }

    }
}