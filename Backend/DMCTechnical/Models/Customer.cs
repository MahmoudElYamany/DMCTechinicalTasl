using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Customer : IdentityUser
    {
        public string FName { set; get; }
        public string LName { set; get; }
        public string Image { set; get; }
        public DateTime birthday { get; set; }
        [ForeignKey("Country"), Column(Order = 1)]
        public int Country_Id { get; set; }
        [ForeignKey("City"), Column(Order = 2)]
        public int City_Id { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public bool? IsActive { set; get; }
        public DateTime JoinedDate { get; set; }
        public string Message { get; set; }
        
        public Country Country { set; get; }
        public City City { set; get; }
        public List<orderHeaderCustomer> orderHeaderCustomers { get; set; }

    }
}
