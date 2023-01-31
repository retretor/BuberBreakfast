using BuberBreakfast.Models;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.DataBase;

public class BreakfastContext : DbContext
{
    public DbSet<Breakfast> Breakfasts { get; set; }
    public BreakfastContext(DbContextOptions<BreakfastContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BreakfastDb;Trusted_Connection=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Breakfast>().HasKey(b => b.Id);
    }
}