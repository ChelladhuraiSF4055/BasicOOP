using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineHospital
{
    public enum Gender {Select, Male, Female};
    public class PatientDetials
    {
        private static int s_patientID=1000;
        public string PatientID { get;}
        public string PatientName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int WalletBalance  { get; set; }

        public PatientDetials()
        {
            PatientID="Enter Patient ID";
            PatientName="Enter Patient Name";
            Gender=Gender.Select;
        }
        public PatientDetials(string patientName,int age, Gender gender,int walletBalance)
        {
            s_patientID++;
            PatientID="PID"+s_patientID;
            PatientName=patientName;
            Age=age;
            Gender=gender;
            WalletBalance=walletBalance;
        }

        public void Book(int amount)
        {
            WalletBalance-=amount;
        }
        public void Recharge(int amount)
        {
            WalletBalance+=amount;
        }
    }
}