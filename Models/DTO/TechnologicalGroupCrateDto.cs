namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro TechnologicalGroupCrate.
    /// </summary>
    public class TechnologicalGroupCrateDto
    {
        /// <summary><summary>FK na technologickou skupinu.</summary></summary>
        public string TechnologicalGroupValue { get; set; } = string.Empty;

        /// <summary><summary>FK na obal (crate).</summary></summary>
        public string CrateValue { get; set; } = string.Empty;

    }
}