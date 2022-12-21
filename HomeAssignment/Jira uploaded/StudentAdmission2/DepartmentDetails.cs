using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum Department { Default,EEE,ECE,MECH,CSE }
    public class DepartmentDetails
    {
        private static int s_departmentID=100;
        public string DepartmentID{ get; }
        public Department Department{ get; set; }
        public int NumberOfSeats { get; set; }

        public DepartmentDetails()
        {
            DepartmentID="Enter DepartmentID";
            Department=Department.Default;
        }

        public DepartmentDetails(Department department, int numberOfSeats)
        {
            s_departmentID++;
            DepartmentID="DID"+s_departmentID;
            Department=department;
            NumberOfSeats=numberOfSeats;
        }

        public void RemoveSeat()
        {
            NumberOfSeats++;
        }
        public void AddSeat()
        {
            NumberOfSeats--;
        }

    }
}