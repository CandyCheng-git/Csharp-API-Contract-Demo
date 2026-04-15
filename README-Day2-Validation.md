# Day 2 Rule-Based Validation

## What changed
- Added `ITicketDraftValidator`
- Added `RuleBasedTicketDraftValidator`
- Registered the validator in `Program.cs`
- Wired `/api/tickets/validate` to real validation logic

## Validation rules implemented
- title too generic
- description too short for support
- missing actionable context
- possible spam-like content

## Test cases to try in Swagger

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

## Expected result
The poor request should return:
- `aiQualityPassed = false`
- one or more issues
- suggestions for improvement
