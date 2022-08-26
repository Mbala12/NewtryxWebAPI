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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public readonly NewtryxDbContext _context;
        public OrderDetailRepository(NewtryxDbContext context)
        {
            _context = context;
        }

        public void CreateUpdate(OrderVm orderVm)
        {
            Order oOrder = new Order();
            oOrder.FinalTotal = orderVm.FinalTotal;
            oOrder.OrderDate = DateTime.Now.ToString();
            oOrder.OrderDateTime = DateTime.Now;
            oOrder.OrderNumber = String.Format("{0:hhddmmssmmmyyyy}", DateTime.Now);
            oOrder.Description = "Hello there";
            var oList = oOrder.OrderDetails;
            _context.Orders.Add(oOrder);
            //_context.SaveChanges();

            int orderId = oOrder.OrderId;

            foreach (var item in orderVm.OrderDetails)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.OrderId = orderId;
                objOrderDetail.ItemId = item.ItemId;
                objOrderDetail.ReservationId = item.ReservationId;
                objOrderDetail.SubTotal = item.SubTotal;
                objOrderDetail.UnitPrice = item.UnitPrice;
                objOrderDetail.Quantity = item.Quantity;
                _context.OrderDetails.Add(objOrderDetail);
                _context.SaveChanges();


            }
        }

        public void Delete(OrderDetail orderDetail)
        {
            _context.OrderDetails.Remove(orderDetail);
            _context.SaveChanges();
        }

        public IEnumerable<OrderDetail> GetAll()
        {
            return _context.OrderDetails.ToList();
        }

        public OrderDetail GetById(int id)
        {
            return _context.OrderDetails.FirstOrDefault(x => x.OrderDetailId == id);
        }
    }
}
