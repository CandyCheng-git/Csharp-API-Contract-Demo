# Day 1 Setup Guide

## Day 1 Goals

- create the GitHub repository
- create an ASP.NET Core Web API project
- enable Swagger / OpenAPI
- build the first ticket endpoints

## Step 1: Create the GitHub Repository

Suggested repository name:

`api-contract-demo`

## Step 2: Create the ASP.NET Core Web API Project

### Visual Studio
1. Open Visual Studio
2. Click **Create a new project**
3. Select **ASP.NET Core Web API**
4. Set project name to `ApiContractDemo`
5. Choose .NET 8 if available
6. Enable **OpenAPI support**
7. Create the project

### CLI
```bash
mkdir api-contract-demo
cd api-contract-demo
dotnet new webapi -n ApiContractDemo
cd ApiContractDemo
```

## Step 3: Run the Project

```bash
dotnet run
```

Check that Swagger UI opens successfully.

## Step 4: Clean the Default Template

Delete:
- `WeatherForecast.cs`
- `WeatherForecastController.cs`

## Step 5: Build the First API Shape

Create these endpoint targets:
- `POST /api/Tickets`
- `GET /api/Tickets`
- `GET /api/Tickets/{id}`
- `PATCH /api/Tickets/{id}/status`
- `POST /api/Tickets/validate`

## Step 6: Create Your First Commit

```bash
git init
git add .
git commit -m "Initialize ASP.NET Core Web API project with Swagger"
```

## Day 1 Output

By the end of Day 1, you should have:
- a GitHub repo
- a running ASP.NET Core Web API
- Swagger enabled
- ticket endpoint skeletons
- first commit created
