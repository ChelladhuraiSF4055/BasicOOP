using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public enum Gender {Select,Male,Female}
    public enum Department { Select, ECE,EEE,CSE }
    public class UserDetails
    {
        private static int s_userID=3000;
        public string UserID { get; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
        public long MobileNumber { get; set; }
        public string MailID { get; set; }

        public UserDetails()
        {
            Name="Enter Your name";
            Gender=Gender.Select;
            Department=Department.Select;
            MailID="Enter Your mailId";
        }

        public UserDetails(string name,Gender gender,Department department,long mobile,string mailID)
        {
            s_userID++;
            UserID="SF"+s_userID;
            Name=name;
            Gender=gender;
            Department=department;
            MobileNumber=mobile;
            MailID=mailID;
        }

        
    }
}