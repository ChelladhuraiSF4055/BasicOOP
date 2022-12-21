using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum Status{Default,Booked,Cancelled}
    public class AdmissionDetails
    {
        private  static int admissionID=1000;
        public string AdmissionID {get; }
        public string StudentID { get; set;}
        public string DepartmentID{get; set;}
        public DateTime AdmissionDate {get; set;}
        public Status Status { get; set; }
        
        public AdmissionDetails()
        {
            StudentID="Enter student ID";
            DepartmentID="Enter Department ID";
        }

        public AdmissionDetails(string studentID,string departmentId, DateTime admissionDate,Status status)
        {
            admissionID++;
            AdmissionID="AID"+admissionID;
            StudentID=studentID;
            DepartmentID=departmentId;
            AdmissionDate=admissionDate;
            Status=status;
        }  

        public void BookAdmission()
        {
            Status=Status.Booked;
        }

        public void CancelAdmission()
        {
            Status=Status.Cancelled;
        }
         
    }
}