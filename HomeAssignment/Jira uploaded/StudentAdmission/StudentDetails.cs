using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum Gender { Select,Male,Female }
    public class StudentDetails
    {
        private static int s_studentID=3000;
        public string StudentID{get;}
       public string StudentName { get; set; }
       public string FatherName { get; set; }
       public DateTime DOB{ get; set; }
       public Gender Gender { get; set; } 
       
       public long Phone { get; set; }
        public int Physics { get; set; }
        public int Chemistry{ get; set; }
        public int Maths{ get; set; }

       public StudentDetails()
       {
            Gender=Gender.Select;
       }
        public StudentDetails(string studentName,string fatherName,DateTime dob,
        Gender gender,long phone, int physics, int chemistry, int maths)
        {
            s_studentID++;
            StudentID="SF"+s_studentID;
            StudentName=studentName;
            FatherName=fatherName;
            DOB=dob;
            Gender=gender;
            Phone=phone;
            Physics=physics;
            Chemistry=chemistry;
            Maths=maths;
        }

        public bool CheckEligiblity(double cutOff)
        {
            double result=(double)(Physics+Chemistry+Maths)/3;
            return (result>cutOff);
        }

        //public  Display()

    
        
    }
}