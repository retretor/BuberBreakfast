using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;

namespace BuberBreakfast.Services.Breakfasts;

public class BreakfastService : IBreakfastService
{
    private static readonly Dictionary<Guid, Breakfast> Breakfasts = new Dictionary<Guid, Breakfast>();
    public void CreateBreakfast(Breakfast breakfast)
    {
        Breakfasts.Add(breakfast.Id, breakfast);
    }

    public Breakfast? GetBreakfast(Guid id)
    {
        return Breakfasts.TryGetValue(id, out var breakfast) ? breakfast : null;
    }

    public Breakfast? UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        if (!Breakfasts.ContainsKey(id)) return null;
        var newBreakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet);
        Breakfasts[id] = newBreakfast;
        return newBreakfast;

    }

    public void DeleteBreakfast(Guid id)
    {
        Breakfasts.Remove(id);
    }
}