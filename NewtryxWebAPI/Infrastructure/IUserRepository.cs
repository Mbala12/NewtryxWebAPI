using NewtryxWebAPI.Entities;
using NewtryxWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Infrastructure
{
    public interface IUserRepository
    {
        public void CreateUpdate(UserVm userVm);
        public IEnumerable<User> GetAll();
        public User GetById(int id);
        public void Delete(User user);
    }
}
