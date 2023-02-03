using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Models;

public class Breakfast
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public DateTime LastModifiedDateTime { get; set; }
    public List<Savory> Savories { get; set; }
    public List<Sweet> Sweets { get; set; }

    public Breakfast(
        Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime, 
        DateTime lastModifiedDateTime,
        List<Savory> savory,
        List<Sweet> sweet)
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savories = savory;
        Sweets = sweet;
    }

    public Breakfast()
    {
        Console.WriteLine("Creating new breakfast");
    }
}