using NewtryxWebAPI.Entities;
using NewtryxWebAPI.ViewModel;
using System.Collections.Generic;

namespace NewtryxWebAPI.Infrastructure
{
    public interface IUserControlNumberRepository
    {
        public IEnumerable<UserControlNumberVm> GetControlNumber();

    }
}
