using System.ComponentModel.DataAnnotations;

namespace PostTrades_II.Domain;

public class Bid
{
    public int BidId { get; set; }

    [Required(ErrorMessage = "Account is required.")]
    [StringLength(50)]
    public string Account { get; set; } = string.Empty;
    [Required(ErrorMessage = "Bid Type is required.")]
    [StringLength(50)]
    public string BidType { get; set; } = string.Empty;
    [Range(0, Double.MaxValue)]
    public double? BidQuantity { get; set; }
    [Range(0, Double.MaxValue)]
    public double? AskQuantity { get; set; }
    [Range(0, Double.MaxValue)]
    public double? BidAmount { get; set; }
    [Range(0, Double.MaxValue)]
    public double? AskAmount { get; set; }
    [Required(ErrorMessage = "Benchmark is required.")]
    [StringLength(50)]
    public string Benchmark { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    public DateTime? BidListDate { get; set; }
    [Required(ErrorMessage = "Commentary is required.")]
    [StringLength(50)]
    public string Commentary { get; set; } = string.Empty;
    [Required(ErrorMessage = "Bid Security is required.")]
    [StringLength(50)]
    public string BidSecurity { get; set; } = string.Empty;
    [Required(ErrorMessage = "Bid Status is required.")]
    [StringLength(50)]
    public string BidStatus { get; set; } = string.Empty;
    [Required(ErrorMessage = "Trader is required.")]
    [StringLength(50)]
    public string Trader { get; set; } = string.Empty;
    [Required(ErrorMessage = "Book is required.")]
    [StringLength(50)]
    public string Book { get; set; } = string.Empty;
    [Required(ErrorMessage = "Creation Name is required.")]
    [StringLength(50)]
    public string CreationName { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    public DateTime? CreationDate { get; set; }
    [Required(ErrorMessage = "Revision Name is required.")]
    [StringLength(50)]
    public string RevisionName { get; set; } = string.Empty;
    [DataType(DataType.DateTime)]
    public DateTime? RevisionDate { get; set; }
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