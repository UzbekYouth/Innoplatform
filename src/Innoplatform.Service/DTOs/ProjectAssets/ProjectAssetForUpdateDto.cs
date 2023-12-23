using Innoplatform.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Service.DTOs.ProjectAssets
{
    public class ProjectAssetForUpdateDto
    {
        public IFormFile File { get; set; }
    }
}
