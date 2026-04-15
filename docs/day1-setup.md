# Day 1 Setup Guide

## Day 1 goals

- create the GitHub repository
- create an ASP.NET Core Web API project
- enable Swagger / OpenAPI
- build the first ticket endpoints

## Step 1: Create the GitHub repository

Suggested repository name:

`api-contract-demo`

## Step 2: Create the ASP.NET Core Web API project

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

## Step 3: Run the project

```bash
dotnet run
```

Check that Swagger UI opens successfully.

## Step 4: Clean the default template

Delete:
- `WeatherForecast.cs`
- `WeatherForecastController.cs`

## Step 5: Build the first API shape

Create these endpoint targets:
- `POST /api/tickets`
- `GET /api/tickets`
- `GET /api/tickets/{id}`
- `PATCH /api/tickets/{id}/status`
- `POST /api/tickets/validate`

## Step 6: Create your first commit

```bash
git init
git add .
git commit -m "Initialize ASP.NET Core Web API project with Swagger"
```

## Day 1 output

By the end of Day 1, you should have:
- a GitHub repo
- a running ASP.NET Core Web API
- Swagger enabled
- ticket endpoint skeletons
- first commit created
