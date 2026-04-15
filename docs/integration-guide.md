# Integration Guide

## Purpose

This guide explains how a client application can integrate with the Support Ticket API.

## Base URL

`https://localhost:5001`

## Authentication

This demo does not require authentication.

## Endpoints

### Create ticket
`POST /api/tickets`

### Get all tickets
`GET /api/tickets`

### Get ticket by id
`GET /api/tickets/{id}`

### Update ticket status
`PATCH /api/tickets/{id}/status`

### Validate draft ticket
`POST /api/tickets/validate`

## Suggested client flow

1. User fills in a ticket form
2. Client sends draft content to `POST /api/tickets/validate`
3. API returns rule-validation and AI-style quality results
4. If the draft is acceptable, client sends final request to `POST /api/tickets`
5. If the draft has issues, client shows suggestions before final submission

## Validation rules

### Rule-based validation
- title is required
- title length must be within the accepted range
- description is required
- description length must be within the accepted range
- requesterEmail must be a valid email
- priority must be one of the allowed values

### AI-style quality validation
- title should not be too generic
- description should contain enough support detail
- content should include actionable context where possible
- content should not look like spam or low-information input

## Error format

### Example validation error
```json
{
  "error": "validation_failed",
  "message": "One or more validation errors occurred.",
  "details": {
    "requesterEmail": [
      "The RequesterEmail field is not a valid e-mail address."
    ]
  }
}
```

### Example not found error
```json
{
  "error": "ticket_not_found",
  "message": "Ticket with the given id was not found."
}
```
