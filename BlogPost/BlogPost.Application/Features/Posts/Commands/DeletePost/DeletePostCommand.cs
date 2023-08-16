using BlogPost.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommand : BaseCommand
    {
        public int Id { get; set; }
    }
}
