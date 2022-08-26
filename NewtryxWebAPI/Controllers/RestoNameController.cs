using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtryxWebAPI.ViewModel;
using NewtryxWebAPI.Infrastructure;
using System.Collections.Generic;

namespace NewtryxWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestoNameController : ControllerBase
    {
        private readonly IRestoNameRepository _repos;
        public RestoNameController(IRestoNameRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IActionResult GetRestoName()
        {
            IEnumerable<RestoNameVm> restoName = _repos.GetRestaurantName();
            return Ok(restoName);
        }
    }
}
