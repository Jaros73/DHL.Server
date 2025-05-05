using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    public class RegionalReportEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
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

        public ICollection<AttachmentEntity> Attachments { get; set; } = new List<AttachmentEntity>();
    }
}