using System.ComponentModel.DataAnnotations;

namespace TodoList.API.Models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Email { get; set; }

    [Required]
    public required string PasswordHash { get; set; }

    public virtual ICollection<Todo>? Todos { get; set; }
}
