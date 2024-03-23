using Microsoft.EntityFrameworkCore;
using PostTrades_II.Data;
using PostTrades_II.Domain;

namespace PostTrades_II.Repositories;

public class CurvePointRepository (PostTradesDbContext postTradesDbContext) : ICurvePointRepository
{
    public async Task<IEnumerable<CurvePoint>> GetAllCurvePoints()
    {
        return await postTradesDbContext.CurvePoints.ToListAsync();
    }

    public async Task<CurvePoint> GetCurvePointById(int id)
    {
        return await postTradesDbContext.CurvePoints.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public async Task<int> CreateCurvePoint(CurvePoint curvePoint)
    {
        postTradesDbContext.CurvePoints.Add(curvePoint);

        return await postTradesDbContext.SaveChangesAsync();
    }

    public async Task UpdateCurvePoint(CurvePoint curvePoint)
    {
        postTradesDbContext.Entry(curvePoint).State = EntityState.Modified;

        await postTradesDbContext.SaveChangesAsync();
    }

    public async Task<int> DeleteCurvePointById(int id)
    {
        var curvePoint = await postTradesDbContext.CurvePoints.FindAsync(id);
        if (curvePoint != null)
        {
            postTradesDbContext.CurvePoints.Remove(curvePoint);
        }

        return await postTradesDbContext.SaveChangesAsync();
    }
}