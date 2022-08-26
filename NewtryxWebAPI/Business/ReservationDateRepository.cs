using NewtryxWebAPI.Infrastructure;
using System.Collections.Generic;
using NewtryxWebAPI.AppDbContext;
using NewtryxWebAPI.ViewModel;
using System.Linq;

namespace NewtryxWebAPI.Business
{
    public class ReservationDateRepository : IReservationDateRepository
    {
        private readonly NewtryxDbContext _context;
        public ReservationDateRepository(NewtryxDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ReservationDateVm> GetReservationDate()
        {
            List<ReservationDateVm> objDate = new List<ReservationDateVm>();
            objDate= (from x in _context.Reservations
                       select new ReservationDateVm
                       {
                           ReservationId = x.ReservationId,
                           StartDateTime = x.StartDateTime
                       }).ToList();

            return objDate;
        }
    }
}
