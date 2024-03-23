using PostTrades_II.Domain;

namespace PostTrades_II.Repositories;

public interface IRatingRepository
{
    Task<IEnumerable<Rating>> GetAllRatings();
    Task<Rating> GetRatingById(int id);
    Task<int> CreateRating(Rating rating);
    Task UpdateRating(Rating rating);
    Task<int> DeleteRatingById(int id);
}