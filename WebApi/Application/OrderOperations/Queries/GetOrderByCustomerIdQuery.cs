using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Queries
{
    public class GetOrderByCustomerIdQuery
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetOrderByCustomerIdQuery(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GetOrderByCustomerIdViewModel> Handle()
        {
            var orders = _context.Orders.Include(x=> x.Customer).Include(x=> x.Movie).OrderBy(x=> x.Id).ToList<Order>();
            List<GetOrderByCustomerIdViewModel> vm = _mapper.Map<List<GetOrderByCustomerIdViewModel>>(orders);
            return vm;
        }
    }
    public class GetOrderByCustomerIdViewModel
    {
        public string Customer { get; set; }
        public string Movie { get; set; }
        public string PurchaseDate { get; set; }
        public float TotalPrice { get; set; }
    }
}