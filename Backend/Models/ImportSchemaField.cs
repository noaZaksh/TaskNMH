namespace Backend.Models;

public class ImportSchemaField
{
    public int Id { get; set; }

    public int ImportSchemaId { get; set; }

    public int MetricFieldId { get; set; }

    public string ExcelColumnName { get; set; } = string.Empty;

    public int ExcelColumnIndex { get; set; }

    public ImportSchema? ImportSchema { get; set; }

    public MetricField? MetricField { get; set; }
}
