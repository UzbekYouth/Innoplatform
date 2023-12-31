﻿using Innoplatform.Domain.Commons;

namespace Innoplatform.Domain.Entities.Projects;

public class ProjectAsset : Auditable
{
    public long ProjectId { get; set; }
    public Project Project { get; set; }
    public string File { get; set; }
}
