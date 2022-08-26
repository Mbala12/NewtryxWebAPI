using System;
using System.Collections.Generic;
using NewtryxWebAPI.AppDbContext;
using NewtryxWebAPI.Infrastructure;
using NewtryxWebAPI.ViewModel;
using System.Linq;
using System.Threading.Tasks;
using NewtryxWebAPI.Entities;

namespace NewtryxWebAPI.Business
{
    public class ReservationStatusRepository : IReservationStatusRepository
    {
        private readonly NewtryxDbContext _context;
        public ReservationStatusRepository(NewtryxDbContext context)
        {
            _context = context;
        }

        public void Delete(ReservationStatus reservationStatus)
        {
            _context.ReservationStatuses.Remove(reservationStatus);
            _context.SaveChanges();
        }

        public IEnumerable<ReservationStatus> GetAll()
        {
            return _context.ReservationStatuses.ToList();
        }

        public ReservationStatus GetById(int id)
        {
            return _context.ReservationStatuses.FirstOrDefault(x => x.ReservationStatusId == id);
        }

        public void CreateUpdate(ReservationStatusVm reservationStatusVm)
        {
            var id = reservationStatusVm.ReservationStatusId;
            if (id != 0)
            {
                ReservationStatus rss = new ReservationStatus()
                {
                    ReservationStatusId = reservationStatusVm.ReservationStatusId,
                    ReservationStatusType = reservationStatusVm.ReservationStatusType
                };
                _context.ReservationStatuses.Update(rss);
                _context.SaveChanges();

            }
            else
            {
                ReservationStatus rss = new ReservationStatus()
                {
                    ReservationStatusType = reservationStatusVm.ReservationStatusType
                };
                _context.ReservationStatuses.Add(rss);
                _context.SaveChanges();
            }
        }
    }
}
