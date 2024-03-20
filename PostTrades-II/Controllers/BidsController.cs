using Microsoft.AspNetCore.Mvc;
using PostTrades_II.Domain;
using PostTrades_II.Repositories;

namespace PostTrades_II.Controllers;

[Route("/[controller]")]
[ApiController]
public class BidsController : ControllerBase
{
    private readonly IBidRepository _bidRepository;

    public BidsController(IBidRepository bidRepository)
    {
        _bidRepository = bidRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Bid>>> GetAllBids()
    {
        var bids = await _bidRepository.GetAllBids();
        if (bids == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        return Ok(bids);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Bid>> GetBidById(int id)
    {
        var bid = await _bidRepository.GetBidById(id);
        if (bid == null)
        {
            return NotFound();
        }

        return Ok(bid);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Bid>> CreateBid(Bid bid)
    {
        if (bid == null)
        {
            return NotFound();
        }

        await _bidRepository.CreateBid(bid);

        return CreatedAtAction(nameof(GetBidById), new { id = bid.BidId }, bid);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateBid(int id, Bid bid)
    {
        if (id != bid?.BidId)
        {
            return BadRequest();
        }

        await _bidRepository.UpdateBid(bid);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteBidById(int id)
    {
        await _bidRepository.DeleteBidById(id);

        return NoContent();
    }
}