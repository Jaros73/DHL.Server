namespace DHL.Server.Features.Kurzy.Models
{
    /// <summary>
    /// Datový přenosový objekt pro kurz dispečerské služby.
    /// </summary>

        public class KurzyDispatchDto
        {
            public int Id { get; set; }

            public DateTime CreatedAt { get; set; }

            public DateTime? UpdatedAt { get; set; }

            public int LocationId { get; set; }

            public string LocationName { get; set; } = string.Empty;

            public string Sit { get; set; } = string.Empty;

            public string CisloKurzu { get; set; } = string.Empty;

            public DateTime DatumOdjezdu { get; set; }

            public TimeSpan? PlanovanyCasOdjezdu { get; set; }

            public int? RozdilCasuOdjezdu { get; set; }

            public TimeSpan? PlanovanyCasPrijezdu { get; set; }

            public int? RozdilCasuPrijezdu { get; set; }
        }
    }
