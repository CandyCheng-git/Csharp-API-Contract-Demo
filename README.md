# API Contract Demo

A small backend API demo designed to showcase API contract thinking, Swagger / OpenAPI documentation, request and response examples, validation flow, structured error handling, Postman assets, and integration readiness for other developers or teams.

## Project goal

This project is intentionally small, but it is built to demonstrate more than just CRUD endpoints. It focuses on:

- clear backend API design
- Swagger / OpenAPI documentation
- request and response examples
- validation rules
- structured error handling
- Postman collection support
- integration guide clarity
- AI-assisted validation workflow design

## Suggested demo domain

This demo uses a **Support Ticket API** to show a practical business workflow.

### Core endpoints
- `POST /api/tickets`
- `GET /api/tickets`
- `GET /api/tickets/{id}`
- `PATCH /api/tickets/{id}/status`
- `POST /api/tickets/validate`

## Why this project exists

This repo is designed to demonstrate:

- API contract thinking
- communication clarity for cross-team integration
- predictable validation and error responses
- developer experience awareness
- maintainable service design

## Tech stack

- ASP.NET Core Web API
- Swagger / OpenAPI
- Postman
- C# validation services

## Validation approach

The project uses two validation layers:

1. **Rule-based validation**
   - required fields
   - email format
   - allowed priority values
   - title and description length

2. **AI-style quality validation**
   - title too generic
   - description too vague
   - missing actionable context
   - possible spam-like content

## AI-assisted validation approach

This project includes an AI-assisted validation concept, but the first version does not force a real external LLM integration.

### Why not Python first?
The main goal of this project is to demonstrate API contract design, documentation clarity, validation flow, and integration readiness. Since the backend is built in ASP.NET Core, the validation logic is kept inside the same service boundary for simplicity, consistency, and maintainability.

Adding Python as a separate service in the first version would increase:
- deployment complexity
- cross-service communication overhead
- dependency management
- explanation burden during interviews

For this reason, the first version uses C#-based validation services.

### Why not connect to a real OpenAI API immediately?
A real LLM integration is optional, not required for the first version of this demo.

The first version focuses on:
- clean API design
- rule-based validation
- mock AI-style quality checks
- structured request and response contracts
- predictable error handling

This keeps the demo:
- stable
- free to run
- easier to explain
- easier to test

### Validation layers
The validation flow is designed in two layers:

1. **Rule-based validation**
   - required fields
   - email format
   - allowed priority values
   - title and description length

2. **AI-style quality validation**
   - title too generic
   - description too vague
   - missing actionable context
   - possible spam-like content

### Future extensibility
The design is intended to support a future upgrade to a real AI provider through an interface-based validation service, without changing the external API contract.

## Example integration flow

1. Client submits draft ticket content to `POST /api/tickets/validate`
2. API returns rule validation and AI-style quality findings
3. If validation passes, client submits the ticket to `POST /api/tickets`
4. If quality issues exist, client shows suggestions before final submission

## Repository structure

```text
api-contract-demo/
├── src/
│   └── ApiContractDemo/
│       ├── Controllers/
│       ├── Dtos/
│       ├── Models/
│       ├── Services/
│       ├── Validation/
│       └── Program.cs
├── docs/
│   ├── api-spec-draft.md
│   ├── ai-validation-design.md
│   ├── integration-guide.md
│   └── day1-setup.md
├── postman/
│   └── ApiContractDemo.postman_collection.json
└── README.md
```

## Integration assets
- [API Spec Draft](docs/api-spec-draft.md)
- [AI Validation Design](docs/ai-validation-design.md)
- [Integration Guide](docs/integration-guide.md)
- [Day 1 Setup Guide](docs/day1-setup.md)

## Future improvements

- replace mock AI validation with a real provider
- add SQL persistence
- add authentication
- add API versioning
- add Docker support
- deploy to Azure App Service
