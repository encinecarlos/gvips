using AutoMapper;
using Gvips.API.ViewModels;
using Gvips.Domain.Models;

namespace Gvips.API.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Post, PostViewModel>().ReverseMap();
        }
        
    }
}