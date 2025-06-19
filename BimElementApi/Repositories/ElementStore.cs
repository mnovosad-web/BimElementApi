using BimElementApi.Models;

namespace BimElementApi.Repositories;

public class ElementStore
{
    private readonly Dictionary<string, BimElement> _elements = new();

    public IEnumerable<BimElement> GetAll() => _elements.Values;

    public BimElement? Get(string id) => _elements.TryGetValue(id, out var e) ? e : null;

    public void Add(BimElement element)
    {
        element.Status = CalculateStatus(element.ProgressPercent);
        _elements[element.IfcGuid] = element;
    }

    public bool UpdateProgress(string id, int progress)
    {
        if (!_elements.TryGetValue(id, out var e)) return false;
        e.ProgressPercent = progress;
        e.Status = CalculateStatus(progress);
        return true;
    }

    private static string CalculateStatus(int percent)
    {
        return percent switch
        {
            0 => "NotStarted",
            100 => "Completed",
            _ => "InProgress"
        };
    }
}