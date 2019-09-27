using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLAyer
{
    public class GetCustomer
    {
        public static AtmEntities ent = new AtmEntities();
        public static List<Customers> GetAllCustomers()
        {
            return ent.Customers.ToList();
        }
    }
}
