using System.ComponentModel.DataAnnotations;

namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// Spojovací model mezi lokací a strojem (LocationMachines).
    /// </summary>
    public class LocationMachine
    {
        /// <summary>FK na lokaci.</summary>
        [Required]
        public int LocationId { get; set; }


        /// <summary>FK na stroj.</summary>
        [Required]
        public string MachineValue { get; set; } = string.Empty;
    }
}
