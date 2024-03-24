using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("task_specific_day")]
[Index(nameof(TaskId), nameof(Day), IsUnique = true)]
public class TaskSpecificDayModel
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("TaskModel")]
    [Column("task_id")]
    [Required]
    public int TaskId { get; set; }
    public TaskModel Task { get; set; }

    [Column("day")]
    [Required]
    public DateOnly Day { get; set; }
}