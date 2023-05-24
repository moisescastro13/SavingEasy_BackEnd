
using System.Data;

namespace Domain.Entities;

public class BoxSaving: Entity<BoxSavingId>
{
    private readonly HashSet<Saving> _savings = new();
    public int Total { get; set; }
    public UserId userId { get; set; }
    public IReadOnlyCollection<Saving> savings => _savings;
    internal BoxSaving(int total): base()
    {
        Total = total;
    }
    public BoxSaving(int total, UserId userId, BoxSavingId id): this(total)
    {
        Id = id;
        this.userId = userId;
    }
    internal static BoxSaving Create( UserId userId, BoxSavingId id, int multiplier)
    {
        var savingValues = Enumerable.Range(1, 100).Select(x => new Saving(x * multiplier, false)).ToList();
        var totalSaving = 0;

        var boxSaving = new BoxSaving(totalSaving, userId, new BoxSavingId(Guid.NewGuid()));

        foreach (var saving in savingValues)
        {
            boxSaving.AddSaving(saving);
        }
        return boxSaving;
    }
    private void AddSaving(Saving saving)
    {
        _savings.Add(saving);
    }
    public void UpdateSaving(IEnumerable<Saving> savings)
    {
        _savings.Clear();
        savings.OrderBy(x => x.number).ToList().ForEach(x => _savings.Add(x));
    }
}
