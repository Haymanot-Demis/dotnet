using AutoMapper.Configuration.Conventions;
using BlogPost.Application.Features.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Comments.Commands.DeleteComment
{
    public class DeleteCommentCommand : BaseCommand
    {
        public int Id { get; set; }
    }
}
