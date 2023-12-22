using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities;

public class ProjectAsset:Auditable
{
    public long ProjectId { get; set; }
    public string File {  get; set; }
}
