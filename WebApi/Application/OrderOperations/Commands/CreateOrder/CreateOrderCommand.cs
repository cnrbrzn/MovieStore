using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.OrderOperations.Commands.CreateOrder
{
    public class CreateOrderCommand
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateOrderModel Model { get; set; }

        public CreateOrderCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var order = _mapper.Map<Order>(Model);
            order.Customer = _context.Customers.SingleOrDefault(x=> x.Id == Model.CustomerId);
            order.Movie = _context.Movies.SingleOrDefault(x=> x.Id == Model.MovieId);
            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }

    public class CreateOrderModel
    {
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
        public DateTime PurchaseDate { get; set; } = DateTime.Now.Date;
        public float TotalPrice { get; set; }

    }
}
