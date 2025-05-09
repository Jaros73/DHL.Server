namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro Prilohy.
    /// </summary>
    public class PrilohyDto
    {
        public int Id { get; set; }

        public string Filename { get; set; } = string.Empty;

        public string DisplayName { get; set; } = string.Empty;

        public int RegionalReportId { get; set; }

        public ICollection<PrilohyDto> Prilohy { get; set; } = new List<PrilohyDto>();

    }
}