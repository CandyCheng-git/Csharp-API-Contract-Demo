using System.ComponentModel.DataAnnotations;

namespace ApiContractDemo.Dtos;

public class UpdateTicketStatusRequest
{
    [Required]
    [RegularExpression("open|in_progress|closed", ErrorMessage = "Status must be open, in_progress, or closed.")]
    public string Status { get; set; } = string.Empty;
}
