using Microsoft.EntityFrameworkCore;
using TodoList.API.Models;

namespace TodoList.API.Data;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options) : base(options) { }

    public DbSet<Todo> Todos { get; set; }
    public DbSet<User> Users { get; set; }

}
