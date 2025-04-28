using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// Model pro technologickou skupinu (TechnologicalGroups).
    /// </summary>
    public class TechnologicalGroup
    {
        /// <summary>Primární klíč technologické skupiny.</summary>
        [Key]
        public string Value { get; set; } = string.Empty;
    }
}
