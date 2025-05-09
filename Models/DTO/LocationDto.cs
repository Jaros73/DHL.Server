namespace DHL.Server.Models.DTO
{
    /// <summary>
    /// DTO pro Location.
    /// </summary>
    public class LocationDto
    {
        /// <summary><summary>Identifikátor lokace.</summary></summary>
        public int Id { get; set; }

        /// <summary><summary>Název lokace.</summary></summary>
        public string Name { get; set; } = string.Empty;

        /// <summary><summary>Typ poštovní pobočky.</summary></summary>
        public string PostOfficeType { get; set; } = string.Empty;

        /// <summary><summary>Poštovní směrovací číslo (PSČ).</summary></summary>
        public int Psc { get; set; }

    }
}