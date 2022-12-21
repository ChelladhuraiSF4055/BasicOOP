using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineHospital
{
    public enum Status {Select,Booked,Cancelled}
    public class AppoinmentDetails
    {
        public static int s_appointmentID=500;
        public string AppointmentID { get; }
        public string DoctorID { get; set; }
        public string PatientID { get; set; }   
        public DateTime AppointmentDate { get; set; }
        public string AppoinmentSlot {get; set;}
        public Status Status { get; set; }
        public int  Fees { get; set; }

        public AppoinmentDetails()
        {
            DoctorID="Enter DoctorID";
            PatientID="Enter PatientID";
            Status=Status.Select;
        }

        public AppoinmentDetails(string patientID,string doctorID,DateTime appoinmentDate,string appoinmentSlot,Status status,int fees)
        {
            s_appointmentID++;
            AppointmentID="AID"+s_appointmentID;
            PatientID=patientID;
            DoctorID=doctorID;
            AppointmentDate=appoinmentDate;
            AppoinmentSlot=appoinmentSlot;
            Status=status;
            Fees=fees;
        }
        public void Cancel()
        {
            Status=Status.Cancelled;
        }
    }
}