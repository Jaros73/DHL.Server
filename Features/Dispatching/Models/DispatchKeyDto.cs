namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro DispatchKey.
    /// </summary>
    public class DispatchKeyDto
    {
        /// <summary><summary>Primární klíč klíče operace.</summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Název klíče operace.</summary></summary>
        public string Name { get; set; } = string.Empty;

    }
}