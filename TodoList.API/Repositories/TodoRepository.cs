using Microsoft.EntityFrameworkCore;
using TodoList.API.Data;
using TodoList.API.Models;

namespace TodoList.API.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly TodoContext _context;

    public TodoRepository(TodoContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Todo>> GetTodos()
    {
        return await _context.Todos.ToListAsync();
    }

    public async Task<Todo> GetTodoById(int id)
    {
        return await _context.Todos.FindAsync(id);
    }

    public async Task<Todo> GetTodoByTitle(string title)
    {
        return await _context.Todos.FirstOrDefaultAsync(t => t.Title == title);
    }

    public async Task<IEnumerable<Todo>> GetTodosByUserId(int userId)
    {
        return await _context.Todos.Where(t => t.UserId == userId).ToListAsync();
    }

    public async Task CreateTodo(Todo todo)
    {
        await _context.Todos.AddAsync(todo);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateTodo(Todo todo)
    {
        _context.Entry(todo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTodo(int id)
    {
        var todo = await _context.Todos.FindAsync(id);
        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();
    }
}
