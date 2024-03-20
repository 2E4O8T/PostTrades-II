using Microsoft.EntityFrameworkCore;
using PostTrades_II.Data;
using PostTrades_II.Domain;

namespace PostTrades_II.Repositories;

public class BidRepository(PostTradesDbContext postTradesDbContext) : IBidRepository
{
    public async Task<IEnumerable<Bid>> GetAllBids()
    {
        return await postTradesDbContext.Bids.ToListAsync();
    }

    public async Task<Bid> GetBidById(int id)
    {
        return await postTradesDbContext.Bids.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<int> CreateBid(Bid bid)
    {
        postTradesDbContext.Bids.Add(bid);

        return await postTradesDbContext.SaveChangesAsync();
    }

    public async Task UpdateBid(Bid bid)
    {
        postTradesDbContext.Entry(bid).State = EntityState.Modified;

        await postTradesDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteBidById(int id)
    {
        var bid = await postTradesDbContext.Bids.FindAsync(id);
        if (bid != null)
        {
            postTradesDbContext.Bids.Remove(bid);
        }

        return await postTradesDbContext.SaveChangesAsync();
    }
}