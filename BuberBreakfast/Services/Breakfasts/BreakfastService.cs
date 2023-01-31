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
        return DbRepository.GetBreakfasts().Find(b => b.Id == id);
    }

    public Breakfast? UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        if (DbRepository.GetBreakfasts().All(b => b.Id != id)) return null;
        var newBreakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);
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