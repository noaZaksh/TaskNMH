using Backend.DTOs;

namespace Backend.Services;

public interface IMetricService
{
    Task<List<MetricDto>> GetAllAsync();

    Task<MetricDto?> GetByIdAsync(int id);

    Task<MetricDto> CreateAsync(MetricDto dto);

    Task<bool> UpdateAsync(int id, MetricDto dto);

    Task<bool> DeleteAsync(int id);
}