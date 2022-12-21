using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhaseIIAssignment
{
    public class UserDetailClass
    {
        public static int s_userID = 1000;
        public string UserID { get; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public long Phone { get; set; }
        public int Balance { get; set; }

        public UserDetailClass()
        {
            UserID = "Enter UserID";
            UserName = "Enter UserName";
            City = "Enter City";
        }
        public UserDetailClass(string userName, int age, string city, long phone, int balance)
        {
            s_userID++;
            UserID = "UID" + s_userID;
            Age = age;
            City = city;
            Phone = phone;
            Balance = balance;
        }

        public void Recharge(int amount)
        {
            Balance += amount;
        }
        public void Purchase(int amount)
        {
            Balance -= amount;
        }
    }
}