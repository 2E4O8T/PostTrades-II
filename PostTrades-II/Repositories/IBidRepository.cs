using PostTrades_II.Domain;

namespace PostTrades_II.Repositories;

public interface IBidRepository
{
    Task<IEnumerable<Bid>> GetAllBids();
    Task<Bid> GetBidById(int id);
    Task<int> CreateBid(Bid bid);
    Task UpdateBid(Bid bid);
    Task<int> DeleteBidById(int id);
}