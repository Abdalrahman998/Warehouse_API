using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string SKUCode { get; set; }
        public int Qty { get; set; }
        public double CostPrice { get; set; }
        public double? MSRPPrice { get; set; }
        [ForeignKey("warehouse")]
        public int Warehouse_Id { get; set; }
        public Warehouse warehouse { get; set; }
    }
}
