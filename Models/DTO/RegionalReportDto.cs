using DHL.Server.Models.Entities;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro RegionalReport.
    /// </summary>
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

        public int LocationId { get; set; }
        public LocationEntity Location { get; set; } = default!;
        public string LocationZip { get; set; } = string.Empty;

        public string? LocationName { get; set; }

        public string? Popis { get; set; }

        public string? Opatreni { get; set; }

        public string? KurzCode { get; set; }

        public DateTime? KurzPlanovanyPrijezd { get; set; }

        public DateTime? KurzSkutecnyPrijezd { get; set; }

        public string? KurzZpozdeniEnumId { get; set; }

        public string? KurzZpozdeniName { get; set; }

        public string? Poznamka { get; set; }

        public string? CreatedByFullName { get; set; }

        public string? UpdatedByFullName { get; set; }

    }
}