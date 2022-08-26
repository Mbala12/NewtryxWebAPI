using NewtryxWebAPI.AppDbContext;
using NewtryxWebAPI.Entities;
using NewtryxWebAPI.Infrastructure;
using NewtryxWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Business
{
    public class UserRepository : IUserRepository
    {
        private readonly NewtryxDbContext _context;
        public UserRepository(NewtryxDbContext context)
        {
            _context = context;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            List<User> objUser = new List<User>();
            objUser = (from x in _context.Users
                        select new User
                        {
                            UserId = x.UserId,
                            Firstname = x.Firstname,
                            Lastname = x.Lastname,
                            Email = x.Email,
                            Phone = x.Phone,
                            Controlnumber = x.Controlnumber
                        }).ToList();
            return objUser;
            //return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == id);
        }

        public void CreateUpdate(UserVm userVm)
        {
            var id = userVm.UserId;

            DateTime _date = DateTime.Now;
            string yearDate = String.Format("{0:yyyydd}", _date);
            string minSec = String.Format("{0:mmss}", _date);
            string substr1 = userVm.Firstname.Substring(1, 2).ToUpper();
            string substr2 = userVm.Lastname.Substring(1, 2).ToUpper();
            userVm.Controlnumber = substr1 + yearDate + substr2 + minSec;
            if (id != 0)
            {
                User user = new User()
                {
                    UserId = userVm.UserId,
                    Firstname = userVm.Firstname.ToUpper(),
                    Lastname = userVm.Lastname.ToUpper(),
                    Email = userVm.Email,
                    Phone = userVm.Phone,
                    Controlnumber = userVm.Controlnumber
                };
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            else
            {
                User user = new User()
                {
                    Firstname = userVm.Firstname.ToUpper(),
                    Lastname = userVm.Lastname.ToUpper(),
                    Email = userVm.Email,
                    Phone = userVm.Phone,
                    Controlnumber = userVm.Controlnumber
                };
                _context.Users.Add(user);
                _context.SaveChanges();
            }

            
        }
    }
}
