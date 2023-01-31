using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Models;

public class Breakfast
{
    [Key]
    public Guid Id;
    public string Name;
    public string Description;
    public DateTime StartDateTime;
    public DateTime EndDateTime;
    public DateTime LastModifiedDateTime;
    public readonly List<string> Savory;
    public readonly List<string> Sweet;

    public Breakfast(
        Guid id,
        string name,
        string description,
        DateTime startDateTime,
        DateTime endDateTime, 
        DateTime lastModifiedDateTime,
        List<string> savory,
        List<string> sweet)
    {
        Id = id;
        Name = name;
        Description = description;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        LastModifiedDateTime = lastModifiedDateTime;
        Savory = savory;
        Sweet = sweet;
    }

    public Breakfast()
    {
        Console.WriteLine("Creating new empty breakfast");
    }
    // public Breakfast()
    // {
    //     Console.WriteLine("Creating new empty breakfast");
    //     Id = Guid.NewGuid();
    //     Name = "";
    //     Description = "";
    //     StartDateTime = DateTime.UtcNow;
    //     EndDateTime = DateTime.UtcNow;
    //     LastModifiedDateTime = DateTime.UtcNow;
    //     Savory = new List<string>();
    //     Sweet = new List<string>();
    // }
}