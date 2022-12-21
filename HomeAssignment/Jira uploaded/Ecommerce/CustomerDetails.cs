using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class CustomerDetails
    {
        private static int s_customerID=1000;
        public string CustomerID { get; }
        public string Name { get; set; }
        public string City { get; set; }    
        public long Mobile { get; set; }
        public int WalletBalance { get; set; }  
        public string EmailID { get; set; }

        public CustomerDetails()
        {
            Name="Enter Your CustomerID";
            CustomerID="Enter CustomerID";
            City="Entrr City";
            EmailID="Enter mail";
        }
        public CustomerDetails(string name, string city, long phone, int walletBalance, string emailID)
        {
            s_customerID++;
            CustomerID="CID"+s_customerID;
            Name=name;
            City=city;
            Mobile=phone;
            WalletBalance=walletBalance;
            EmailID=emailID;
        }

        public int Recharge(int amount)
        {
            WalletBalance+=amount;
            return WalletBalance;
        }
        public void Purchase(int amount)
        {
            WalletBalance-=amount;
        }

        public void Refund(int amount)
        {
            WalletBalance+=amount;
        }

    }
}