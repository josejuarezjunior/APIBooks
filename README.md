# AppBooks API

Welcome to the AppBooks API! This is a Web API project developed with ASP.NET Core 8, allowing management of authors and books. The API provides CRUD functionalities to manage these entities.

## Table of Contents

- [AppBooks API](#appbooks-api)
  - [Table of Contents](#table-of-contents)
  - [Installation](#installation)
  - [Configuration](#configuration)
  - [Running the Application](#running-the-application)
  - [Endpoints](#endpoints)
    - [Authors](#authors)
    - [Books](#books)
  - [Contribution](#contribution)
  - [License](#license)

## Installation

To install and run this project locally, follow these steps:

1. Clone the repository:
    ```bash
    git clone https://github.com/your-username/AppBooks.git
    cd AppBooks
    ```

2. Make sure you have the [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) installed.

3. Restore project dependencies:
    ```bash
    dotnet restore
    ```

## Configuration

1. Configure the database. In the `appsettings.json` file, update the connection string to match your database environment:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AppBooksDb;Trusted_Connection=True;MultipleActiveResultSets=true"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft.AspNetCore": "Warning"
        }
      },
      "AllowedHosts": "*"
    }
    ```

2. Run the migrations to set up the database:
    ```bash
    dotnet ef database update
    ```

## Running the Application

To run the application, use the command:

    ```bash
    dotnet run
    ```

The API will be available at https://localhost:5001 or http://localhost:5000.

## Endpoints

### Authors
- GET /authors: Returns a list of all authors.
- GET /authors/{id}: Returns a specific author by ID.
- POST /authors: Creates a new author. (Request Body JSON format provided)
- PUT /authors/{id}: Updates an existing author. (Request Body JSON format provided)
- PATCH /authors/{id}: Marks an author as deleted.

### Books
- GET /books: Returns a list of all books.
- GET /books/{id}: Returns a specific book by ID.
- POST /books: Creates a new book. (Request Body JSON format provided)
- PUT /books/{id}: Updates an existing book. (Request Body JSON format provided)
- PATCH /books/{id}: Marks a book as deleted.

## Contribution
Contributions are welcome! Feel free to open issues and pull requests.

1. Fork the repository
2. Create your feature branch (git checkout -b feature/fooBar)
3. Commit your changes (git commit -m 'Add some fooBar')
4. Push to the branch (git push origin feature/fooBar)
5. Create a new Pull Request

## License
Distributed under the MIT License. See LICENSE for more information.