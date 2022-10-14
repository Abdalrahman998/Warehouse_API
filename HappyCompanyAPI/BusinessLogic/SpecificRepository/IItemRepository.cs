using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.SpecificRepository
{
    public interface IItemRepository
    {
        List<Item> LoadByName(string Name);
        List<Item> LoadByWarehouse(int Id);
        List<Item> LoadAll();
        List<Item> LoadTop10();
        List<Item> LoadLow10();
    }
}
