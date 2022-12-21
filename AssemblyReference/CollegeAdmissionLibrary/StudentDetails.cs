using System;
namespace CollegeAdmissionLibrary
{
    public enum Gender {Select, Male, Female, Transgender}
    public class StudentDetails
    {
        private static int s_studentID=3000;
        public string StudentID { get; }
        //Field describe the attribute of class
        private string _name;

        //Property Express Field information to outside world
        public string Name{get{return _name;}set{_name=value;} }

        //Auto Implemented Property
        public string FatherName { get; set; }

        public Gender Gender { get; set; }

        public DateTime DOB { get; set; }

        public long Phone {get; set; }

        public int Physics { get; set; }

        public int Chemistry { get; set; }

        public int Maths { get; set; }

        //Default Constructors
        public StudentDetails ()
        {
            Name ="Enter Your Name";
            _name="Enter name";
            StudentID="Enter student ID";
            FatherName="Enter Your Father Name";
            Gender=Gender.Select;
        }

        public StudentDetails(string name,string fatherName, Gender gender, DateTime dob,
                                long phone, int physics, int chemistry, int maths)
            {
                s_studentID++;
                StudentID="SF"+s_studentID;
                Name=name;
                FatherName=fatherName;
                Gender=gender;
                DOB=dob;
                Phone=phone;
                Physics=physics;
                Chemistry=chemistry;
                Maths=maths;
            }
            public bool CheckEligibility(double cutoff)
            {
                int total=Physics+Chemistry+Maths;
                double average=(double)total/3;
                if(average>=cutoff)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    }
}