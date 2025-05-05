using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.Entities
{
    /// <summary>
    /// Spojovací model mezi lokací a strojem (LocationMachines).
    /// </summary>
    public class LocationMachineEntity
    {
        /// <summary>FK na lokaci.</summary>
        [Required]
        public int LocationId { get; set; }


        /// <summary>FK na stroj.</summary>
        [Required]
        public string MachineValue { get; set; } = string.Empty;
    }
}
