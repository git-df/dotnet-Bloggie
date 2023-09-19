using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ListBlogPostModel
    {
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public bool Visible { get; set; }
    }
}
