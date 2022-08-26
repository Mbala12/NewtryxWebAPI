using NewtryxWebAPI.Entities;
using NewtryxWebAPI.Infrastructure;
using NewtryxWebAPI.ViewModel;
using NewtryxWebAPI.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Business
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly NewtryxDbContext _context;
        public ReservationRepository(NewtryxDbContext context)
        {
            _context = context;
        }

        public void Delete(Reservation reservation)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }

        public IEnumerable<ReservationDetailsVm> GetAll()
        {


            List<ReservationDetailsVm> objReservation = new List<ReservationDetailsVm>();
            objReservation = (from x in _context.Reservations
                              join y in _context.Users on x.UserId equals y.UserId
                              join z in _context.Restaurants on x.RestaurantId equals z.RestaurantId
                              join m in _context.ReservationStatuses on x.ReservationStatusId equals m.ReservationStatusId
                              select new ReservationDetailsVm
                              {
                                  ReservationId = x.ReservationId,
                                  BookingNo = x.BookingNo,
                                  RestoNames = z.Name,
                                  UserFullname = y.Firstname + " " +y.Lastname,
                                  StatusType = m.ReservationStatusType,
                                  BookedDT = x.StartDateTime,
                                  Description = x.Description
                              }).ToList();
            return objReservation;
            //return _context.Reservations.ToList();
        }

        public Reservation GetById(int id)
        {
            return _context.Reservations.FirstOrDefault(x => x.ReservationId == id);
        }

        public void CreateUpdate(ReservationVm reservationVm)
        {
            var id = reservationVm.ReservationId;
            DateTime _date = DateTime.Now;
            reservationVm.BookingNo = String.Format("{0:mmsshhmmddyyyy}", _date);
            if (id != 0)
            {
                Reservation reserv = new Reservation()
                {
                    ReservationId = reservationVm.ReservationId,
                    RestaurantId = reservationVm.RestaurantId,
                    BookingNo = reservationVm.BookingNo,
                    UserId = reservationVm.UserId,
                    ReservationStatusId = reservationVm.ReservationStatusId,
                    Description = reservationVm.Description,
                    StartDateTime = reservationVm.StartDateTime
                };
                _context.Reservations.Update(reserv);
                _context.SaveChanges();

            }
            else
            {
                Reservation reserv = new Reservation()
                {
                    RestaurantId = reservationVm.RestaurantId,
                    BookingNo = reservationVm.BookingNo,
                    UserId = reservationVm.UserId,
                    ReservationStatusId = reservationVm.ReservationStatusId,
                    Description = reservationVm.Description,
                    StartDateTime = reservationVm.StartDateTime
                };                
                _context.Reservations.Add(reserv);
                _context.SaveChanges();
            }
        }
    }
}
