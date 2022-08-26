using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class RestaurantController : Controller
    {
        private readonly IRestaurantRepository _repos;
        public RestaurantController(IRestaurantRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IActionResult GetRestaurants()
        {
            IEnumerable<Restaurant> restaurants = _repos.GetAll();
            return Ok(restaurants);
        }

        [HttpGet("{id}")]
        public IActionResult GetRestaurant(int id)
        {
            Restaurant restaurant = _repos.GetById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }

        [HttpPost]
        public IActionResult Post([FromBody] RestaurantVm restaurantVm)
        {
            if (restaurantVm == null)
            {
                return BadRequest();
            }
            _repos.CreateUpdate(restaurantVm);
            return Ok(restaurantVm);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Restaurant restaurant = _repos.GetById(id);
            if (restaurant == null)
            {
                return BadRequest();
            }
            _repos.Delete(restaurant);
            return Ok(restaurant);
        }

    }
}
