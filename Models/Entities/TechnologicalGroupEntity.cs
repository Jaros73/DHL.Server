using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Model pro technologickou skupinu (TechnologicalGroups).
    /// </summary>
    public class TechnologicalGroupEntity
    {
        /// <summary>Primární klíč technologické skupiny.</summary>
        [Key]
        public string Value { get; set; } = string.Empty;
    }
}
