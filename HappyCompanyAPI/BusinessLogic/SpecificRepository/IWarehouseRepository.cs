using DataAccess.Entities;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SpecificRepository
{
    public interface IWarehouseRepository
    {
        List<Warehouse> LoadByName(string Name);
        List<Warehouse> LoadAll();
        List<WarehouseWithTotalItems> LoadWithTotalItems();
    }
}
