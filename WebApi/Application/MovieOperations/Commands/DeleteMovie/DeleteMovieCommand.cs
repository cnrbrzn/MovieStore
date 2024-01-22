using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Commands.DeleteMovie
{
    public class DeleteMovieCommand
    {
        public int MovieId { get; set; }
        public readonly IMovieStoreDbContext _context;

        public DeleteMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x=> x.Id == MovieId);
            if(movie is null)
            throw new InvalidOperationException("Silinecek film bulunamadı!");
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }
    }
}