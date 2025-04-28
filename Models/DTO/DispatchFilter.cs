namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// Model pro filtrování dispečerských záznamů podle časového rozmezí.
    /// </summary>
    public class DispatchDateRange
    {
        /// <summary>
        /// Počáteční datum filtru.
        /// </summary>
        public DateTime? From { get; set; } = null;

        /// <summary>
        /// Koncové datum filtru.
        /// </summary>
        public DateTime? To { get; set; } = null;
    }

    /// <summary>
    /// Model pro filtrování dispečerských záznamů.
    /// </summary>
    public class DispatchFilter
    {
        /// <summary>
        /// Filtruje záznamy podle data vytvoření (rozsah od-do).
        /// </summary>
        public DispatchDateRange CreatedAt { get; set; } = new DispatchDateRange();

        /// <summary>
        /// Filtruje záznamy podle lokací (více hodnot).
        /// </summary>
        public List<string>? LocationIds { get; set; }

        /// <summary>
        /// Filtruje záznamy podle typů operací (více hodnot).
        /// </summary>
        public List<int>? TypeEnumIds { get; set; }

        /// <summary>
        /// Filtruje záznamy podle klíčů operací (více hodnot).
        /// </summary>
        public List<int>? KeyEnumIds { get; set; }
    }
}