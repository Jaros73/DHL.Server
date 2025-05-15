namespace DHL.Server.Features.Dispatching.Models
{
    /// <summary>
    /// DTO pro DispatchModel.
    /// </summary>
    public class DispatchModelDto
    {
        /// <summary><summary>Primární klíč záznamu.</summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Datum a čas vytvoření záznamu.</summary></summary>
        public DateTime CreatedAt { get; set; }

        /// <summary><summary>Identifikátor uživatele, který vytvořil záznam.</summary></summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary><summary>Jméno uživatele, který vytvořil záznam.</summary></summary>
        public string CreatedByFullName { get; set; } = string.Empty;

        /// <summary><summary>Identifikátor lokace.</summary></summary>
        public int LocationId { get; set; }

        /// <summary><summary>Název lokace.</summary></summary>
        public string LocationName { get; set; } = string.Empty;

        /// <summary><summary>Datum a čas operace provedené uživatelem.</summary></summary>
        public DateTime UserTime { get; set; }

        /// <summary><summary>Typ operace (typ ENUM).</summary></summary>
        public int TypeEnumId { get; set; }

        /// <summary><summary>Název typu operace.</summary></summary>
        public string TypeEnumName { get; set; } = string.Empty;

        /// <summary><summary>Klíč operace (klíč ENUM).</summary></summary>
        public int KeyEnumId { get; set; }

        /// <summary><summary>Název klíče operace.</summary></summary>
        public string KeyEnumName { get; set; } = string.Empty;

        /// <summary><summary>Popis operace (volitelné).</summary></summary>
        public string? Description { get; set; }

        /// <summary><summary>Datum a čas poslední aktualizace.</summary></summary>
        public DateTime? UpdatedAt { get; set; }

    }
}