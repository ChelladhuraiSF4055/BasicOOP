using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineDrive
{
    public enum VaccineName{Select,Covishield,Covaccine}
    public class VaccineClass
    {
        private static int  s_vaccineID=100;
        public string VaccineID { get; set; }
        public VaccineName VaccineName{get;set;}
        public int NoOfDose { get; set; }
        
    public VaccineClass()
    {
        VaccineID="Enter Vaccine ID";
        VaccineName=VaccineName.Select;
    }
    public VaccineClass(VaccineName vaccineName,int noOfDose)
    {
        s_vaccineID++;
        VaccineID="CID"+s_vaccineID;
        VaccineName=vaccineName;
        NoOfDose=noOfDose;
    }

    public void injected()
    {
        NoOfDose--;
    }
    }
}