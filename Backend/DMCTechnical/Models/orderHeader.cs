using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class orderHeader
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }
        public DateTime orderDate { get; set; }
        /*public DateTime RequestDate { get; set; }*/
        public DateTime DueDate { get; set; }
        public int Status { get; set; }
        public int TotalValue { get; set; }

        [ForeignKey("discount")]
        public int? DiscountID { get; set; }

        public int tax { get; set; }
        public string paymentType { get; set; }
        public Discount discount { get; set; }
        public List<orderHeaderCustomer> orderHeaderCustomers { get; set; }
        public Status State { set; get; }


    }
}
