using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Model pro stroj (Machines).
    /// </summary>
    public class VykonStrojeEntity
    {
        /// <summary>Primární klíč stroje.</summary>
        [Key]
        public string Value { get; set; } = string.Empty;
    }
}
