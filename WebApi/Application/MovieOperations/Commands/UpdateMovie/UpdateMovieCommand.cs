using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.MovieOperations.Commands.UpdateMovie
{
    public class UpdateMovieCommand
    {
        public readonly IMovieStoreDbContext _context;

        public UpdateMovieModel Model { get; set; }
        public int MovieId { get; set; }

        public UpdateMovieCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == MovieId);
            if(movie is null)
            {
                throw new InvalidOperationException("Güncellenecek film bulunamadı!");
            }
            movie.Name = Model.Name != default ? Model.Name : movie.Name;
            movie.ReleaseDate = Model.ReleaseDate != default ? Model.ReleaseDate : movie.ReleaseDate;
            movie.GenreID = Model.GenreID != default ? Model.GenreID : movie.GenreID;
            movie.DirectorID = Model.DirectorID != default ? Model.DirectorID : movie.DirectorID;
            movie.Price = Model.Price != default ? Model.Price : movie.Price;
            _context.SaveChanges();
        }
    }
    public class UpdateMovieModel
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int GenreID { get; set; }
        public int DirectorID { get; set; }
        public float Price { get; set; }
    }
}