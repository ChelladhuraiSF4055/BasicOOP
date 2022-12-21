using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineDrive
{
    public enum Gender {Select,Male,Female }
    public class BeneficiaryClass
    {
        public static int s_registrationNumber =1000;
        public string RegistrationNumber { get; set; }
        public string  Name { get; set; }
        public Gender Gender { get; set; }
        public long  MobileNumber { get; set; }
        public string  City { get; set; }
        public int Age { get; set; }

        public BeneficiaryClass ()
        {
            RegistrationNumber="Enter your Registration Number";
            Name="Enter your Name";
            Gender=Gender.Select;
        }

        public BeneficiaryClass(string name, Gender gender,long mobile, string city, int age)
        {
            s_registrationNumber++;
            RegistrationNumber="BID"+s_registrationNumber;
            Name=name;
            Gender=gender;
            MobileNumber=mobile;
            City=city;
            Age=age;

        }    
    }
}