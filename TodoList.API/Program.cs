using TodoList.API.Data;
using Microsoft.EntityFrameworkCore;
using TodoList.API.Repositories;
using TodoList.API.Dtos;
using TodoList.API.Models;
using TodoList.API.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.AddDbContext<TodoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var todosGroup = app.MapGroup("/todos");

// AuthController
app.MapPost("/api/register", async (IUserRepository userRepository, RegisterDto registerDto) =>
{
    if (await userRepository.GetUserByUsername(registerDto.Username) != null)
    {
        return Results.BadRequest("Username already exists.");
    }

    var newUser = new User
    {
        Username = registerDto.Username,
        PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password)
    };
    await userRepository.CreateUser(newUser);

    return Results.Created("User created.");
});

// TodoController
todosGroup.MapGet("/", async (ITodoRepository todoRepository) =>
{
    var todos = await todoRepository.GetTodos();
    if (todos == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(todos);
});

todosGroup.MapGet("/{id:int}", async (ITodoRepository todoRepository, int id) =>
{
    var todo = await todoRepository.GetTodoById(id);
    if (todo == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(todo);
})
.WithName("GetTodo");

todosGroup.MapGet("/{title}", async (ITodoRepository todoRepository, string title) =>
{
    var todo = await todoRepository.GetTodoByTitle(title);
    if (todo == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(todo);
});

/*todosGroup.MapGet("/users/{userId:int}", async (ITodoRepository todoRepository, int userId) =>
{
    var todos = await todoRepository.GetTodosByUserId(userId);
    return Results.Ok(todos);
});*/

todosGroup.MapPost("/", async (ITodoRepository todoRepository, TodoDto todoDto) =>
{
    var newTodo = new Todo
    {
        Title = todoDto.Title,
        Description = todoDto.Description,
        IsCompleted = false,
        //UserId = todoDto.UserId
    };
    await todoRepository.CreateTodo(newTodo);

    return Results.CreatedAtRoute("GetTodo", new { id = newTodo.Id }, newTodo);
});

todosGroup.MapPut("/{id:int}", async (ITodoRepository todoRepository, int id, TodoDto todoDto) =>
{
    var existingTodo = await todoRepository.GetTodoById(id);
    if (existingTodo == null)
    {
        return Results.NotFound();
    }

    existingTodo.Title = todoDto.Title;
    existingTodo.IsCompleted = todoDto.IsCompleted;
    await todoRepository.UpdateTodo(existingTodo);

    return Results.Ok();
});

todosGroup.MapDelete("/{id:int}", async (ITodoRepository todoRepository, int id) =>
{
    var existingTodo = await todoRepository.GetTodoById(id);
    if (existingTodo == null)
    {
        return Results.NotFound();
    }

    await todoRepository.DeleteTodo(id);

    return Results.NoContent();
});


app.Run();
