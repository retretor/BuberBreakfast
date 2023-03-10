using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.Services.Breakfasts;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("[controller]")]
public class BreakfastController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        var savory = request.Savory.Select(s => new Savory { Name = s }).ToList();
        var sweet = request.Sweet.Select(s => new Sweet { Name = s }).ToList();
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            savory,
            sweet);
        
        _breakfastService.CreateBreakfast(breakfast);
        
        var response = MapBreakfastResponse(breakfast);
        
        return CreatedAtAction(
            nameof(GetBreakfast),
            new {id = breakfast.Id},
            response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        var breakfast = _breakfastService.GetBreakfast(id);
        if (breakfast == null)
        {
            return NotFound();
        }
        
        var response = MapBreakfastResponse(breakfast);
        return Ok(response);
    }
    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        var breakfast = _breakfastService.UpsertBreakfast(id, request);
        if (breakfast == null)
        {
            return NotFound();
        }
        
        var response = MapBreakfastResponse(breakfast);
        return Ok(response);
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        _breakfastService.DeleteBreakfast(id);
        return NoContent();
    }
    
    [HttpGet]
    public IActionResult GetBreakfasts()
    {
        var breakfasts = _breakfastService.GetBreakfasts();
        var response = breakfasts.Select(MapBreakfastResponse);
        return Ok(response);
    }
    
    private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
    {
        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savories.Select(s => s.Name).ToList(),
            breakfast.Sweets.Select(s => s.Name).ToList());
        return response;
    }

    [HttpDelete]
    public IActionResult ClearBreakfasts()
    {
        _breakfastService.ClearBreakfasts();
        return NoContent();
    }
}