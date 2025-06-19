using System.ComponentModel.DataAnnotations;
using BimElementApi.DTOs;
using BimElementApi.Models;
using BimElementApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BimElementApi.Controllers;

/// <summary>
/// Controller for managing BIM elements.
/// </summary>
[ApiController]
[Route("api/elements")]
public class BimElementController : ControllerBase
{
    private readonly ElementStore _store;

    public BimElementController(ElementStore store)
    {
        _store = store;
    }
    
    /// <summary>Get all BIM elements.</summary>
    [HttpGet]
    public IActionResult GetAll()
    {
        var elements = _store.GetAll();
        return Ok(elements);
    }

    /// <summary>Get a BIM element by its IFC GUID.</summary>
    /// <param name="ifcGuid">The unique IFC GUID of the element.</param>
    [HttpGet("{ifcGuid}")]
    public IActionResult GetById(string ifcGuid)
    {
        var element = _store.Get(ifcGuid);
        return element is null ? NotFound() : Ok(element);
    }

    /// <summary>Add a new BIM element.</summary>
    /// <param name="element">The BIM element to add.</param>
    [HttpPost]
    public IActionResult Add([FromBody] BimElement element)
    {
        var context = new ValidationContext(element);
        var results = new List<ValidationResult>();
        if (!Validator.TryValidateObject(element, context, results, true))
            return BadRequest(results);

        _store.Add(element);
        return CreatedAtAction(nameof(GetById), new { ifcGuid = element.IfcGuid }, element);
    }

    /// <summary>Update the progress of a BIM element.</summary>
    /// <param name="ifcGuid">The unique IFC GUID of the element.</param>
    /// <param name="dto">Progress update object.</param>
    [HttpPut("{ifcGuid}/progress")]
    public IActionResult UpdateProgress(string ifcGuid, [FromBody] ProgressDto dto)
    {
        if (dto.ProgressPercent is < 0 or > 100)
            return BadRequest("Progress must be between 0 and 100.");

        var success = _store.UpdateProgress(ifcGuid, dto.ProgressPercent);
        return success ? NoContent() : NotFound();
    }
}