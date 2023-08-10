using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class BlogPostCommentOnList
    {
        public string Content { get; set; }
        public DateTime DateAdded { get; set; }
        public string UserName { get; set; }
    }
}
