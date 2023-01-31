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
    public List<string> Savory { get; set; }
    public List<string> Sweet { get; set; }

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