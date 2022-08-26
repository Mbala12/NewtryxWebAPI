using NewtryxWebAPI.AppDbContext;
using NewtryxWebAPI.Infrastructure;
using NewtryxWebAPI.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace NewtryxWebAPI.Business
{
    public class RestoNameRepository: IRestoNameRepository
    {
        private readonly NewtryxDbContext _context;
        public RestoNameRepository(NewtryxDbContext context)
        {
            _context = context;
        }
        public IEnumerable<RestoNameVm> GetRestaurantName()
        {
            List<RestoNameVm> objResto = new List<RestoNameVm>();
            objResto = (from x in _context.Restaurants 
                        select new RestoNameVm
                        {
                            RestaurantId = x.RestaurantId,
                            Name = x.Name
                        }).ToList();

            return objResto;
        }
    }
}
