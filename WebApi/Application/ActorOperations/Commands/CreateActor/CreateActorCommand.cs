using System;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Commands.CreateActor
{
    public class CreateActorCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateActorModel Model { get; set; }
        public CreateActorCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var actor = _context.Actors.SingleOrDefault(x=> x.FirstName == Model.FirstName && x.LastName == Model.LastName);
            if(actor != null)
                throw new InvalidOperationException("Oyuncu zaten mevcut!");
            actor = _mapper.Map<Actor>(Model);
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }
    }
    public class CreateActorModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}