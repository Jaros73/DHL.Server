using System;
using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Features.Ciselniky.Models
{
    /// <summary>
    /// DTO pro přenos dat klíče technologické skupiny.
    /// </summary>
    public class KlicDto
    {
        /// <summary>Primární klíč záznamu.</summary>
        public int Id { get; set; }

        /// <summary>Název klíče.</summary>
        [Required(ErrorMessage = "Název je povinný.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>Zda je klíč aktivní.</summary>
        public bool IsActive { get; set; }

        /// <summary>Datum vytvoření.</summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>Uživatel, který klíč založil.</summary>
        public string CreatedBy { get; set; } = string.Empty;

        /// <summary>Datum poslední změny.</summary>
        public DateTime Updated { get; set; }
    }
}
