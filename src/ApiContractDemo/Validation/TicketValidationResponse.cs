namespace ApiContractDemo.Validation;

public class TicketValidationResponse
{
    public bool IsValid { get; set; }
    public bool RuleValidationPassed { get; set; }
    public bool AiQualityPassed { get; set; }
    public List<ValidationIssue> Issues { get; set; } = new();
    public List<string> Suggestions { get; set; } = new();
}
