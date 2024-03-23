using Microsoft.EntityFrameworkCore;
using PostTrades_II.Data;
using PostTrades_II.Domain;

namespace PostTrades_II.Repositories;

public class RatingRepository (PostTradesDbContext postTradesDbContext) : IRatingRepository
{
    public async Task<IEnumerable<Rating>> GetAllRatings()
    {
        return await postTradesDbContext.Ratings.ToListAsync();
    }

    public async Task<Rating> GetRatingById(int id)
    {
        return await postTradesDbContext.Ratings.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<int> CreateRating(Rating rating)
    {
        postTradesDbContext.Ratings.Add(rating);

        return await postTradesDbContext.SaveChangesAsync();
    }

    public async Task UpdateRating(Rating rating)
    {
        postTradesDbContext.Entry(rating).State = EntityState.Modified;

        await postTradesDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteRatingById(int id)
    {
        var rating = await postTradesDbContext.Ratings.FindAsync(id);
        if (rating != null)
        {
            postTradesDbContext.Ratings.Remove(rating);
        }

        return await postTradesDbContext.SaveChangesAsync();
    }
}