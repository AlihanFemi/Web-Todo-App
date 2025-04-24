# A simple Todo application using a .NET layered architecture with a frontend, a Web API backend, and a DB. Supports Docker-based deployment.


## Architecture

- **Todo.Domain**: Core business entities and interfaces.  
- **Todo.Infrastructure**: Data access implementation using Entity Framework Core and SQL-Lite.  
- **Todo.Application**: Application services, DTOs, and business logic.  
- **Todo.Web.Api**: ASP.NET Core Web API exposing RESTful endpoints.  
- **Todo.Web**: Frontend UI.  


## Prerequisites

- .NET 6 SDK
- Docker & Docker Compose


## Getting Started

### Run with Docker

```bash
docker-compose up --build
```
- API available at http://localhost:5000  
- UI available at http://localhost:5001  


## API Endpoints

### Todo Lists
| Method | Route                  | Description               |
| ------ | ---------------------- | ------------------------- |
| GET    | /api/TodoList/GetById/{id} | Get a single todo list  |
| GET    | /api/TodoList/GetAll    |  List all todo lists   |
| POST   | /api/TodoList/CreateTodoList      | Create a new todo list    |
| PUT    | /api/TodoList/UpdateTodoList/{id}    | Update an existing list   |
| DELETE | /api/TodoList/DeleteTodoList/{id}    | Delete a todo list        |

### Todo Tasks
| Method | Route                  | Description                   |
| ------ | ---------------------- | ----------------------------- |
| GET    | /api/TodoTask/GetById/{id} |  Get a single todo task       |
| GET    | /api/TodoTask/GetAll   |  List all todo tasks          |
| POST   | /api/TodoTask/CreateTodoTask        | Create a new todo task        |
| PUT    | /api/TodoTask/UpdateTodoTask/{id}   | Update an existing todo task  |
| DELETE | /api/TodoTask/DeleteTodoTask/{id}    | Delete a todo task            |

### Users
| Method | Route               | Description               |
| ------ | ------------------- | ------------------------- |
| GET    | /api/User/GetById/{id}        |  Get a single user        |
| GET    | /api/User/GetAll    |  List all users           |
| POST   | /api/User/CreateUser | Create a new user         |
| POST   | /api/User/ValidatePassword | Validates the password of a user |
| PUT    | /api/User/UpdateUser/{id} | Update an existing user   |
| DELETE | /api/User/DeleteUser/{id}    | Delete a user             |

## Frontend

- Reads/writes via `WEB_API_URL` env var (default: `http://web-api-todo/`)  
- Implements listing, creation, editing, and deletion of tasks.
