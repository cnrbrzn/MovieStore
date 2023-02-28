using System.Linq;
using AutoMapper;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Entities;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MoviesViewModel>().ForMember(dest=> dest.Genre, opt => opt.MapFrom(src=> src.Genre.Name))
                                                .ForMember(dest=> dest.Director, opt => opt.MapFrom(src=> src.Director.FirstName + " " + src.Director.LastName));
            
            CreateMap<Movie, MovieDetailViewModel>().ForMember(dest=> dest.Genre, opt => opt.MapFrom(src=> src.Genre.Name))
                                                    .ForMember(dest=> dest.Director, opt => opt.MapFrom(src=> src.Director.FirstName + " " + src.Director.LastName))
                                                    .ForMember(dest => dest.Actors, opt => opt.MapFrom(src=> src.ActorMovieJoint.Select(x => x.Actor.FirstName + " " + x.Actor.LastName)));
            CreateMap<CreateMovieModel, Movie>();
        }
    }
}