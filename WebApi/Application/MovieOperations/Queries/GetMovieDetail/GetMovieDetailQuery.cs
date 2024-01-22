using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Queries.GetMovieDetail
{
    public class GetMovieDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int MovieId { get; set; }

        public GetMovieDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public MovieDetailViewModel Handle()
        {
            var movie = _context.Movies.Include(x=> x.Genre).Include(x=> x.Director).Include(x=> x.ActorMovieJoint).ThenInclude(x => x.Actor).SingleOrDefault(x=> x.Id == MovieId);
            var actors = _context.ActorMovieJoints.Where(x=> x.MovieId == MovieId).ToList();
            if(movie is null)
            throw new InvalidOperationException("Film bulunamadı!");
            MovieDetailViewModel vm = _mapper.Map<MovieDetailViewModel>(movie);
            return vm;
        }
    }

    public class MovieDetailViewModel
    {
        public string Name { get; set; }
        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Price { get; set; }
        public List<string> Actors { get; set; }
    }
}