using AutoMapper;

namespace WebApplication1.Middlewares;
class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        CreateMap<CreateCommentDto, Comment>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
            if (srcMember is int value && value == 0) {
                return false;
            }
            return srcMember != null;
        }));
        
        CreateMap<CreatePostDto, Post>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
            if (srcMember is int value && value == 0) {
                return false;
            }
            return srcMember != null;
        }));

        CreateMap<UpdatePostsDto, Post>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>{
            if (srcMember is int value && value == 0) {
                return false;
            }
            return srcMember != null;
        }));
        CreateMap<UpdateCommentDto, Comment>().ReverseMap().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => {
            if (srcMember is int value && value == 0) {
                return false;
            }
            return srcMember != null;
        }));
    }    
}