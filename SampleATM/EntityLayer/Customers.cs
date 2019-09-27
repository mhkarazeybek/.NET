using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [Required]
        public string CardNo { get; set; }
        [Required]
        public string CsPassword { get; set; }
        public ICollection<Accounts> Account { get; set; }

    }
}
