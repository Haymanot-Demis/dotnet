using AutoMapper;
using BlogPost.Application.DTO;
using BlogPost.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPost.Application.MappingProfile
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<CreatePostDTO, Post>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
                if (srcMember is int value && value == 0)
                {
                    return false;
                }
                return srcMember != null;
            }));

            CreateMap<UpdatePostDTO, Post>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
                if (srcMember is int value && value == 0)
                {
                    return false;
                }
                return srcMember != null;
            }));


            CreateMap<CreateCommentDTO, Comment>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
                if (srcMember is int value && value == 0)
                {
                    return false;
                }
                return srcMember != null;
            }));


            CreateMap<UpdateCommentDTO, Comment>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
                if (srcMember is int value && value == 0)
                {
                    return false;
                }
                return srcMember != null;
            }));
        }
    }
}
