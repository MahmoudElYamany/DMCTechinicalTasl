using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Item
    {
        [Key]
        public int ID { get; set; }
        public string  name { get; set; }
        public double price { get; set; }
        public int quatity { get; set; }
        public string description { get; set; }
        public int size { get; set; }
        public string  color { get; set; }
        public string image { get; set; }

        [ForeignKey("Category"),Column(Order =1)]
        public int Category_Id { set; get; }
        
        [ForeignKey("uOM"), Column(Order = 2)]
        public int UOM_ID { get; set; }

        public Category Category { set; get; }
        public UOM uOM { get; set; }

        public List<orderDetial> orderDetials { get; set; }

    }
}
