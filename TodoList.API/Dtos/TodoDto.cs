using System.ComponentModel.DataAnnotations;

namespace TodoList.API.Dtos;

public class TodoDto
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Title { get; set; }

    [Required]
    public required string Description { get; set; }

    public bool IsCompleted { get; set; } = false;
}

