using Application.Dto.BoxSaving;

namespace Application.Interfaces.BoxSavings
{
    public interface IUpdateBoxSavingService
    {
        Task Update(Guid userId, Guid boxId, UpdateBoxSavingDto updateBoxSavingDto, CancellationToken cancellationToken = default);
    }
}