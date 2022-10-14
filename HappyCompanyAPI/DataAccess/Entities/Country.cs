using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    [Table("Countries")]
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Warehouse> liWarehouse { get; set; }
    }
}
