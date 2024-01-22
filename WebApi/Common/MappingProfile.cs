using System.Linq;
using AutoMapper;
using WebApi.Application.ActorOperations.Commands.CreateActor;
using WebApi.Application.ActorOperations.Queries;
using WebApi.Application.CustomerOperations.Commands.CreateCustomer;
using WebApi.Application.DirectorOperations.Commands.CreateDirector;
using WebApi.Application.DirectorOperations.Queries;
using WebApi.Application.MovieOperations.Commands.CreateMovie;
using WebApi.Application.MovieOperations.Queries.GetMovieDetail;
using WebApi.Application.MovieOperations.Queries.GetMovies;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.Application.OrderOperations.Queries;
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
            CreateMap<CreateCustomerModel, Customer>();
            CreateMap<Order, GetOrderByCustomerIdViewModel>().ForMember(dest=> dest.Customer, opt=> opt.MapFrom(src=> src.Customer.FirstName + " " + src.Customer.LastName))
            .ForMember(dest => dest.Movie, opt=> opt.MapFrom(src=> src.Movie.Name));
            CreateMap<Order, OrderDetailViewModel>().ForMember(dest=> dest.Customer, opt=> opt.MapFrom(src=> src.Customer.FirstName + " " + src.Customer.LastName))
            .ForMember(dest => dest.Movie, opt=> opt.MapFrom(src=> src.Movie.Name));
            CreateMap<Director, DirectorsViewModel>();
            CreateMap<CreateDirectorModel, Director>();
            CreateMap<Actor, ActorsViewModel>();
            CreateMap<CreateActorModel, Actor>();
            CreateMap<CreateOrderModel, Order>();
        }
    }
}