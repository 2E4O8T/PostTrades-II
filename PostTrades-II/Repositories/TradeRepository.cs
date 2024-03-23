using Microsoft.EntityFrameworkCore;
using PostTrades_II.Data;
using PostTrades_II.Domain;

namespace PostTrades_II.Repositories;

public class TradeRepository (PostTradesDbContext postTradesDbContext) : ITradeRepository
{
    public async Task<IEnumerable<Trade>> GetAllTrades()
    {
        return await postTradesDbContext.Trades.ToListAsync();
    }

    public async Task<Trade> GetTradeById(int id)
    {
        return await postTradesDbContext.Trades.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<int> CreateTrade(Trade trade)
    {
        postTradesDbContext.Trades.Add(trade);

        return await postTradesDbContext.SaveChangesAsync();
    }

    public async Task UpdateTrade(Trade trade)
    {
        postTradesDbContext.Entry(trade).State = EntityState.Modified;

        await postTradesDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteTradeById(int id)
    {
        var trade = await postTradesDbContext.Trades.FindAsync(id);
        if (trade != null)
        {
            postTradesDbContext.Trades.Remove(trade);
        }

        return await postTradesDbContext.SaveChangesAsync();
    }
}