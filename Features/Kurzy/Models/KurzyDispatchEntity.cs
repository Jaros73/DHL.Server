using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DHL.Server.Features.Kurzy.Models
{
    /// <summary>
    /// Entita reprezentující kurz dispečerské služby.
    /// Slouží k evidenci kurzů v systému DHL.
    /// </summary>
    [Table("KurzyDispatch")]
    public class KurzyDispatchEntity
    {
        /// <summary>
        /// Primární klíč – ID kurzu.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Datum a čas vytvoření záznamu.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Datum a čas poslední aktualizace záznamu.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// ID lokace (DSPU), odkud kurz vyjíždí.
        /// </summary>
        public int LocationId { get; set; }

        /// <summary>
        /// Název lokace (DSPU).
        /// </summary>
        [MaxLength(100)]
        public string LocationName { get; set; } = string.Empty;

        /// <summary>
        /// Typ dopravní sítě (např. CN, B, D+1).
        /// </summary>
        [MaxLength(20)]
        public string Sit { get; set; } = string.Empty;

        /// <summary>
        /// Kód kurzu (např. P01-100).
        /// </summary>
        [MaxLength(6)]
        public string CisloKurzu { get; set; } = string.Empty;

        /// <summary>
        /// Datum odjezdu kurzu.
        /// </summary>
        public DateTime DatumOdjezdu { get; set; }

        /// <summary>
        /// Plánovaný čas odjezdu.
        /// </summary>
        public TimeSpan? PlanovanyCasOdjezdu { get; set; }

        /// <summary>
        /// Rozdíl (v minutách) oproti plánovanému odjezdu.
        /// </summary>
        public int? RozdilCasuOdjezdu { get; set; }

        /// <summary>
        /// Plánovaný čas příjezdu.
        /// </summary>
        public TimeSpan? PlanovanyCasPrijezdu { get; set; }

        /// <summary>
        /// Rozdíl (v minutách) oproti plánovanému příjezdu.
        /// </summary>
        public int? RozdilCasuPrijezdu { get; set; }
    }
}
