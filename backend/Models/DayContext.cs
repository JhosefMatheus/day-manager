using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class DayContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }
    public DbSet<TaskTypeModel> TaskTypes { get; set; }
    public DbSet<TaskDayModel> TaskDays { get; set; }
    public DbSet<TaskSpecificDayModel> TaskSpecificDays { get; set; }

    public DayContext(DbContextOptions<DayContext> options) : base(options)
    {
    }
}