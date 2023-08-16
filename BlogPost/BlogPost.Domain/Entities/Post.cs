using BlogPost.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Entities
{
    public class Post : BaseEntity
    {
        public string? Title { get; set; }   
        public string? Content { get; set; } 
        public ICollection<Comment>? Comments { get; set; }

        public Post() 
        { 
            Comments = new List<Comment>();
        }
    }
}
