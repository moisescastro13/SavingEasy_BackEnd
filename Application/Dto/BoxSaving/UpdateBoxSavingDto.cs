
using Domain.Entities;

namespace Application.Dto.BoxSaving;

public class UpdateBoxSavingDto
{
    public IEnumerable<Saving> NewSavings { get; set; }
}


