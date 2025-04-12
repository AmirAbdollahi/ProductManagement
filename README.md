# Product Management
This repository contains a sample .NET web application that demonstrates the implementation of a CRUD system for product management. It covers the software architecture, unit testing, integration testing, and includes Swagger documentation for ease of use.

## Features
* CRUD Operations: Perform Create, Read, Update, and Delete actions on products.
* Swagger Documentation: Easily interact with the API endpoints using Swagger UI.
* Unit and Integration Tests: Ensure the functionality and reliability of the system through automated tests.
* ASP.NET Core: Utilizes the power of ASP.NET Core for building the web API.
* SQL Server: Backend data is stored in a SQL Server database.

## Technologies Used
* Backend: ASP.NET Core
* Database: SQL Server
* Testing: xUnit (Unit Tests), integration tests
* API Documentation: Swagger
* ORM: Entity Framework Core

## Setup
Prerequisites
1. .NET SDK: v8.0 or higher
2. SQL Server: A running SQL Server instance
3. Visual Studio/Code: For easy development and debugging

## Installation
1. Clone the repository:

```
git clone https://github.com/AmirAbdollahi/ProductManagement.git
cd ProductManagement
```
2. Restore the project dependencies:

```
dotnet restore
```
3. Set up the SQL Server database and configure the connection string in appsettings.json.

4. Apply migrations to set up the database schema:

```
dotnet ef database update
```
5. Run the application:

```
dotnet run
```

## Accessing the API
Once the application is running, you can navigate to the following URL to view the Swagger UI for API documentation:

```
http://localhost:5000/swagger
```
## Running Tests
You can run the unit tests and integration tests with the following command:

```
dotnet test
```
Contributing
1. Fork this repository.
2. Create a new branch.
3. Make your changes.
4. Submit a pull request.

Please follow the coding standards and ensure that the tests pass before submitting a PR.

## License
This project is licensed under the MIT License.
