using AutoMapper;
using Blogs_Api_DotNet.Models;

namespace Blogs_Api_DotNet.DTO.Mappings
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<User, LoginDTO>().ReverseMap();
        }
    }
}
