using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class City
    {
        [Key]
        public int City_Id { set; get; }
        [Required]
        public string City_Name { get; set; }
        public Country country { set; get; }
        public List<Customer> customers { set; get; }
    }
}
