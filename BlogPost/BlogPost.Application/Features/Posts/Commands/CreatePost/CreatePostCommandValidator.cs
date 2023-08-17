using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator() { 
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title id required").Length(2, 50).WithMessage("Title length must be between 10 and 50");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required").MinimumLength(10).WithMessage("Content length must be more 10 chars");
        }
    }
}
