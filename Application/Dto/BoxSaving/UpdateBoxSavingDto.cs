
using Domain.Entities;

namespace Application.Dto.BoxSaving;

public class UpdateBoxSavingDto
{
    public int Multiplier { get; set; }
    public IEnumerable<Saving> NewSavings { get; set; }
}


