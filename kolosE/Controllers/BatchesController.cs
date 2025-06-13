using kolosE.Models.DTOs;
using kolosE.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolosE.Controllers;

[ApiController]
[Route("api/[controller]")]

public class BatchesController : ControllerBase
{
    private readonly INurseriesService _nurseriesService;

    public BatchesController(INurseriesService nurseriesService)
    {
        _nurseriesService = nurseriesService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertNewBatchAsync(BatchRequestDTO request, CancellationToken token)
    {
        await _nurseriesService.InsertNewBatchAsync(request, token);
        return Created();
    }
    
    
}