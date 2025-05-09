// File: Features/Ciselniky/Models/KlicDto.cs
using System;

namespace DHL.Server.Features.Ciselniky.Models
{
    /// <summary>
    /// DTO pro práci s klíčem technologické skupiny.
    /// </summary>
    public class KlicDto
    {
        /// <summary>ID klíče.</summary>
        public int Id { get; set; }

        /// <summary>Název klíče.</summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>Zda je klíč aktivní.</summary>
        public bool IsActive { get; set; }

        /// <summary>Datum vytvoření.</summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>Kdo záznam vytvořil.</summary>
        public string CreatedBy { get; set; } = "system";

        /// <summary>Datum poslední aktualizace.</summary>
        public DateTime Updated { get; set; } = DateTime.UtcNow;

    }
}
