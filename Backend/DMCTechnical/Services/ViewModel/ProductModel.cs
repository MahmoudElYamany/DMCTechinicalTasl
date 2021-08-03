using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModel
{
    public class ProductModel
    {
        public int id { get; set; }
        public string Category { get; set; }
        public string avaliable { get; set; }
        public string image { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int size { get; set; }
        public string uom { get; set; }
        public string color { get; set; }
    }
}
