using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatdAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BaseEntity() { 
            CreatdAt = DateTime.UtcNow;
        }

    }
}
