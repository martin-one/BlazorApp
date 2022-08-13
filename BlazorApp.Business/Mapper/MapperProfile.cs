using AutoMapper;
using BlazorApp.DataAccess;
using BlazorApp.Models;

namespace BlazorApp.Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
