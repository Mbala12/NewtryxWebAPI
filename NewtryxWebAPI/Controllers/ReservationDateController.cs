using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewtryxWebAPI.ViewModel;
using NewtryxWebAPI.Infrastructure;
using System.Collections.Generic;

namespace NewtryxWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationDateController : ControllerBase
    {
        private readonly IReservationDateRepository _repos;
        public ReservationDateController(IReservationDateRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IActionResult GetReservationDates()
        {
            IEnumerable<ReservationDateVm> reservationDate = _repos.GetReservationDate();
            return Ok(reservationDate);
        }

    }
}
