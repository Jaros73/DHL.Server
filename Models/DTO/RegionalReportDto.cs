using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    public class RegionalReportDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime? UpdatedAt { get; set; }
        public string? UpdatedBy { get; set; }

        public DateTime DateFor { get; set; }
        public string Category { get; set; } = string.Empty;
        public string Network { get; set; } = string.Empty;

        public string LocationId { get; set; } = string.Empty;
        public string LocationZip { get; set; } = string.Empty;
        public string? LocationName { get; set; }

        public string? Description { get; set; }
        public string? ActionTaken { get; set; }

        public string? CourseCode { get; set; }
        public DateTime? CoursePlannedArrival { get; set; }
        public DateTime? CourseRealArrival { get; set; }
        public string? CourseDelayEnumId { get; set; }
        public string? CourseDelayName { get; set; }

        public string? Note { get; set; }
        public string? CreatedByFullName { get; set; }
        public string? UpdatedByFullName { get; set; }

        public List<AttachmentDto> Attachments { get; set; } = new();
    }

}

