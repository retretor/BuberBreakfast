using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.DataBase;
using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{
    private static readonly DbRepository DbRepository = new DbRepository();
    public void CreateBreakfast(Breakfast breakfast)
    {
        DbRepository.SaveBreakfast(breakfast);
    }

    public Breakfast? GetBreakfast(Guid id)
    {
        var breakfast = DbRepository.GetBreakfast(id);
        
        return breakfast;
    }

    public Breakfast? UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        if (DbRepository.GetBreakfasts().All(b => b.Id != id)) return null;
        var savory = request.Savory.Select(s => new Savory { Name = s }).ToList();
        var sweet = request.Sweet.Select(s => new Sweet { Name = s }).ToList();
        var newBreakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            savory,
            sweet);
        DbRepository.UpdateBreakfast(GetBreakfast(id)!, newBreakfast);
        return newBreakfast;
    }

    public void DeleteBreakfast(Guid id)
    {
        DbRepository.DeleteBreakfast(id);
    }
    public void ClearBreakfasts()
    {
        DbRepository.ClearBreakfasts();
    }

    public List<Breakfast> GetBreakfasts()
    {
        return DbRepository.GetBreakfasts();
    }
}