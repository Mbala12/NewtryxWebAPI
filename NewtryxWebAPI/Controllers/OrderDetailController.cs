using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewtryxWebAPI.Infrastructure;
using NewtryxWebAPI.AppDbContext;
using NewtryxWebAPI.ViewModel;
using NewtryxWebAPI.Entities;

namespace NewtryxWebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailRepository _repos;
        public OrderDetailController(IOrderDetailRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IActionResult GetOrderDetails()
        {
            IEnumerable<OrderDetail> orderDetailds = _repos.GetAll();
            return Ok(orderDetailds);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderDetail(int id)
        {
            OrderDetail orderDetail = _repos.GetById(id);
            if (orderDetail == null)
            {
                return NotFound();
            }
            return Ok(orderDetail);
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrderVm orderVm)
        {
            if (orderVm == null)
            {
                return BadRequest();
            }
            _repos.CreateUpdate(orderVm);
            return Ok(orderVm);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            OrderDetail orderDetail = _repos.GetById(id);
            if (orderDetail == null)
            {
                return BadRequest();
            }
            _repos.Delete(orderDetail);
            return Ok(orderDetail);
        }

    }
}
