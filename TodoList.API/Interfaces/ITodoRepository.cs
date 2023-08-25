using TodoList.API.Models;

namespace TodoList.API.Repositories;

public interface ITodoRepository
{
    Task CreateTodo(Todo todo);
    Task<IEnumerable<Todo>> GetTodos();
    Task<Todo> GetTodoById(int id);
    Task<Todo> GetTodoByTitle(string title);
    Task UpdateTodo(Todo todo);
    Task DeleteTodo(int id);
}
