using Microsoft.AspNetCore.Mvc;
using PostTrades_II.Domain;
using PostTrades_II.Repositories;

namespace PostTrades_II.Controllers;

[Route("/[controller]")]
[ApiController]
public class CurvePointsController : ControllerBase
{
    private readonly ICurvePointRepository _curvePointRepository;

    public CurvePointsController(ICurvePointRepository curvePointRepository)
    {
        _curvePointRepository = curvePointRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CurvePoint>>> GetAllCurvePoints()
    {
        var curvePoints = await _curvePointRepository.GetAllCurvePoints();
        if (curvePoints == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        return Ok(curvePoints);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CurvePoint>> GetCurvePointById(int id)
    {
        var curvePoint = await _curvePointRepository.GetCurvePointById(id);
        if (curvePoint == null)
        {
            return NotFound();
        }

        return Ok(curvePoint);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CurvePoint>> CreateCurvePoint(CurvePoint curvePoint)
    {
        if (curvePoint == null)
        {
            return NotFound();
        }

        await _curvePointRepository.CreateCurvePoint(curvePoint);

        return CreatedAtAction(nameof(GetCurvePointById), new { id = curvePoint.CurvePointId }, curvePoint);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateCurvePoint(int id, CurvePoint curvePoint)
    {
        if (id != curvePoint?.CurvePointId)
        {
            return BadRequest();
        }

        await _curvePointRepository.UpdateCurvePoint(curvePoint);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteCurvePointById(int id)
    {
        await _curvePointRepository.DeleteCurvePointById(id);

        return NoContent();
    }
}