using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DHL.Server.Features.Kurzy.Models;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Entita reprezentující přílohu nahranou ke konkrétnímu kurzu.
    /// Uchovává pouze metadata souboru, samotný obsah je uložen na disku.
    /// </summary>
    [Table("KurzyDispatchPrilohy")]
    public class KurzyDispatchPrilohyEntity
    {
        /// <summary>
        /// Primární klíč – ID přílohy.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Název souboru zobrazený uživateli (původní).
        /// </summary>
        [MaxLength(255)]
        public string FileName { get; set; } = string.Empty;

        /// <summary>
        /// Relativní cesta k uloženému souboru (např. uploads/kurzy/1234/file.pdf).
        /// </summary>
        [MaxLength(500)]
        public string StoredPath { get; set; } = string.Empty;

        /// <summary>
        /// MIME typ souboru (např. application/pdf).
        /// </summary>
        [MaxLength(100)]
        public string ContentType { get; set; } = string.Empty;

        /// <summary>
        /// Velikost souboru v bajtech.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// Datum a čas nahrání souboru.
        /// </summary>
        public DateTime UploadedAt { get; set; }

        /// <summary>
        /// Cizí klíč – ID kurzu, ke kterému příloha náleží.
        /// </summary>
        public int KurzyDispatchId { get; set; }

        /// <summary>
        /// Navigační vlastnost na kurz.
        /// </summary>
        [ForeignKey("KurzyDispatchId")]
        public KurzyDispatchEntity? Kurz { get; set; }
    }
}
