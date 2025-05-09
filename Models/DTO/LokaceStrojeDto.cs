namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro LokaceStroje.
    /// </summary>
    public class LokaceStrojeDto
    {
        /// <summary><summary>FK na lokaci.</summary></summary>
        public int LocationId { get; set; }

        /// <summary><summary>FK na stroj.</summary></summary>
        public string MachineValue { get; set; } = string.Empty;

    }
}