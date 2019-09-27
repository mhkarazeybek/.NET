using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLAyer;

namespace BusinessLayer
{
    public class Check
    {
        public static bool ControlCustomer(string cardNo)
        {
            bool sonuc = false;
            List<Customers> csList = GetCustomer.GetAllCustomers();
            foreach (Customers item in csList)
            {
                if (item.CardNo==cardNo)
                {
                    sonuc = true;
                }
            }
            return sonuc;
        }
        public static bool ControlPassword(string cardNo,string password)
        {
            bool sonuc = false;
            List<Customers> csList = GetCustomer.GetAllCustomers();
            foreach (Customers item in csList)
            {
                if (item.CardNo==cardNo)
                {
                    if (item.CsPassword==password)
                    {
                        sonuc = true;
                    }
                }
            }
            return sonuc;
        }

        public static bool ControlMoney(Accounts ac,int amount)
        {
            if (ac.Money >= amount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
