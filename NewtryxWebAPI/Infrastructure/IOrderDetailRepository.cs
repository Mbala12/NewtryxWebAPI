using NewtryxWebAPI.Entities;
using NewtryxWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Infrastructure
{
    public interface IOrderDetailRepository
    {
        public void CreateUpdate(OrderVm orderVm);
        public IEnumerable<OrderDetail> GetAll();
        public OrderDetail GetById(int id);
        public void Delete(OrderDetail orderDetail);
    }
}
