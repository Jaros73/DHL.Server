using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    public class RegionalReportDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
    ...
    public List<AttachmentDto> Attachments { get; set; } = new();
    }
}

