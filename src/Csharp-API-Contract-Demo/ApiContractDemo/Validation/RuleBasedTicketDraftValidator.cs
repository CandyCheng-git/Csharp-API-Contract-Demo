using ApiContractDemo.Dtos;

namespace ApiContractDemo.Validation;

public class RuleBasedTicketDraftValidator : ITicketDraftValidator
{
    private static readonly string[] GenericTitles =
    {
        "help",
        "issue",
        "problem",
        "urgent",
        "not working"
    };

    private static readonly string[] ActionableKeywords =
    {
        "error",
        "login",
        "password",
        "portal",
        "screen",
        "page",
        "button",
        "failed",
        "cannot",
        "unable",
        "after",
        "when"
    };

    public TicketValidationResponse Validate(ValidateTicketRequest request)
    {
        var issues = new List<ValidationIssue>();
        var suggestions = new List<string>();

        var normalizedTitle = request.Title.Trim().ToLowerInvariant();
        var normalizedDescription = request.Description.Trim().ToLowerInvariant();

        if (GenericTitles.Contains(normalizedTitle))
        {
            issues.Add(new ValidationIssue
            {
                Code = "title_too_generic",
                Message = "The title is too vague. Please describe the issue more clearly."
            });
            suggestions.Add("Use a more specific title, such as 'Unable to login to employee portal'.");
        }

        if (normalizedDescription.Length < 25)
        {
            issues.Add(new ValidationIssue
            {
                Code = "description_too_short_for_support",
                Message = "The description does not contain enough detail for troubleshooting."
            });
            suggestions.Add("Include when the issue started and what error message was shown.");
        }

        var hasActionableContext = ActionableKeywords.Any(keyword => normalizedDescription.Contains(keyword));
        if (!hasActionableContext)
        {
            issues.Add(new ValidationIssue
            {
                Code = "missing_actionable_context",
                Message = "The description is missing actionable troubleshooting context."
            });
            suggestions.Add("Include where the issue happened, what you were doing, and what result you saw.");
        }

        if (LooksSpamLike(normalizedTitle, normalizedDescription))
        {
            issues.Add(new ValidationIssue
            {
                Code = "possible_spam_content",
                Message = "The content looks repetitive or too low-information for support handling."
            });
            suggestions.Add("Rewrite the request using normal sentences and remove repeated filler words.");
        }

        var aiQualityPassed = issues.Count == 0;

        return new TicketValidationResponse
        {
            IsValid = true,
            RuleValidationPassed = true,
            AiQualityPassed = aiQualityPassed,
            Issues = issues,
            Suggestions = suggestions.Distinct().ToList()
        };
    }

    private static bool LooksSpamLike(string title, string description)
    {
        if (title.Length > 0 && title.Distinct().Count() <= 2)
        {
            return true;
        }

        var words = description.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (words.Length >= 3)
        {
            var repeatedWordRatio = words.GroupBy(w => w).Max(g => g.Count()) / (double)words.Length;
            if (repeatedWordRatio > 0.6)
            {
                return true;
            }
        }

        return false;
    }
}
