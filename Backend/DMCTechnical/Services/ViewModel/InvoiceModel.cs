using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModel
{
    public class InvoiceModel
    {
        public DateTime orderDate { get; set; }
        public DateTime dueDate { get; set; }
        public int status { get; set; }
        public int? totalValue { get; set; }
        public string? discountCode { get; set; }
        public int discountvalue { get; set; }
        public int tax { get; set; }
        public string paymentType { get; set; }
        public List<ProductModel> items { get; set; }
        public List<int> quantity { get; set; }
        public string userName { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public Boolean anotherCountry { get; set; }

    }
}
