using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Queries
{
    public class GetOrderDetailQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public int OrderId { get; set; }

        public GetOrderDetailQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public OrderDetailViewModel Handle()
        {
            var orders = _context.Orders.Include(x=> x.Customer).Include(x=> x.Movie).SingleOrDefault(x=> x.Id == OrderId);
            OrderDetailViewModel vm = _mapper.Map<OrderDetailViewModel>(orders);
            return vm;
        }
    }

    public class OrderDetailViewModel
    {
        public string Customer { get; set; }
        public string Movie { get; set; }
        public string PurchaseDate { get; set; }
        public float TotalPrice { get; set; }
        public string IsActive { get; set; }
    }
}