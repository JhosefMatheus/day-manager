using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("task_type")]
[Index(nameof(Name), IsUnique = true)]
public class TaskTypeModel
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [Required]
    public string Name { get; set; }

    public ICollection<TaskModel> Tasks { get; set; }
}