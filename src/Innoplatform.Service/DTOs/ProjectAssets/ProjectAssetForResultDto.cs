using Innoplatform.Domain.Entities.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.ProjectAssets
{
    public class ProjectAssetForResultDto
    {
        public long Id { get; set; }
        public Project Project { get; set; }
        public string File { get; set; }
    }
}
