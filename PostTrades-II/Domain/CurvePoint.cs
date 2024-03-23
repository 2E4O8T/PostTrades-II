using System.ComponentModel.DataAnnotations;

namespace PostTrades_II.Domain;

public class CurvePoint
{
    public int CurvePointId { get; set; }
    
    public byte? CurveId { get; set; }
    public DateTime? AsOfDate { get; set; } = DateTime.Now;
    [Range(0, Double.MaxValue)]
    public double? Term { get; set; }
    [Range(0, Double.MaxValue)]
    public double? CurvePointValue { get; set; }
    public DateTime? CreationDate { get; set; } = DateTime.Now;
}