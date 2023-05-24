
using Application.Dto.BoxSaving;
using Application.Interfaces;
using Application.Interfaces.BoxSavings;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.BoxSavings;

public class UpdateBoxSavingService : IUpdateBoxSavingService
{
    private readonly IApplicationDbContext _context;

    public UpdateBoxSavingService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Update(Guid userId, Guid boxId, UpdateBoxSavingDto updateBoxSavingDto, CancellationToken cancellationToken = default)
    {
        var id = new UserId(userId);
        var boxSavingId = new BoxSavingId(boxId);
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

        if (user is null)
        {
            return;
        }

        user.UpdateBoxSavings(updateBoxSavingDto.Multiplier, boxSavingId, updateBoxSavingDto.NewSavings);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
