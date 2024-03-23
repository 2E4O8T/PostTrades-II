using System.ComponentModel.DataAnnotations;

namespace PostTrades_II.Domain;

public class Trade
{
    public int TradeId { get; set; }

    [Required(ErrorMessage = "Account is required.")]
    [StringLength(50)]
    public string Account { get; set; } = string.Empty;
    [Required(ErrorMessage = "Account Type is required.")]
    [StringLength(50)]
    public string AccountType { get; set; } = string.Empty;
    [Range(0, Double.MaxValue)]
    public double? BuyQuantity { get; set; }
    [Range(0, Double.MaxValue)]
    public double? SellQuantity { get; set; }
    [Range(0, Double.MaxValue)]
    public double? BuyPrice { get; set; }
    [Range(0, Double.MaxValue)]
    public double? SellPrice { get; set; }
    public DateTime? TradeDate { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Trade Security is required.")]
    [StringLength(50)]
    public string TradeSecurity { get; set; } = string.Empty;
    [Required(ErrorMessage = "Trade Status is required.")]
    [StringLength(50)]
    public string TradeStatus { get; set; } = string.Empty;
    [Required(ErrorMessage = "Trader is required.")]
    [StringLength(50)]
    public string Trader { get; set; } = string.Empty;
    [Required(ErrorMessage = "Benchmark is required.")]
    [StringLength(50)]
    public string Benchmark { get; set; } = string.Empty;
    [Required(ErrorMessage = "Book is required.")]
    [StringLength(50)]
    public string Book { get; set; } = string.Empty;
    [Required(ErrorMessage = "Creation Name is required.")]
    [StringLength(50)]
    public string CreationName { get; set; } = string.Empty;
    public DateTime? CreationDate { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Revision Name is required.")]
    [StringLength(50)]
    public string RevisionName { get; set; } = string.Empty;
    public DateTime? RevisionDate { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Deal Name is required.")]
    [StringLength(50)]
    public string DealName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Deal Type is required.")]
    [StringLength(50)]
    public string DealType { get; set; } = string.Empty;
    [Required(ErrorMessage = "Source List Id is required.")]
    [StringLength(50)]
    public string SourceListId { get; set; } = string.Empty;
    [Required(ErrorMessage = "Side is required.")]
    [StringLength(50)]
    public string Side { get; set; } = string.Empty;
}