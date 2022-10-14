using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class WarehouseWithTotalItems
    {
        public Warehouse warehouse { get; set; }
        public int TotalItems { get; set; }
    }
}
