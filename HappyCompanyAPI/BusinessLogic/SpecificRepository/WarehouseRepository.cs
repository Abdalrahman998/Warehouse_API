using DataAccess.Context;
using DataAccess.Entities;
using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SpecificRepository
{
    public class WarehouseRepository:IWarehouseRepository
    {
        SystemContext context;

        public WarehouseRepository(SystemContext _context)
        {
            context = _context;
        }
        public List<Warehouse> LoadByName(string Name)
        {
            int l = Name.Length;
            return context.warehouses.Include("country").Where(c => c.Name.Substring(0, l) == Name).ToList();
        }
        public List<Warehouse> LoadAll()
        {
            List<Warehouse> li = context.warehouses.Include("country").ToList();
            return li;
        }
        public List<WarehouseWithTotalItems> LoadWithTotalItems()
        {
            List<WarehouseWithTotalItems> li = context.warehouses.Select(data =>
                   new WarehouseWithTotalItems()
                   {
                       warehouse = data,
                       TotalItems = data.liItem.Count()
                   }).ToList();
            return li;
        }
    }
}
