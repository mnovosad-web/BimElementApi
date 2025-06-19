using System.ComponentModel.DataAnnotations;

namespace BimElementApi.Models;

/// <summary>
/// Represents a BIM element like a wall or door.
/// </summary>
public class BimElement
{
    /// <summary>Unique identifier (IFC GUID) of the element.</summary>
    public string IfcGuid { get; set; } = default!;
    
    /// <summary>Type of the element (e.g., Wall, Door).</summary>
    public string ElementType { get; set; } = default!;

    /// <summary>Progress in percent (0-100).</summary>
    [Range(0, 100)]
    public int ProgressPercent { get; set; }

    /// <summary>Status of the element based on progress.</summary>
    public string Status { get; set; } = default!;
}