# TodoList API

Welcome to the TodoList API repository. This API allows you to manage your todos using a simple and intuitive interface. Below you'll find instructions on how to set up and use the API.

## Getting Started

To use this API, follow these steps:

1. **Clone the Repository:** Start by cloning this repository to your local machine.

2. **Install Dependencies:** Navigate to the project directory and install the required dependencies using the following command:

   bash
   dotnet restore
Configure the Database: Update the database connection string in the appsettings.json file to point to your preferred database.

Run Migrations: Apply the Entity Framework migrations to set up the database schema:

dotnet ef database update

dotnet run
Access the API: You can use tools like curl, Postman, or any API client to interact with the endpoints.

Endpoints
Get All Todos
Endpoint: GET /api/todos

Retrieve a list of all todos.

Get Todo by ID
Endpoint: GET /api/todos/{id}

Retrieve a specific todo by its ID.

Create Todo
Endpoint: POST /api/todos

Create a new todo. Provide the title and userId in the request body.

Update Todo
Endpoint: PUT /api/todos/{id}

Update an existing todo by its ID. Provide the updated todo details in the request body.

Delete Todo
Endpoint: DELETE /api/todos/{id}

Delete a todo by its ID.
