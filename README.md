# Ongkon API

Ongkon is a collaborative whiteboard platform that enables multiple users to draw and work together in real-time. This repository contains the backend API service that powers the collaborative features of Ongkon.

## About Ongkon

Ongkon provides a seamless collaborative drawing experience where:
- Multiple users can draw simultaneously on the same whiteboard
- Real-time synchronization of drawings and elements
- Support for various drawing elements including nodes, connectors, and annotations
- Cross-platform compatibility through a web-based interface

## Project Structure

The solution consists of the following projects:

- **Ongkon.Api**: The main API project containing controllers and API endpoints
- **Ongkon.Business**: Contains business logic and command/query handlers
- **Ongkon.Contracts**: Contains shared models, commands, and interfaces
- **Ongkon.Database**: Handles data access and database operations

## Prerequisites

- .NET 7.0 SDK or later
- MongoDB (for data storage)

## Features

- Real-time collaborative whiteboard functionality
- Multi-user support with concurrent editing
- Element manipulation (nodes, connectors)
- Node annotations and comments
- Real-time updates and synchronization
- CORS support for cross-origin requests
- Swagger/OpenAPI documentation

## Getting Started

1. Clone the repository
2. Navigate to the solution directory
3. Restore NuGet packages:
   ```
   dotnet restore
   ```
4. Run the application:
   ```
   dotnet run --project Ongkon.Api
   ```

The API will be available at `https://localhost:5001` and `http://localhost:5000` by default.

## API Documentation

Once the application is running, you can access the Swagger UI documentation at:
```
https://localhost:5001/swagger
```

## Architecture

The project follows a clean architecture pattern with the following components:

- **Commands**: Handle write operations (Create, Update, Delete)
- **Queries**: Handle read operations
- **Command/Query Handlers**: Implement the business logic
- **Repository Pattern**: Abstracts data access
- **MongoDB**: Used as the primary database

## Dependencies

- Microsoft.AspNetCore.OpenApi (7.0.10)
- Swashbuckle.AspNetCore (6.5.0)
- MongoDB.Driver

## Development

The project uses:
- C# 7.0+ features
- Nullable reference types
- Implicit using statements
- Clean architecture principles

## Contributing

1. Fork the repository
2. Create your feature branch
3. Commit your changes
4. Push to the branch
5. Create a new Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details.