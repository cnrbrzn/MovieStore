using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.CustomerOperations.Commands.CreateCustomer
{
    public class CreateCustomerCommand
    {
        public CreateCustomerModel Model { get; set; }
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;
        public CreateCustomerCommand(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle()
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Email == Model.Email);
            if(customer != null)
            {
                throw new InvalidOperationException("Müşteri zaten mevcut!");
            }
            customer = _mapper.Map<Customer>(Model);
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }
    }
    public class CreateCustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}