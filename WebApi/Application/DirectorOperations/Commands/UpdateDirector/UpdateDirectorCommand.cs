using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Commands.UpdateDirector
{
    public class UpdateDirectorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public UpdateDirectorModel Model { get; set; }
        public int DirectorId { get; set; }
        public UpdateDirectorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var director = _context.Directors.SingleOrDefault(x=> x.Id == DirectorId);
            if(director is null)
                throw new InvalidOperationException("Güncellenecek oyuncu zaten bulunamadı!");
            director.FirstName = Model.FirstName != default ? Model.FirstName : director.FirstName;
            director.LastName = Model.LastName != default ? Model.LastName : director.LastName;
            _context.SaveChanges();
        }
    }
    public class UpdateDirectorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}