using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities;

public class InvestmentArea : Auditable
{
    public string Title { get; set; }
    public string Image { get; set; }
}
