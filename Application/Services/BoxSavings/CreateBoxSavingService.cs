using Application.Dto.BoxSaving;
using Application.Interfaces;
using Application.Interfaces.BoxSavings;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.BoxSavings;

public class CreateBoxSavingService: ICreateBoxSavingService
{
    private readonly IApplicationDbContext _context;

    public CreateBoxSavingService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Create(Guid userId, CreateBoxSavingDto createBoxSavingDto, CancellationToken cancellationToken = default)
    {
        var id = new UserId(userId);
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (user is null)
        {
            return;
        }

        user.AddBoxSaving(createBoxSavingDto.Multiplier);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
