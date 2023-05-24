using Application.Dto.BoxSaving;
using Domain.Entities;

namespace Application.Interfaces.BoxSavings
{
    public interface ICreateBoxSavingService
    {
        Task Create(Guid userId, CreateBoxSavingDto createBoxSavingDto, CancellationToken cancellationToken);
    }
}
