using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Application.OrderOperations.Commands.CreateOrder;
using WebApi.Application.OrderOperations.Commands.DeleteOrder;
using WebApi.Application.OrderOperations.Queries;
using WebApi.DBOperations;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class OrderController : ControllerBase
    {
        private readonly IMovieStoreDbContext _context;
        private readonly IMapper _mapper;

        public OrderController(IMovieStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetOrders()
        {
            GetOrderByCustomerIdQuery query = new GetOrderByCustomerIdQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            GetOrderDetailQuery query = new GetOrderDetailQuery(_context,_mapper);
            query.OrderId = id;
            var result = query.Handle();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateOrder([FromBody] CreateOrderModel newOrder)
        {
            CreateOrderCommand command = new CreateOrderCommand(_context,_mapper);
            command.Model = newOrder;
            CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok(newOrder);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            DeleteOrderCommand command = new DeleteOrderCommand(_context);
            command.OrderId = id;
            DeleteOrderCommandValidator validator = new DeleteOrderCommandValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }
    }
}