using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// Model pro stroj (Machines).
    /// </summary>
    public class Machine
    {
        /// <summary>Primární klíč stroje.</summary>
        [Key]
        public string Value { get; set; } = string.Empty;
    }
}
