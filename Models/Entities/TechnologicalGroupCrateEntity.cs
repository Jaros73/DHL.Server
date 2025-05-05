using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Spojovací model mezi technologickou skupinou a obalem (TechnologicalGroupCrates).
    /// </summary>
    public class TechnologicalGroupCrateEntity
    {
        /// <summary>FK na technologickou skupinu.</summary>
        [Required]
        public string TechnologicalGroupValue { get; set; } = string.Empty;

        /// <summary>FK na obal (crate).</summary>
        [Required]
        public string CrateValue { get; set; } = string.Empty;
    }
}
