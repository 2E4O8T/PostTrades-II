using Microsoft.AspNetCore.Mvc;
using PostTrades_II.Domain;
using PostTrades_II.Repositories;

namespace PostTrades_II.Controllers;

[Route("/[controller]")]
[ApiController]
public class RatingsController : ControllerBase
{
    private readonly IRatingRepository _ratingRepository;

    public RatingsController(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Rating>>> GetAllRatings()
    {
        var ratings = await _ratingRepository.GetAllRatings();
        if (ratings == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        return Ok(ratings);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Rating>> GetRatingById(int id)
    {
        var rating = await _ratingRepository.GetRatingById(id);
        if (rating == null)
        {
            return NotFound();
        }

        return Ok(rating);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rating>> CreateRating(Rating rating)
    {
        if (rating == null)
        {
            return NotFound();
        }

        await _ratingRepository.CreateRating(rating);

        return CreatedAtAction(nameof(GetRatingById), new { id = rating.RatingId }, rating);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateRating(int id, Rating rating)
    {
        if (id != rating?.RatingId)
        {
            return BadRequest();
        }

        await _ratingRepository.UpdateRating(rating);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteRatingById(int id)
    {
        await _ratingRepository.DeleteRatingById(id);

        return NoContent();
    }
}