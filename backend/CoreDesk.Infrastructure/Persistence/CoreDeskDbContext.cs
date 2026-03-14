using CoreDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreDesk.Infrastructure.Persistence;

public class CoreDeskDbContext : DbContext
{
    public CoreDeskDbContext(DbContextOptions<CoreDeskDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Project> Projects => Set<Project>();
    public DbSet<TaskItem> Tasks => Set<TaskItem>();
    public DbSet<Note> Notes => Set<Note>();
    public DbSet<Company> Companies => Set<Company>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(x => x.Email)
            .IsUnique();
    }
}