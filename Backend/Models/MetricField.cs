namespace Backend.Models;

public class MetricField
{
    public int Id { get; set; }

    public int MetricId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string DataType { get; set; } = string.Empty;

    public bool IsRelevant { get; set; }

    public bool IsRequired { get; set; }

    public int DisplayOrder { get; set; }

    public Metric? Metric { get; set; }

    public ICollection<ImportValue> Values { get; set; } = new List<ImportValue>();

    public ICollection<ImportSchemaField> SchemaFields { get; set; } = new List<ImportSchemaField>();
}
