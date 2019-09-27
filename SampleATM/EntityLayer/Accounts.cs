using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Accounts
    {
        [Key]
        public int AccountId { get; set; }
        public int CustomerId { get; set; }
        public double Money { get; set; }
        public virtual Customers Customer { get; set; }
    }
}
