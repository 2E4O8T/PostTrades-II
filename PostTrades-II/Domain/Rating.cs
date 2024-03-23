using System.ComponentModel.DataAnnotations;

namespace PostTrades_II.Domain;

public class Rating
{
    public int RatingId { get; set; }

    [Required(ErrorMessage = "Moody's Rating is required.")]
    [StringLength(50)]
    public string MoodysRating { get; set; } = string.Empty;
    [Required(ErrorMessage = "Standard and Poor's is required.")]
    [StringLength(50)]
    public string SandPRating { get; set; } = string.Empty;
    [Required(ErrorMessage = "Fitch Rating is required.")]
    [StringLength(50)]
    public string FitchRating { get; set; } = string.Empty;
    public byte? OrderNumber { get; set; }
}