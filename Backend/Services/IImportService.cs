using Backend.DTOs;

namespace Backend.Services;

public interface IImportService
{
    Task<List<ImportDto>> GetHistoryAsync(int metricId);

    Task<ImportDto?> GetByIdAsync(int id);
}
