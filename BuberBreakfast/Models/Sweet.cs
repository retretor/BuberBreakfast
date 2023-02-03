using System.ComponentModel.DataAnnotations;

namespace BuberBreakfast.Models;

public class Sweet
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public Breakfast Breakfast { get; set; }
}