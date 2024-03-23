using PostTrades_II.Domain;

namespace PostTrades_II.Repositories;

public interface ITradeRepository
{
    Task<IEnumerable<Trade>> GetAllTrades();
    Task<Trade> GetTradeById(int id);
    Task<int> CreateTrade(Trade trade);
    Task UpdateTrade(Trade trade);
    Task<int> DeleteTradeById(int id);
}