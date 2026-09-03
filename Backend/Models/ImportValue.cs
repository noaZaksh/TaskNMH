namespace Backend.Models;

public class ImportValue
{
    public int Id { get; set; }

    public int ImportRowId { get; set; }

    public int MetricFieldId { get; set; }

    public string Value { get; set; } = string.Empty;

    public ImportRow? ImportRow { get; set; }

    public MetricField? MetricField { get; set; }
}
