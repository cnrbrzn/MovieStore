using System;
using System.Linq;
using WebApi.DBOperations;

namespace WebApi.Application.OrderOperations.Commands.DeleteOrder
{
    public class DeleteOrderCommand
    {
        private readonly IMovieStoreDbContext _context;
        public int OrderId { get; set; }
        public DeleteOrderCommand(IMovieStoreDbContext context)
        {
            _context = context;
        }
        public void Handle()
        {
            var order = _context.Orders.SingleOrDefault(x=> x.Id == OrderId);
            if(order is null)
                throw new InvalidOperationException("Silinecek sipariş bulunamadı!");
            order.IsActive = false;
            _context.SaveChanges();
        }
    }
}