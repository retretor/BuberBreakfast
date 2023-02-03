using System.Data.Entity;
using BuberBreakfast.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace BuberBreakfast.DataBase;

[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
public class BreakfastContext : DbContext
{
    public Microsoft.EntityFrameworkCore.DbSet<Breakfast> Breakfasts { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Savory> Savories { get; set; }
    public Microsoft.EntityFrameworkCore.DbSet<Sweet> Sweets { get; set; }
    public BreakfastContext(DbContextOptions<BreakfastContext> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=192.168.0.103;port=3306;database=breakfasts;uid=retretor;password=Egoregor_09");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.Entity<Breakfast>()
        //     .HasMany(b => b.Savories)
        //     .WithOne(s => s.Breakfast);
        //
        // modelBuilder.Entity<Breakfast>()
        //     .HasMany(b => b.Sweets)
        //     .WithOne(s => s.Breakfast);
    }
}