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
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _repos;
        public ReservationController(IReservationRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IActionResult GetReservations()
        {
            IEnumerable<ReservationDetailsVm> reservations = _repos.GetAll();
            return Ok(reservations);
        }

        [HttpGet("{id}")]
        public IActionResult GetReservation(int id)
        {
            Reservation res = _repos.GetById(id);
            if (res == null)
            {
                return NotFound();
            }
            return Ok(res);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReservationVm reservationVm)
        {
            if (reservationVm == null)
            {
                return BadRequest();
            }
            _repos.CreateUpdate(reservationVm);
            return Ok(reservationVm);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Reservation res = _repos.GetById(id);
            if (res == null)
            {
                return BadRequest();
            }
            _repos.Delete(res);
            return Ok(res);
        }

    }
}
