using System;
/// <summary>
/// namespace Used to process the college admission with this application
/// </summary>
namespace CollegeAdmission
{
    /// <summary>
    /// Enum Genders Used to declare standard options
    /// </summary>
    public enum Gender {Select, Male, Female, Transgender}
    /// <summary>
    /// Class Student Details Used to provide template to object instance
    /// </summary>
    public class StudentDetails
    {
        /// <summary>
        /// static field Used to assign Unique student ID 
        /// </summary>
        private static int s_studentID=3000;
        /// <summary>
        /// Property StudentID Used to display student ID
        /// </summary>
        public string StudentID { get; }
        ///<summary>
        /// Field _name Used to store Student names
        /// </summary>
        private string _name;
        ///<summary>
        /// Property Express and assign value to & from name field
        /// </summary>
        public string Name{get{return _name;}set{_name=value;} }
        /// summary  
        /// Property FatherName - A Auto Implemented Property Used to recieve Father name
        /// </summary>
        public string FatherName { get; set; }
        /// <summary>
        /// Property Gender of Type Enum: Used to select student Gender Information
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Property DOB of type DateTime Used to receive to Date Of Birth 
        /// </summary>
        public DateTime DOB { get; set; }
        /// <summary>
        /// Property Phone Used for receiving phone number
        /// </summary>
        public long Phone {get; set; }
        /// <summary>
        /// Property Physics Used to initialize Physics Marks obtained by student
        /// </summary>
        /// <value>Value limit 0 to 100</value>
        public int Physics { get; set; }
        /// <summary>
        /// Property Chemistry Used to initialize Chemistry Marks obtained by the student
        /// </summary>
        /// <value>Value limit to 0 to 100</value>
        public int Chemistry { get; set; }
        /// <summary>
        /// Property Maths Used to initialize Maths Marks obtained by the student
        /// </summary>
        /// <value>Value limit to 0 to 100</value>
        public int Maths { get; set; }

        ///<summary>
        /// Default Constructors of <see cref="StudentDetails" />class used to initialize values to its properties
        /// </summary>
        public StudentDetails ()
        {
            Name ="Enter Your Name";
            FatherName="Enter Your Father Name";
            Gender=Gender.Select;
        }

        /// <summary>
        /// Constructor of<see cref="StudentDetails" /> class used to initialize value before creation on object
        /// </summary>
        /// <param name="name">Parameter name used to initialize a Student's Name to Name</param>
        /// <param name="fatherName">Parameter fatherName used to initialize Father Name of student</param>
        /// <param name="gender">Parameter gender used to initialize Student's Gender Information</param>
        /// <param name="dob">Parameter dob used to receive Student's Date of Birth</param>
        /// <param name="phone">Parameter phone used to initialize Student's Phone Number</param>
        /// <param name="physics">Parameter physics used to initalize Physics marks obtained</param>
        /// <param name="chemistry">Parameter chemistry used to initialize Chemistry marks obtained</param>
        /// <param name="maths">Parameter maths used to initialize Maths marks obtained</param>
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
            /// <summary>
            /// Check if Student is Eligible for Admission or Not
            /// </summary>
            /// <param name="cutoff">Parameter cutoff used to set cutoff value for admission</param>
            /// <returns>True/False</returns>
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