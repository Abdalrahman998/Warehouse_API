using DataAccess.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HappyCompanyAPI.DTO
{
    public class ItemDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKUCode { get; set; }
        public int Qty { get; set; }
        public double CostPrice { get; set; }
        public double? MSRPPrice { get; set; }
        public int Warehouse_Id { get; set; }
    }
}
