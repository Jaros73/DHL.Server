namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// Model obsahující metadata pro dispečerské záznamy.
    /// </summary>
    public class DispatchMeta
    {
        /// <summary>
        /// Seznam dostupných lokací.
        /// </summary>
        public List<Location> Locations { get; set; } = new();

        /// <summary>
        /// Seznam dostupných typů operací.
        /// </summary>
        public List<DispatchType> Types { get; set; } = new();

        /// <summary>
        /// Seznam dostupných klíčů operací.
        /// </summary>
        public List<DispatchKey> Keys { get; set; } = new();
    }

    /// <summary>
    /// Model pro reprezentaci lokace.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Identifikátor lokace.
        /// </summary>
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Název lokace.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }

    /// <summary>
    /// Model pro reprezentaci typu operace.
    /// </summary>
    public class DispatchType
    {
        /// <summary>
        /// Identifikátor typu operace.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Název typu operace.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }

    /// <summary>
    /// Model pro reprezentaci klíče operace.
    /// </summary>
    public class DispatchKey
    {
        /// <summary>
        /// Identifikátor klíče operace.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Název klíče operace.
        /// </summary>
        public string Name { get; set; } = string.Empty;
    }
}
