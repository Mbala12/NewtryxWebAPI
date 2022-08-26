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
    public class ItemRepository : IItemRepository
    {
        private readonly NewtryxDbContext _context;
        public ItemRepository(NewtryxDbContext context)
        {
            _context = context;
        }

        public void Delete(Item item)
        {
            _context.Items.Remove(item);
            _context.SaveChanges();
        }

        public IEnumerable<Item> GetAll()
        {
            return _context.Items.ToList();
        }

        public Item GetById(int id)
        {
            return _context.Items.FirstOrDefault(x => x.ItemId == id);
        }

        public void CreateUpdate(ItemVm itemVm)
        {
            var id = itemVm.ItemId;
            if(id != 0)
            {
                Item item = new Item()
                {
                    ItemId = itemVm.ItemId,
                    ItemName = itemVm.ItemName.ToUpper(),
                    ItemPrice = itemVm.ItemPrice
                };
                _context.Items.Update(item);
                _context.SaveChanges();
            }
            else
            {
                Item item = new Item()
                {
                    ItemName = itemVm.ItemName.ToUpper(),
                    ItemPrice = itemVm.ItemPrice
                };
                _context.Items.Add(item);
                _context.SaveChanges();
            }
        }
    }
}
