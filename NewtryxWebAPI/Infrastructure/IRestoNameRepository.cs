using NewtryxWebAPI.ViewModel;
using System.Collections.Generic;

namespace NewtryxWebAPI.Infrastructure
{
    public interface IRestoNameRepository
    {
        public IEnumerable<RestoNameVm> GetRestaurantName();
    }
}
