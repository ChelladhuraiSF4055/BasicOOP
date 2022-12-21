using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineHospital
{
    public class DoctorDetails
    {
        public static int s_doctorID=300;
        public string DoctorID { get; }
        public string DoctorName { get; set; }
        public int Experience { get; set; } 
        public string Specialization { get; set; }
        public int Fees { get; set; }
        public List<string> AvailableSlots { get; set; }

        public DoctorDetails()
        {
            DoctorID="Enter DoctorID";
            Specialization="Enter Specialization";
        }
        public DoctorDetails(string doctorName,int experience,string specialization,int fees,List<string>availableSlots)
        {
            s_doctorID++;
            DoctorID="DID"+s_doctorID;
            DoctorName=doctorName;
            Experience=experience;
            Specialization=specialization;
            Fees=fees;
            AvailableSlots=availableSlots;
        }
    }
}