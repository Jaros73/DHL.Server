using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro Obal.
    /// </summary>
    public class ObalDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Identifier { get; set; } = string.Empty;

        [Required]
        public int Quantity { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        [StringLength(50)]
        public string SourceType { get; set; } = string.Empty;

        [Required]
        public int SourceId { get; set; }
    }
}