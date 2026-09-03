using Backend.DTOs;
using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MetricController : ControllerBase
{
    private readonly IMetricService _metricService;

    public MetricController(IMetricService metricService)
    {
        _metricService = metricService;
    }

    // POST: api/Metric/GetAll
    [HttpPost("GetAll")]
    public async Task<ActionResult<List<MetricDto>>> GetAll()
    {
        var result = await _metricService.GetAllAsync();

        return Ok(result);
    }

    // POST: api/Metric/GetById
    [HttpPost("GetById")]
    public async Task<ActionResult<MetricDto>> GetById(
        [FromBody] int id)
    {
        var result = await _metricService.GetByIdAsync(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    // POST: api/Metric/Create
    [HttpPost("Create")]
    public async Task<ActionResult<MetricDto>> Create(
        [FromBody] MetricDto dto)
    {
        var result = await _metricService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result);
    }

    // POST: api/Metric/Update
    [HttpPost("Update")]
    public async Task<ActionResult> Update(
        [FromBody] MetricDto dto)
    {
        var updated = await _metricService.UpdateAsync(dto.Id, dto);

        if (!updated)
        {
            return NotFound();
        }

        return Ok();
    }

    // POST: api/Metric/Delete
    [HttpPost("Delete")]
    public async Task<ActionResult> Delete(
        [FromBody] int id)
    {
        var deleted = await _metricService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return Ok();
    }
}