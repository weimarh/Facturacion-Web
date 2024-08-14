# Facturacion-Web

Overview
This document provides technical details about a C# web API project built on .NET 8, utilizing SQL Server as the data store, implementing OAuth for authentication, and adhering to the repository pattern for data access.
Project Structure

The project is organized into the following layers:
API: Contains controllers and API endpoints for interacting with the application.
Application: Houses application services that handle business logic.
Domain: Defines domain entities, value objects, and domain services.
Infrastructure: Implements data access, external services, and other infrastructure concerns.
Tests: Unit and integration tests for various components.

Technologies and Frameworks
.NET 8: Provides the core framework for the application.
ASP.NET Core Web API: Used to build the web API endpoints.
Entity Framework Core: ORM for data access to SQL Server.
OAuth: Authentication mechanism for securing API access.
Repository Pattern: Architectural pattern for data access abstraction.
MSTest: Testing frameworks for unit and integration tests.

Repository Pattern Implementation
The repository layer abstracts data access operations, providing a clean separation between the domain and data access logic. Repositories typically implement generic interfaces for CRUD operations.
