using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Model pro přepravní obal (Crates).
    /// </summary>

    public class ObalEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Identifier { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; } = 0;

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [StringLength(50)]
        public string SourceType { get; set; } = string.Empty;

        [Required]
        public int SourceId { get; set; }
    }
}
