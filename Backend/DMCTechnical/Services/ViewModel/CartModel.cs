using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModel
{
    public class CartModel
    {
        public string address { get; set; }
        public int cityid { get; set; }
        public int countryid { get; set; }
        public string discount { get; set; }
        public List<ProductModel> items { get; set; }
        public string orderId { get; set; }
        public string paymenttype { get; set; }
        public List<int> quantity { get; set; }
        public int subtotal { get; set; }
        public string username { get; set; }
        public int total { get; set; }
    }
}
