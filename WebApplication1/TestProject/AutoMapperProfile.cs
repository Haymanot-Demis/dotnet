using AutoMapper;

public class AutomapperProfile: Profile{
    public AutomapperProfile(){
        CreateMap<Comment, CreateCommentDto>();
        CreateMap<CreateCommentDto, Comment>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Post, CreatePostDto>();
        CreateMap<CreatePostDto, Post>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

        CreateMap<Post, UpdatePostsDto>();
        CreateMap<UpdatePostsDto, Post>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        CreateMap<Comment, UpdateCommentDto>();
        CreateMap<UpdateCommentDto, Comment>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
}