using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Queries.GetMovies
{
    public class GetMoviesQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public GetMoviesQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<MoviesViewModel> Handle()
        {
            var movieList = _context.Movies.Include(x=> x.Genre).Include(x=> x.Director).OrderBy(x=> x.Id).ToList<Movie>();
            List<MoviesViewModel> vm = _mapper.Map<List<MoviesViewModel>>(movieList);
            return vm;
        }
    }

    public class MoviesViewModel
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Price { get; set; }
    }
}