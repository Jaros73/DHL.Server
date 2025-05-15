namespace DHL.Server.Features.Dispatching.Models
{
    /// <summary>
    /// DTO pro DispatchType.
    /// </summary>
    public class DispatchTypeDto
    {
        /// <summary><summary>Primární klíč typu operace.</summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Název typu operace.</summary></summary>
        public string Name { get; set; } = string.Empty;

    }
}