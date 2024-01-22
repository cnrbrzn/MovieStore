using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Commands.UpdateActor
{
    public class UpdateActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        public UpdateActorModel Model { get; set; }
        public int ActorId { get; set; }
        public UpdateActorCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x=> x.Id == ActorId);
            if(actor is null)
                throw new InvalidOperationException("Güncellenecek oyuncu zaten bulunamadı!");
            actor.FirstName = Model.FirstName != default ? Model.FirstName : actor.FirstName;
            actor.LastName = Model.LastName != default ? Model.LastName : actor.LastName;
            _context.SaveChanges();
        }
    }
    public class UpdateActorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}