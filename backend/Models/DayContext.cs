using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public class DayContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }

    public DayContext(DbContextOptions<DayContext> options) : base(options)
    {
    }
}