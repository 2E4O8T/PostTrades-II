using PostTrades_II.Domain;

namespace PostTrades_II.Repositories;

public interface IRuleNameRepository
{
    Task<IEnumerable<RuleName>> GetAllRuleNames();
    Task<RuleName> GetRuleNameById(int id);
    Task<int> CreateRuleName(RuleName ruleName);
    Task UpdateRuleName(RuleName ruleName);
    Task<int> DeleteRuleNameById(int id);
}