using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtryxWebAPI.ViewModel;
using NewtryxWebAPI.Infrastructure;
using System.Collections.Generic;

namespace NewtryxWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControlNumberController : ControllerBase
    {

        private readonly IUserControlNumberRepository _repos;
        public UserControlNumberController(IUserControlNumberRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IActionResult GetControlNumbers()
        {
            IEnumerable<UserControlNumberVm> userControlNumber = _repos.GetControlNumber();
            return Ok(userControlNumber);
        }

    }
}
