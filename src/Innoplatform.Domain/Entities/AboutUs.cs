using Innoplatform.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Domain.Entities
{
    public class AboutUs:Auditable
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
