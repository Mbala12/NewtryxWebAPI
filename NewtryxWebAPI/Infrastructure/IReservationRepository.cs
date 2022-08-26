using NewtryxWebAPI.Entities;
using NewtryxWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Infrastructure
{
    public interface IReservationRepository
    {
        public void CreateUpdate(ReservationVm reservationVm);
        public IEnumerable<ReservationDetailsVm> GetAll();

        public Reservation GetById(int id);
        public void Delete(Reservation reservation);
    }
}
