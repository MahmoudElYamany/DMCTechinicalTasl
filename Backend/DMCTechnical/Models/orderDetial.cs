using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class orderDetial
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("orderHeader"), Column(Order = 1)]
        public string orderHeaderID { get; set; }
        [ForeignKey("item"), Column(Order = 2)]
        public int itemID { get; set; }
        public int Quantity { get; set; }

        public orderHeader orderHeader { get; set; }
        public Item item { get; set; }
    }
}
