using NewtryxWebAPI.Infrastructure;
using NewtryxWebAPI.ViewModel;
using System.Collections.Generic;

namespace NewtryxWebAPI.Infrastructure
{
    public interface IReservationDateRepository
    {
        public IEnumerable<ReservationDateVm> GetReservationDate();
    }
}
