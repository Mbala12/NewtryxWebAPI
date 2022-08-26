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
    public class UserController : Controller
    {
        private readonly IUserRepository _repos;
        public UserController(IUserRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            IEnumerable<User> users = _repos.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            User user = _repos.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserVm userVm)
        {
            if (userVm == null)
            {
                return BadRequest();
            }
            _repos.CreateUpdate(userVm);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            User user = _repos.GetById(id);
            if (user == null)
            {
                return BadRequest();
            }
            _repos.Delete(user);
            return Ok(user);
        }

    }
}
