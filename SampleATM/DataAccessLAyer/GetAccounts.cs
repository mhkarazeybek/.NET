using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;

namespace DataAccessLAyer
{
    public class GetAccounts
    {
        private static AtmEntities ent = new AtmEntities();
        public static List<Accounts> GetAllAccounts()
        {
            return ent.Accounts.ToList();
        }
    }
}
