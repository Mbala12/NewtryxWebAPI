using Microsoft.AspNetCore.Mvc;
using NewtryxWebAPI.Entities;
using NewtryxWebAPI.Infrastructure;
using NewtryxWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Controllers
{
    [Route("api/[Controller]")]
    public class ItemController : Controller
    {
        private readonly IItemRepository _repos;
        public ItemController(IItemRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IActionResult GetItems()
        {
            IEnumerable<Item> restaurants = _repos.GetAll();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            Item item = _repos.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ItemVm itemVm)
        {
            if (itemVm == null)
            {
                return BadRequest();
            }
            _repos.CreateUpdate(itemVm);
            return Ok(itemVm);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Item item = _repos.GetById(id);
            if (item == null)
            {
                return BadRequest();
            }
            _repos.Delete(item);
            return Ok(item);
        }

    }
}
