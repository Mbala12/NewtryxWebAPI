using NewtryxWebAPI.Entities;
using NewtryxWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Infrastructure
{
    public interface IReservationStatusRepository
    {
        public void CreateUpdate(ReservationStatusVm reservationStatusVm);
        public IEnumerable<ReservationStatus> GetAll();
        public ReservationStatus GetById(int id);
        public void Delete(ReservationStatus reservationStatus);
    }
}
