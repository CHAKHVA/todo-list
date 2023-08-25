﻿using System.ComponentModel.DataAnnotations;


namespace TodoList.API.Models;

public class Todo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Title { get; set; }

    [Required]
    public required string Description { get; set; }

    public bool IsCompleted { get; set; } = false;

    public int UserId { get; set; }
    public required User User { get; set; }
}
