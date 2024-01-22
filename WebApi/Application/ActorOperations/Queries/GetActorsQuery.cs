using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.ActorOperations.Queries
{
    public class GetActorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetActorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<ActorsViewModel> Handle()
        {
            var actors = _context.Actors.OrderBy(x=> x.Id).ToList<Actor>();
            List<ActorsViewModel> vm = _mapper.Map<List<ActorsViewModel>>(actors);
            return vm;
        }
    }
    public class ActorsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}