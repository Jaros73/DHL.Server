using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Model pro typy operací (tabulka DispatchTypeEntity).
    /// </summary>
    public class DispatchTypeEntity
    {
        /// <summary>Primární klíč typu operace.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Název typu operace.</summary>
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
