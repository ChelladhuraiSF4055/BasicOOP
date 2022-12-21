using System;

namespace Component
{
    public enum Gender{Select,Male,Female,Transgender}
    public class CustomerDetails
    {
        private static int s_customerID=1000;
        public int CustomerID { get; }
        public string Name { get; set; }

        private double _balance;
        public double Balance { get{return _balance;} }

        public Gender Gender { get; set; }

        public long Phone { get; set; }

        public string MailID { get; set; }

        public DateTime DOB { get; set; }

       //Default Constructors
       public CustomerDetails ()
       {
        Name="Enter Your Name";
        Gender=Gender.Select;  
        MailID="Enter Your mailID";
       }
       //parameter Constuctor
       
       public CustomerDetails(string name, Gender gender, long phone, string mailID, DateTime dob)
       {
            s_customerID++;
            CustomerID=s_customerID;
            Name=name;
            Gender=gender;
            Phone=phone;
            MailID=mailID;
            DOB=dob;
       }
       public double Deposit(double amount)
       {
            _balance+=amount;
            return Balance;
        }
        public bool Withdraw(double amount)
        {
            if(Balance<amount)
            {
                return false;
            }
            else
            {
                _balance-=amount;
                return true;
            }
        
        }
    }

}