using AutoMapper;
using Webapi.Nc7.Movies.Models;
using Webapi.Nc7.Movies.Models.Dtos;

namespace Webapi.Nc7.Movies.MoviesMappers
{
    public class MovieMapper : Profile
    {
        public MovieMapper()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category,NewCategoryDto>().ReverseMap();
            CreateMap<Movie, MovieDto>().ReverseMap();
        }

    }
}
