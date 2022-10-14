using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SpecificRepository
{
    public class ItemRepository:IItemRepository
    {
        SystemContext context;

        public ItemRepository(SystemContext _context)
        {
            context = _context;
        }
        public List<Item> LoadByName(string Name)
        {
            int l = Name.Length;
            return context.items.Include("warehouse").Where(c => c.Name.Substring(0, l) == Name).ToList();
        }
        public List<Item> LoadByWarehouse(int Id)
        {
            return context.items.Include("warehouse").Where(i => i.Warehouse_Id == Id).ToList();
        }
        public List<Item> LoadAll()
        {
            List<Item> li = context.items.Include("warehouse").ToList();
            return li;
        }
        public List<Item> LoadTop10()
        {
            List<Item> li = context.items.OrderByDescending(i => i.Qty).Take(10).ToList();
            return li;
        }
        public List<Item> LoadLow10()
        {
            List<Item> li = context.items.OrderBy(i => i.Qty).Take(10).ToList();
            return li;
        }
    }
}
