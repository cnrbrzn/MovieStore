using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.MovieOperations.Commands.CreateMovie
{
    public class CreateMovieCommand
    {
        public readonly IMovieStoreDbContext _context;
        public readonly IMapper _mapper;

        public CreateMovieModel Model { get; set; }

        public CreateMovieCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Name.ToLower() == Model.Name);
            if(movie != null)
            {
                throw new InvalidOperationException("Film zaten mevcut!");
            }
            movie = _mapper.Map<Movie>(Model);
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }
    }
    public class CreateMovieModel
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreID { get; set; }
        public int DirectorID { get; set; }
        public List<Actor> Actor { get; set; }
        public float Price { get; set; }
    }
}