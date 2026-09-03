namespace Backend.Models;

public class ImportRow
{
    public int Id { get; set; }

    public int ImportId { get; set; }

    public int RowNumber { get; set; }

    public Import? Import { get; set; }

    public ICollection<ImportValue> Values { get; set; } = new List<ImportValue>();
}
