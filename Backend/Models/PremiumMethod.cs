namespace Backend.Models;

public class PremiumMethod
{
    public int Id { get; set; }

    public string MethodNumber { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal PremiumPercent { get; set; }

    public string CalculationPeriod { get; set; } = string.Empty;

    public ICollection<Metric> Metrics { get; set; } = new List<Metric>();
}
