using PostTrades_II.Domain;

namespace PostTrades_II.Repositories;

public interface ICurvePointRepository
{
    Task<IEnumerable<CurvePoint>> GetAllCurvePoints();
    Task<CurvePoint> GetCurvePointById(int id);
    Task<int> CreateCurvePoint(CurvePoint curvePoint);
    Task UpdateCurvePoint(CurvePoint curvePoint);
    Task<int> DeleteCurvePointById(int id);
}