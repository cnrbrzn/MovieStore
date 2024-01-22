using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.DirectorOperations.Queries
{
    public class GetDirectorsQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetDirectorsQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<DirectorsViewModel> Handle()
        {
            var directors = _context.Directors.OrderBy(x=> x.Id).ToList<Director>();
            List<DirectorsViewModel> vm = _mapper.Map<List<DirectorsViewModel>>(directors);
            return vm;
        }
    }
    public class DirectorsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}