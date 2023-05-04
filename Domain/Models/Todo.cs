using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Shared.Models;

public class Todo
{
    [Key]
    public int Id { get; set; }
    public User Owner { get; private set; }
    [MaxLength(50)]
    public string Title { get; private set; }
    public bool isCompleted { get; set; }

    public Todo(User owner, string title)
    {
        Owner = owner;
        Title = title;
    }
    
    private Todo(){}
  
}
