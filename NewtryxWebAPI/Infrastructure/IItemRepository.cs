using NewtryxWebAPI.Entities;
using NewtryxWebAPI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewtryxWebAPI.Infrastructure
{
    public interface IItemRepository
    {
        public void CreateUpdate(ItemVm itemVm);
        public IEnumerable<Item> GetAll();
        public Item GetById(int id);
        public void Delete(Item item);
    }
}
