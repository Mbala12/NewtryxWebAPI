using NewtryxWebAPI.Entities;
using NewtryxWebAPI.Infrastructure;
using NewtryxWebAPI.ViewModel;
using NewtryxWebAPI.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.Rendering;

namespace NewtryxWebAPI.Business
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly NewtryxDbContext _context;
        public RestaurantRepository(NewtryxDbContext context)
        {
            _context = context;
        }

        public void Delete(Restaurant restaurant)
        {
            _context.Restaurants.Remove(restaurant);
            _context.SaveChanges();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }

        public Restaurant GetById(int id)
        {
            return _context.Restaurants.FirstOrDefault(x => x.RestaurantId == id);
        }

        public void CreateUpdate(RestaurantVm restaurantVm)
        { 
            var id = restaurantVm.RestaurantId;
            if(id != 0)
            {
                Restaurant res = new Restaurant()
                {
                    RestaurantId = restaurantVm.RestaurantId,
                    Name = restaurantVm.Name.ToUpper(),
                    Address = restaurantVm.Address.ToUpper(),
                    Email = restaurantVm.Email,
                    Phone = restaurantVm.Phone
                };
                _context.Restaurants.Update(res);
                _context.SaveChanges();
            }
            else
            {
                Restaurant res = new Restaurant()
                {
                    Name = restaurantVm.Name.ToUpper(),
                    Address = restaurantVm.Address.ToUpper(),
                    Email = restaurantVm.Email,
                    Phone = restaurantVm.Phone
                };
                _context.Restaurants.Add(res);
                _context.SaveChanges();
            }
            
        }
    }
}
