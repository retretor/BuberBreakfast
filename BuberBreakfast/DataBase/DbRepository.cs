using BuberBreakfast.Models;
using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.DataBase;

public class DbRepository
{
    private readonly BreakfastContext _context;
    
    public DbRepository()
    {
        _context = new BreakfastContext(new DbContextOptions<BreakfastContext>());
        _context.Database.EnsureCreated();
    }
    
    public void SaveBreakfast(Breakfast breakfast)
    {
        if(_context.Breakfasts.Any())
        {
            var existingBreakfast = _context.Breakfasts.FirstOrDefault(b => b.Id == breakfast.Id);
            if (existingBreakfast != null)
            {
                Console.WriteLine("Breakfast already exists: " + breakfast.Id);
                return;
            }
        }
        Console.WriteLine("Adding breakfast: " + breakfast.Id);
        var newBreakfast = new Breakfast(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            DateTime.UtcNow,
            breakfast.Savories,
            breakfast.Sweets);
        _context.Breakfasts.Add(newBreakfast);
        foreach (var savory in breakfast.Savories) _context.Savories.Add(savory);
        foreach (var sweet in breakfast.Sweets) _context.Sweets.Add(sweet);
        _context.SaveChanges();
        Console.WriteLine("Saved breakfasts");
    }
    
    public List<Breakfast> GetBreakfasts()
    {
        Console.WriteLine("Breakfasts: " + _context.Breakfasts.Count());
        var breakfasts = _context.Breakfasts.ToList();
        foreach (var breakfast in breakfasts)
        {
            var savories = _context.Savories.Where(s => s.Breakfast == breakfast).ToList();
            var sweets = _context.Sweets.Where(s => s.Breakfast == breakfast).ToList();
            breakfast.Savories = savories;
            breakfast.Sweets = sweets;
        }
        return breakfasts;
    }
    public Breakfast? GetBreakfast(Guid id)
    {
        var breakfast = _context.Breakfasts.FirstOrDefault(b => b.Id == id) ?? null;
        if (breakfast == null) return null;
        var savories = _context.Savories.Where(s => s.Breakfast == breakfast).ToList();
        var sweets = _context.Sweets.Where(s => s.Breakfast == breakfast).ToList();
        return new Breakfast(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            savories,
            sweets);
    }

    public void ClearBreakfasts()
    {
        if(_context.Breakfasts.Any())
        {
            _context.Breakfasts.RemoveRange(_context.Breakfasts);
            _context.Savories.RemoveRange(_context.Savories);
            _context.Sweets.RemoveRange(_context.Sweets);
        }
        _context.SaveChanges();
    }

    public void UpdateBreakfast(Breakfast breakfast, Breakfast newBreakfast)
    {
        var existingBreakfast = _context.Breakfasts.FirstOrDefault(b => b.Id == breakfast.Id);
        if (existingBreakfast == null)
        {
            Console.WriteLine("Breakfast does not exist: " + breakfast.Id);
            return;
        }
        Console.WriteLine("Updating breakfast: " + breakfast.Id);
        _context.Breakfasts.Remove(existingBreakfast);
        _context.Breakfasts.Add(newBreakfast);
        _context.SaveChanges();
        Console.WriteLine("Updated breakfasts");
    }
    
    public void DeleteBreakfast(Guid id)
    {
        var existingBreakfast = _context.Breakfasts.FirstOrDefault(b => b.Id == id);
        if (existingBreakfast == null)
        {
            Console.WriteLine("Breakfast does not exist: " + id);
            return;
        }
        Console.WriteLine("Deleting breakfast: " + id);
        _context.Breakfasts.Remove(existingBreakfast);
        _context.SaveChanges();
        Console.WriteLine("Deleted breakfasts");
    }
}