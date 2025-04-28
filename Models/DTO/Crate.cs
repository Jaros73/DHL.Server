using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// Model pro přepravní obal (Crates).
    /// </summary>
    public class Crate
    {
        /// <summary>Primární klíč obalu.</summary>
        [Key]
        public string Value { get; set; } = string.Empty;
    }
}
