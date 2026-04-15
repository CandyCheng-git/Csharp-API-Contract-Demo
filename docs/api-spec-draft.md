# API Spec Draft

## Overview

This API provides a simple support ticket workflow with both standard CRUD-style operations and a pre-submission validation endpoint.

## Base URL

`https://localhost:5001`

## Content type

`application/json`

---

## Data model

### Ticket
```json
{
  "id": "uuid",
  "title": "Unable to login to employee portal",
  "description": "After resetting my password this morning, I still cannot log in to the employee portal.",
  "requesterEmail": "user@example.com",
  "priority": "high",
  "status": "open",
  "createdAt": "2026-04-15T10:00:00Z"
}
```

### Allowed priority values
- `low`
- `medium`
- `high`

### Allowed status values
- `open`
- `in_progress`
- `closed`

---

## Endpoint definitions

### 1. Create ticket
**POST** `/api/tickets`

#### Request body
```json
{
  "title": "Unable to login to employee portal",
  "description": "After resetting my password this morning, I still cannot log in to the employee portal. The page keeps showing an invalid credentials message.",
  "requesterEmail": "user@example.com",
  "priority": "high"
}
```

#### Success response
**201 Created**
```json
{
  "id": "0d9a5a61-4ddf-4a6f-bfdb-23821b6e8d36",
  "title": "Unable to login to employee portal",
  "description": "After resetting my password this morning, I still cannot log in to the employee portal. The page keeps showing an invalid credentials message.",
  "requesterEmail": "user@example.com",
  "priority": "high",
  "status": "open",
  "createdAt": "2026-04-15T10:00:00Z"
}
```

#### Validation error response
**400 Bad Request**
```json
{
  "error": "validation_failed",
  "message": "One or more validation errors occurred.",
  "details": {
    "title": [
      "The Title field is required."
    ],
    "requesterEmail": [
      "The RequesterEmail field is not a valid e-mail address."
    ]
  }
}
```

---

### 2. Get all tickets
**GET** `/api/tickets`

#### Success response
**200 OK**
```json
[
  {
    "id": "0d9a5a61-4ddf-4a6f-bfdb-23821b6e8d36",
    "title": "Unable to login to employee portal",
    "description": "After resetting my password this morning, I still cannot log in to the employee portal.",
    "requesterEmail": "user@example.com",
    "priority": "high",
    "status": "open",
    "createdAt": "2026-04-15T10:00:00Z"
  }
]
```

---

### 3. Get ticket by ID
**GET** `/api/tickets/{id}`

#### Success response
**200 OK**
```json
{
  "id": "0d9a5a61-4ddf-4a6f-bfdb-23821b6e8d36",
  "title": "Unable to login to employee portal",
  "description": "After resetting my password this morning, I still cannot log in to the employee portal.",
  "requesterEmail": "user@example.com",
  "priority": "high",
  "status": "open",
  "createdAt": "2026-04-15T10:00:00Z"
}
```

#### Not found response
**404 Not Found**
```json
{
  "error": "ticket_not_found",
  "message": "Ticket with the given id was not found."
}
```

---

### 4. Update ticket status
**PATCH** `/api/tickets/{id}/status`

#### Request body
```json
{
  "status": "in_progress"
}
```

#### Success response
**200 OK**
```json
{
  "id": "0d9a5a61-4ddf-4a6f-bfdb-23821b6e8d36",
  "title": "Unable to login to employee portal",
  "description": "After resetting my password this morning, I still cannot log in to the employee portal.",
  "requesterEmail": "user@example.com",
  "priority": "high",
  "status": "in_progress",
  "createdAt": "2026-04-15T10:00:00Z"
}
```

#### Validation error response
**400 Bad Request**
```json
{
  "error": "validation_failed",
  "message": "One or more validation errors occurred.",
  "details": {
    "status": [
      "Status must be open, in_progress, or closed."
    ]
  }
}
```

---

### 5. Validate ticket content
**POST** `/api/tickets/validate`

#### Request body
```json
{
  "title": "Help",
  "description": "not working",
  "requesterEmail": "user@example.com",
  "priority": "high"
}
```

#### Success response
**200 OK**
```json
{
  "isValid": true,
  "ruleValidationPassed": true,
  "aiQualityPassed": false,
  "issues": [
    {
      "code": "title_too_generic",
      "message": "The title is too vague. Please describe the issue more clearly."
    },
    {
      "code": "description_too_short_for_support",
      "message": "The description does not contain enough detail for troubleshooting."
    }
  ],
  "suggestions": [
    "Use a more specific title, such as 'Unable to login to employee portal'.",
    "Include when the issue started and what error message was shown."
  ]
}
```

---

## Validation response schema

### ValidationResult
```json
{
  "isValid": true,
  "ruleValidationPassed": true,
  "aiQualityPassed": false,
  "issues": [
    {
      "code": "title_too_generic",
      "message": "The title is too vague. Please describe the issue more clearly."
    }
  ],
  "suggestions": [
    "Use a more specific title."
  ]
}
```

### Fields
- `isValid`: overall boolean outcome
- `ruleValidationPassed`: whether structural validation passed
- `aiQualityPassed`: whether content quality validation passed
- `issues`: list of validation findings
- `suggestions`: list of suggested improvements

### ValidationIssue
```json
{
  "code": "title_too_generic",
  "message": "The title is too vague. Please describe the issue more clearly."
}
```
