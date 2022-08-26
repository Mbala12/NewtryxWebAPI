using NewtryxWebAPI.Entities;
using NewtryxWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Infrastructure
{
    public interface IOrderRepository
    {
        public void CreateUpdate(OrderVm orderVm);
        public IEnumerable<Order> GetAll();
        public Order GetById(int id);
        public void Delete(Order order);
    }
}
