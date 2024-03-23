using Microsoft.EntityFrameworkCore;
using PostTrades_II.Data;
using PostTrades_II.Domain;

namespace PostTrades_II.Repositories;

public class RuleNameRepository (PostTradesDbContext postTradesDbContext) : IRuleNameRepository
{
    public async Task<IEnumerable<RuleName>> GetAllRuleNames()
    {
        return await postTradesDbContext.RuleNames.ToListAsync();
    }

    public async Task<RuleName> GetRuleNameById(int id)
    {
        return await postTradesDbContext.RuleNames.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<int> CreateRuleName(RuleName ruleName)
    {
        postTradesDbContext.RuleNames.Add(ruleName);

        return await postTradesDbContext.SaveChangesAsync();
    }

    public async Task UpdateRuleName(RuleName ruleName)
    {
        postTradesDbContext.Entry(ruleName).State = EntityState.Modified;

        await postTradesDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteRuleNameById(int id)
    {
        var ruleName = await postTradesDbContext.RuleNames.FindAsync(id);
        if (ruleName != null)
        {
            postTradesDbContext.RuleNames.Remove(ruleName);
        }

        return await postTradesDbContext.SaveChangesAsync();
    }
}