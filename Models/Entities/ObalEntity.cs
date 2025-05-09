using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Model pro přepravní obal (Crates).
    /// </summary>
    public class ObalEntity
    {
        /// <summary>Primární klíč obalu.</summary>
        [Key]
        public string Value { get; set; } = string.Empty;
    }
}
