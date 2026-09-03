using Backend.DTOs;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Services;

public class MetricService : IMetricService
{
    private readonly IGenericRepository<Metric> _metricRepository;

    public MetricService(
        IGenericRepository<Metric> metricRepository)
    {
        _metricRepository = metricRepository;
    }

    public async Task<List<MetricDto>> GetAllAsync()
    {
        var metrics = await _metricRepository.GetAllAsync();

        return metrics.Select(MapToDto).ToList();
    }

    public async Task<MetricDto?> GetByIdAsync(int id)
    {
        var metric = await _metricRepository.GetByIdAsync(id);

        if (metric == null)
        {
            return null;
        }

        return MapToDto(metric);
    }

    public async Task<MetricDto> CreateAsync(MetricDto dto)
    {
        var metric = new Metric
        {
            PremiumMethodId = dto.PremiumMethodId,
            Name = dto.Name,
            Description = dto.Description,
            SourceType = dto.SourceType,
            SourceName = dto.SourceName,
            Frequency = dto.Frequency
        };

        await _metricRepository.AddAsync(metric);
        await _metricRepository.SaveChangesAsync();

        return MapToDto(metric);
    }

    public async Task<bool> UpdateAsync(int id, MetricDto dto)
    {
        var metric = await _metricRepository.GetByIdAsync(id);

        if (metric == null)
        {
            return false;
        }

        metric.PremiumMethodId = dto.PremiumMethodId;
        metric.Name = dto.Name;
        metric.Description = dto.Description;
        metric.SourceType = dto.SourceType;
        metric.SourceName = dto.SourceName;
        metric.Frequency = dto.Frequency;

        _metricRepository.Update(metric);
        await _metricRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var metric = await _metricRepository.GetByIdAsync(id);

        if (metric == null)
        {
            return false;
        }

        _metricRepository.Delete(metric);
        await _metricRepository.SaveChangesAsync();

        return true;
    }

    private static MetricDto MapToDto(Metric metric)
    {
        return new MetricDto
        {
            Id = metric.Id,
            PremiumMethodId = metric.PremiumMethodId,
            Name = metric.Name,
            Description = metric.Description,
            SourceType = metric.SourceType,
            SourceName = metric.SourceName,
            Frequency = metric.Frequency
        };
    }
}