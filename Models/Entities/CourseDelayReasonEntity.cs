using System.ComponentModel.DataAnnotations;

public class CourseDelayReasonEntity
{
    public int Id { get; set; }

    /// <summary>Název důvodu zpoždění.</summary>
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;

    /// <summary>Stav aktivace záznamu.</summary>
    public bool IsActive { get; set; }

    /// <summary>Datum vytvoření záznamu.</summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>Autor záznamu.</summary>
    public string CreatedBy { get; set; } = string.Empty;
}
