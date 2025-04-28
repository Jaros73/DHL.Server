using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Model pro klíče operací (tabulka DispatchKeyEntity).
    /// </summary>
    public class DispatchKeyEntity
    {
        /// <summary>Primární klíč klíče operace.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Název klíče operace.</summary>
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
