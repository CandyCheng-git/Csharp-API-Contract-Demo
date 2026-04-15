# API Contract Demo

A small ASP.NET Core Web API demo built to showcase API contract thinking, structured validation, predictable error handling, and integration readiness for other developers or teams.

## Project Goal

This project is intentionally small, but it is designed to demonstrate more than simple CRUD endpoints. It focuses on:

- clear backend API design
- OpenAPI / Swagger documentation
- request and response contract clarity
- rule-based validation
- AI-style quality validation
- structured error handling
- Postman-based testing assets
- integration documentation for API consumers

## Demo Domain

This demo uses a **Support Ticket API** to simulate a realistic backend workflow.

## Current Endpoints

- `POST /api/Tickets`
- `GET /api/Tickets`
- `GET /api/Tickets/{id}`
- `PATCH /api/Tickets/{id}/status`
- `POST /api/Tickets/validate`

## Why This Project Exists

This repo is designed to show:

- API contract thinking
- communication clarity for cross-team integration
- predictable validation and response structure
- developer experience awareness
- maintainable validation design inside a single backend service boundary

## Validation Flow

The project uses two validation layers:

### 1. Rule-based validation
This ensures the request is structurally valid:
- required fields
- valid email format
- allowed priority values
- title and description length

### 2. AI-style quality validation
This simulates higher-level support request quality review:
- title too generic
- description too vague
- missing actionable context
- possible spam-like content

## AI-Assisted Validation Approach

This project includes an AI-assisted validation concept, but the first version does not require a real external LLM integration.

### Why not Python first?
The main goal of this project is to demonstrate API design, validation flow, documentation clarity, and integration readiness. Since the backend is built in ASP.NET Core, the validation logic is kept inside the same service boundary for simplicity, consistency, and maintainability.

Adding Python as a separate service in the first version would increase:
- deployment complexity
- cross-service communication overhead
- dependency management
- explanation burden during interviews

For this reason, version 1 uses C#-based validation services.

### Why not connect to a real OpenAI API immediately?
A real LLM integration is optional, not required for the first version of this demo.

Version 1 focuses on:
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

### Future extensibility
The validation design is intended to support a future upgrade to a real AI provider through an interface-based validation service, without changing the external API contract.

## Example Integration Flow

1. Client sends draft ticket content to `POST /api/Tickets/validate`
2. API returns validation issues and suggestions
3. If the draft is acceptable, client submits the final ticket to `POST /api/Tickets`
4. If issues exist, the client shows suggestions before final submission

## Tech Stack

- ASP.NET Core Web API
- C#
- Swagger / OpenAPI
- Postman

## Repository Structure

```text
docs/
postman/
src/ApiContractDemo/
```

## Documentation

- [AI Validation Design](docs/ai-validation-design.md)
- [API Spec Draft](docs/api-spec-draft.md)
- [Integration Guide](docs/integration-guide.md)
- [Day 1 Setup Guide](docs/day1-setup.md)

## Run Locally

```bash
dotnet restore
dotnet run
```

## Notes

This stable version intentionally avoids Swagger example filters and other extra package-based enhancements. The current priority is a clean, working API contract demo with reliable OpenAPI output, Postman assets, and clear validation flow.

## Future Improvements

- replace mock AI validation with a real provider
- add SQL persistence
- add authentication
- add API versioning
- add Docker support
- deploy to Azure App Service
