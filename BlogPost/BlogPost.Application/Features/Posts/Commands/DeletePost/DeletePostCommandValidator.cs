using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Posts.Commands.DeletePost
{
    public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
    {
        public DeletePostCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("Post id can't be less than 1");
        }
    }
}
