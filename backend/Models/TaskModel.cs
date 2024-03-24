using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

[Table("task")]
[Index(nameof(Name), nameof(UserId), nameof(TypeId), IsUnique = true)]
public class TaskModel
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [ForeignKey("UserModel")]
    [Column("user_id")]
    public int UserId { get; set; }
    public UserModel User { get; set; }

    [ForeignKey("TaskTypeModel")]
    [Column("type_id")]
    public int TypeId { get; set; }
    public TaskTypeModel Type { get; set; }

    [Column("name")]
    [Required]
    public string Name { get; set; }

    #nullable enable
    [Column("description")]
    public string? Description { get; set; }
    #nullable disable

    [Column("done")]
    public bool Done { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    public ICollection<TaskDayModel> TaskDays { get; set; }

    public ICollection<TaskSpecificDayModel> TaskSpecificDays { get; set; }
}