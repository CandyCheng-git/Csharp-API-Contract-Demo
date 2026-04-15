using System.ComponentModel.DataAnnotations;

namespace ApiContractDemo.Dtos;

public class CreateTicketRequest
{
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Title { get; set; } = string.Empty;

    [Required]
    [StringLength(500, MinimumLength = 10)]
    public string Description { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string RequesterEmail { get; set; } = string.Empty;

    [Required]
    [RegularExpression("low|medium|high", ErrorMessage = "Priority must be low, medium, or high.")]
    public string Priority { get; set; } = string.Empty;
}
