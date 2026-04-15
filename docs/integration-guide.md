# Integration Guide

## Purpose

This guide explains how a client application can integrate with the Support Ticket API.

## Base URL

`https://localhost:7191`

## Authentication

This demo does not require authentication.

## Main Endpoints

### Create ticket
`POST /api/Tickets`

### Get all tickets
`GET /api/Tickets`

### Get ticket by id
`GET /api/Tickets/{id}`

### Update ticket status
`PATCH /api/Tickets/{id}/status`

### Validate draft ticket
`POST /api/Tickets/validate`

## Suggested Client Flow

1. User fills in a ticket form
2. Client sends draft content to `POST /api/Tickets/validate`
3. API returns rule validation and AI-style quality results
4. If the draft is acceptable, client sends final request to `POST /api/Tickets`
5. If the draft has issues, client shows suggestions before final submission

## Validation Rules

### Rule-based validation
- title is required
- title length must be between 5 and 100 characters
- description is required
- description length must be between 10 and 500 characters
- requesterEmail must be a valid email
- priority must be one of: low, medium, high

### AI-style quality validation
- title should not be too generic
- description should contain enough support detail
- content should include actionable context where possible
- content should not look like spam or low-information input

## Error Format

### Validation error example
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

### Not found error example
```json
{
  "error": "ticket_not_found",
  "message": "Ticket with the given id was not found."
}
```
