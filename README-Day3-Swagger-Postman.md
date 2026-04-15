# Day 3: Swagger Examples and Postman Collection

## What this step improves

This version improves the portfolio value of the project by making the API easier to understand and easier to test.

It adds:
- Swagger examples for request bodies
- clearer endpoint descriptions
- a cleaner Postman collection structure
- a stronger demo story for API contract clarity

## Important package to install

You need this NuGet package:

```bash
dotnet add package Swashbuckle.AspNetCore.Filters
```

## Optional XML comments setting

In your `.csproj`, enable XML documentation output:

```xml
<PropertyGroup>
  <GenerateDocumentationFile>true</GenerateDocumentationFile>
  <NoWarn>$(NoWarn);1591</NoWarn>
</PropertyGroup>
```

## Postman folders
- Tickets
- Validation

## What to test
1. Create Ticket - Valid
2. Get All Tickets
3. Get Ticket By ID
4. Update Ticket Status
5. Validate Ticket - Poor Content
6. Validate Ticket - Invalid Email
