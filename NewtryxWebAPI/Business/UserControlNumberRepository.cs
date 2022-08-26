using NewtryxWebAPI.AppDbContext;
using NewtryxWebAPI.Infrastructure;
using NewtryxWebAPI.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace NewtryxWebAPI.Business
{
    public class UserControlNumberRepository: IUserControlNumberRepository
    {
        private readonly NewtryxDbContext _context;
        public UserControlNumberRepository(NewtryxDbContext context)
        {
            _context = context;
        }

        public IEnumerable<UserControlNumberVm> GetControlNumber()
        {
            List<UserControlNumberVm> objUser = new List<UserControlNumberVm>();
            objUser = (from x in _context.Users
                       select new UserControlNumberVm
                       {
                           UserId = x.UserId,
                           Controlnumber = x.Controlnumber
                       }).ToList();

            return objUser;
        }
    }
}
