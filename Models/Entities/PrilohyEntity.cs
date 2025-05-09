using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    public class PrilohyEntity
    {
        public int Id { get; set; }
        public string Filename { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;

        public int RegionalReportId { get; set; }
        public RegionalReportEntity RegionalReport { get; set; } = null!;
    }
}