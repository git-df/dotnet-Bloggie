﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public BlogPost BlogPost { get; set; }
        public Guid BlogPostId { get; set; }
    }
}
