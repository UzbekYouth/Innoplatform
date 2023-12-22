﻿using Innoplatform.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innoplatform.Domain.Entities
{
    public class Mentor :Auditable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Image {  get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
    }
}
