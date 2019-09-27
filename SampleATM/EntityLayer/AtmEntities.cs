using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class AtmEntities: DbContext
    {
        public AtmEntities():base("Server=servername;Database=ATMHomework;User Id=ıd;Password=password")
        {
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
    }
}
