using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class orderHeaderCustomer
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("orderHeader"), Column(Order = 1)]
        public string orderHeaderID { get; set; }
        [ForeignKey("customer"), Column(Order = 2)]
        public string customerID { get; set; }
        public string address { get; set; }
        [ForeignKey("Country"), Column(Order = 3)]
        public int country_id { get; set; }
        [ForeignKey("City"), Column(Order = 4)]
        public int city_id { get; set; }

        public orderHeader orderHeader { get; set; }
        public Customer customer { get; set; }
        public Country Country { set; get; }
        public City City { set; get; }
    }
}
