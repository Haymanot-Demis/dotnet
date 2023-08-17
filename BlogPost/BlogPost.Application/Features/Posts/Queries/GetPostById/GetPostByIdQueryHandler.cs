using AutoMapper;
using BlogPost.Application.Exceptions;
using BlogPost.Application.Interfaces.Repositories;
using BlogPost.Domain.Entities;
using FluentValidation;
//using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.Features.Posts.Queries.GetPostById
{
    internal class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Post>
    {
        private readonly IPostRepository _postRespository;
        private readonly IMapper _mapper;
        //private readonly ILogger _logger;
        public GetPostByIdQueryHandler(IPostRepository postRespository, IMapper mapper)
        {
            _postRespository = postRespository;
            _mapper = mapper;
            //_logger = logger;
        }

        public Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetPostByIdQuery>(request);
            var validator = new GetPostByIdQueryValidator();
            var validationResult = validator.Validate(query);
            //_logger.LogInformation("Inside getbyid");

            if (!validationResult.IsValid)
            {
                //_logger.LogInformation("validation Error");
                throw new ValidationException(validationResult.Errors);
            }

            var post = _postRespository.GetByIdAsync(query.Id);

            if (post == null) 
            {
                //_logger.LogInformation("not found");
                throw new NotFoundException($"Object with id {query.Id} not found");
            }
            
            return post;
        }
    }
}
