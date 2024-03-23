using System.ComponentModel.DataAnnotations;

namespace PostTrades_II.Domain;

public class RuleName
{
    public int RuleNameId { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Description is required.")]
    [StringLength(50)]
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "Json is required.")]
    [StringLength(50)]
    public string Json { get; set; } = string.Empty;
    [Required(ErrorMessage = "Template is required.")]
    [StringLength(50)]
    public string Template { get; set; } = string.Empty;
    [Required(ErrorMessage = "SQL String is required.")]
    [StringLength(50)]
    public string SqlStr { get; set; } = string.Empty;
    [Required(ErrorMessage = "SQL Partition is required.")]
    [StringLength(50)]
    public string SqlPart { get; set; } = string.Empty;
}