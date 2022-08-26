using NewtryxWebAPI.AppDbContext;
using NewtryxWebAPI.Entities;
using NewtryxWebAPI.Infrastructure;
using NewtryxWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Business
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NewtryxDbContext _context;
        public OrderRepository(NewtryxDbContext context)
        {
            _context = context;
        }

        public void Delete(Order order)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.ToList();
        }

        public Order GetById(int id)
        {
            return _context.Orders.FirstOrDefault(x => x.OrderId == id);
        }

        public void CreateUpdate(OrderVm orderVm)
        {
            var id = orderVm.OrderId;
            if(id == 0)
            {
                Order order = new Order()
                {
                    OrderNumber = orderVm.OrderNumber,
                    FinalTotal = orderVm.FinalTotal,
                    Description = orderVm.Description
                };
                _context.Orders.Add(order);
                _context.SaveChanges();
            }
            else
            {
                Order order = new Order()
                {
                    OrderId = orderVm.OrderId,
                    OrderNumber = orderVm.OrderNumber,
                    FinalTotal = orderVm.FinalTotal,
                    Description = orderVm.Description
                };
                _context.Orders.Update(order);
                _context.SaveChanges();
            }

        }
    }
}
