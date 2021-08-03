using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UOM
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public List<Item> items { get; set; }
    }
}
