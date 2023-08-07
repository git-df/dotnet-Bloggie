using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class AddBlogPostLikeModel
    {
        public Guid BlogPostId { get; set; }
        public Guid UserId { get; set; }
    }
}
