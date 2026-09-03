namespace Backend.DTOs;

public class ImportDto
{
    public int Id { get; set; }
    public int MetricId { get; set; }
    public int Year { get; set; }
    public string Period { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public DateTime ImportedAt { get; set; }
    public string Status { get; set; } = string.Empty;
    public int RowsCount { get; set; }
}
