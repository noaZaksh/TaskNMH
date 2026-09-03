namespace Backend.Models;

public class ImportSchema
{
    public int Id { get; set; }

    public int MetricId { get; set; }

    public int Version { get; set; }

    public DateTime CreatedAt { get; set; }

    public Metric? Metric { get; set; }

    public ICollection<ImportSchemaField> Fields { get; set; } = new List<ImportSchemaField>();
}
