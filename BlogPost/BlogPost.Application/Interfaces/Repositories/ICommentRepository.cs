using BlogPost.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Interfaces.Repositories
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
    }
}
