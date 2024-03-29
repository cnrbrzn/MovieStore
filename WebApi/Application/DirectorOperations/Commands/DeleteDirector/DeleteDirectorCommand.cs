using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.DirectorOperations.Commands.DeleteDirector
{
    public class DeleteDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int DirectorId { get; set; }
        public DeleteDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x=> x.Id == DirectorId);
            if(director is null)
                throw new InvalidOperationException("Silinecek oyuncu bulunamadı!");
            _context.Directors.Remove(director);
            _context.SaveChanges();
        }
    }
}