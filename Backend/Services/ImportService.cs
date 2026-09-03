using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services;

public class ImportService : IImportService
{
    private readonly IGenericRepository<Import> _importRepository;

    public ImportService(
        IGenericRepository<Import> importRepository)
    {
        _importRepository = importRepository;
    }

    public async Task<List<ImportDto>> GetHistoryAsync(int metricId)
    {
        var imports = await _importRepository.FindAsync(
            x => x.MetricId == metricId);

        return imports.Select(MapToDto).ToList();
    }

    public async Task<ImportDto?> GetByIdAsync(int id)
    {
        var import = await _importRepository.GetByIdAsync(id);

        if (import == null)
        {
            return null;
        }

        return MapToDto(import);
    }

    private static ImportDto MapToDto(Import import)
    {
        return new ImportDto
        {
            Id = import.Id,
            MetricId = import.MetricId,
            Year = import.Year,
            Period = import.Period,
            FileName = import.FileName,
            ImportedAt = import.ImportedAt,
            Status = import.Status,
            RowsCount = import.RowsCount
        };
    }
}
