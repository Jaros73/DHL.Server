using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public int LocationId { get; set; }
        [ForeignKey(nameof(LocationId))]
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

        public ICollection<PrilohyEntity> Prilohy { get; set; } = new List<PrilohyEntity>();
    }
}