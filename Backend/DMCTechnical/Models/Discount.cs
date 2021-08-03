using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Discount
    {
        [Key]
        public int ID { get; set; }
        public string TaxCode { get; set; }
        public float Value { get; set; }

        public List<orderHeader> orderHeaders { get; set; }
    }
}
