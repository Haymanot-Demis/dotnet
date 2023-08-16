using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Posts.Commands.CreatePost
{
    public class CreatePostCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreatePostCommandValidator() { 
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title id required").Length(10, 50).WithMessage("Title length must be between 10 and 50");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Content is required").Length(10).WithMessage("Content length must be more 10n chars");
        }
    }
}
