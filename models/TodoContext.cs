using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options)
    {
    }

    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.ToTable("TODOITEM", "WEBSITE");

            entity.Property(p => p.Id).HasColumnName("ID");
            entity.Property(p => p.Name).HasColumnName("NAME");
            entity.Property(p => p.IsComplete).HasColumnName("ISCOMPLETE");
        });
    }
}