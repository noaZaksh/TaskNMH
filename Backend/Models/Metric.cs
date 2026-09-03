namespace Backend.Models;

public class Metric
{
    public int Id { get; set; }

    public int PremiumMethodId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string SourceType { get; set; } = string.Empty;

    public string SourceName { get; set; } = string.Empty;

    public string Frequency { get; set; } = string.Empty;

    // קשר ל-PremiumMethod
    public PremiumMethod? PremiumMethod { get; set; }

    // השדות הדינמיים של ה-Metric
    public ICollection<MetricField> Fields { get; set; } = new List<MetricField>();

    // היסטוריית ייבוא הנתונים
    public ICollection<Import> Imports { get; set; } = new List<Import>();

    // גרסאות מבנה ה-Excel
    public ICollection<ImportSchema> Schemas { get; set; } = new List<ImportSchema>();
}