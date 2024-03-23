using Microsoft.AspNetCore.Mvc;
using PostTrades_II.Domain;
using PostTrades_II.Repositories;

namespace PostTrades_II.Controllers;

[Route("/[controller]")]
[ApiController]
public class RuleNamesController : ControllerBase
{
    private readonly IRuleNameRepository _ruleNameRepository;

    public RuleNamesController(IRuleNameRepository ruleNameRepository)
    {
        _ruleNameRepository = ruleNameRepository;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<RuleName>>> GetAllRuleNames()
    {
        var ruleNames = await _ruleNameRepository.GetAllRuleNames();
        if (ruleNames == null)
        {
            return StatusCode(StatusCodes.Status400BadRequest);
        }

        return Ok(ruleNames);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<RuleName>> GetRuleNameById(int id)
    {
        var ruleName = await _ruleNameRepository.GetRuleNameById(id);
        if (ruleName == null)
        {
            return NotFound();
        }

        return Ok(ruleName);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<RuleName>> CreateRuleName(RuleName ruleName)
    {
        if (ruleName == null)
        {
            return NotFound();
        }

        await _ruleNameRepository.CreateRuleName(ruleName);

        return CreatedAtAction(nameof(GetRuleNameById), new { id = ruleName.RuleNameId }, ruleName);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> UpdateRuleName(int id, RuleName ruleName)
    {
        if (id != ruleName?.RuleNameId)
        {
            return BadRequest();
        }

        await _ruleNameRepository.UpdateRuleName(ruleName);

        return Ok();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteRuleNameById(int id)
    {
        await _ruleNameRepository.DeleteRuleNameById(id);

        return NoContent();
    }
}