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
    public class ReservationStatusController : Controller
    {
        private readonly IReservationStatusRepository _repos;
        public ReservationStatusController(IReservationStatusRepository repos)
        {
            _repos = repos;
        }

        [HttpGet]
        public IActionResult GetReservationStatuses()
        {
            IEnumerable<ReservationStatus> reservationStatuses = _repos.GetAll();
            return Ok(reservationStatuses);
        }

        [HttpGet("{id}")]
        public IActionResult GetReservationStatus(int id)
        {
            ReservationStatus reservationStatus = _repos.GetById(id);
            if (reservationStatus == null)
            {
                return NotFound();
            }
            return Ok(reservationStatus);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReservationStatusVm reservationStatusVm)
        {
            if (reservationStatusVm == null)
            {
                return BadRequest();
            }
            _repos.CreateUpdate(reservationStatusVm);
            return Ok(reservationStatusVm);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            ReservationStatus reservationStatus = _repos.GetById(id);
            if (reservationStatus == null)
            {
                return BadRequest();
            }
            _repos.Delete(reservationStatus);
            return Ok(reservationStatus);
        }
    }
}
