# Day 2 Rule-Based Validation

## What Changed
- Added `ITicketDraftValidator`
- Added `RuleBasedTicketDraftValidator`
- Registered the validator in `Program.cs`
- Wired `/api/Tickets/validate` to real validation logic

## Validation Rules Implemented
- title too generic
- description too short for support
- missing actionable context
- possible spam-like content

## Why This Matters
This step moves the project from a basic API shell into a more realistic validation design. It shows that the API can do more than accept structurally valid input. It can also evaluate whether the content is useful enough for downstream support handling.

## Test Cases to Try in Swagger

### Good request
```json
{
  "title": "Unable to login to employee portal",
  "description": "After resetting my password this morning, I still cannot log in to the employee portal. The page keeps showing an invalid credentials message.",
  "requesterEmail": "user@example.com",
  "priority": "high"
}
```

### Poor request
```json
{
  "title": "Help",
  "description": "not working",
  "requesterEmail": "user@example.com",
  "priority": "high"
}
```

## Expected Result
The poor request should return:
- `aiQualityPassed = false`
- one or more issues
- suggestions for improvement
