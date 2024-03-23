using Microsoft.AspNetCore.Mvc;
using PostTrades_II.Domain;
using PostTrades_II.Repositories;

namespace PostTrades_II.Controllers;

[Route("/[controller]")]
[ApiController]
public class TradesController : ControllerBase
{
    private readonly ITradeRepository _tradeRepository;

    public TradesController(ITradeRepository tradeRepository)
    {
        _tradeRepository = tradeRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Trade>>> GetAllTrades()
    {
        var trades = await _tradeRepository.GetAllTrades();
        if (trades == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        return Ok(trades);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Trade>> GetTradeById(int id)
    {
        var trade = await _tradeRepository.GetTradeById(id);
        if (trade == null)
        {
            return NotFound();
        }

        return Ok(trade);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Trade>> CreateTrade(Trade trade)
    {
        if (trade == null)
        {
            return NotFound();
        }

        await _tradeRepository.CreateTrade(trade);

        return CreatedAtAction(nameof(GetTradeById), new { id = trade.TradeId }, trade);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateTrade(int id, Trade trade)
    {
        if (id != trade?.TradeId)
        {
            return BadRequest();
        }

        await _tradeRepository.UpdateTrade(trade);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteTradeById(int id)
    {
        await _tradeRepository.DeleteTradeById(id);

        return NoContent();
    }
}