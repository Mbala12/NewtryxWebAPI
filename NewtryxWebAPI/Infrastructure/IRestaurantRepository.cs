//using Microsoft.AspNetCore.Mvc.Rendering;
using NewtryxWebAPI.Entities;
using NewtryxWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Infrastructure
{
    public interface IRestaurantRepository
    {
        public IEnumerable<Restaurant> GetAll();
        public Restaurant GetById(int id);
        public void Delete(Restaurant restaurant);
        public void CreateUpdate(RestaurantVm restaurantVm);
        
    }
}
