﻿using BlogPost.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<Post>
    {
        public int Id { get; set;}
        public string? Title { get; set;}
        public string? Content { get; set;}
    }
}
