using System;
using System.Collections.Generic;
namespace Application;//File Scoped namespace
using CollegeAdmissionLibrary;
public class Program{
    public static void Main(string[] args)
    {
        string choice="";
        List<StudentDetails> studentList=new List<StudentDetails>();

        do
        {
            //Buying a file to store application forms
            Console.WriteLine("*****Registration Form****");
            //StudentDetails student=new StudentDetails();
            Console.WriteLine("Enter Your Name: ");
            string name=Console.ReadLine();
            //student.Name=name;//Set Operation
            Console.WriteLine("Enter Your father name: ");
            string fatherName=Console.ReadLine();
            //student.FatherName=Console.ReadLine();
            //Enumeration
            Console.WriteLine("Enter Your Gender: in Male/Female/Transgender");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
            //gender=(Gender)int.Parse(Console.ReadLine());

            //student.Gender=Console.ReadLine();
            Console.WriteLine("Enter DOB");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            //student.DOB=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.WriteLine("Enter Your Phone: ");
            long phone=long.Parse(Console.ReadLine());
            //student.Phone=long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Physics mark: ");
            int physics=Convert.ToInt32(Console.ReadLine());
            //student.Physics=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Chemistry mark: ");
            int chemistry=Convert.ToInt32(Console.ReadLine());
            //student.Chemistry=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Maths Mark: ");
            int maths=Convert.ToInt32(Console.ReadLine());
            //student.Maths=int.Parse(Console.ReadLine());

            StudentDetails student=new StudentDetails(name, fatherName,gender,dob,phone,physics,chemistry,maths);
            studentList.Add(student);

           
            Console.WriteLine("Do You Want to add one more user? say yes/no");
            choice=Console.ReadLine().ToLower();
        }while(choice=="yes");
        

        

        Console.WriteLine("Enter Your student ID");
        string studentID=Console.ReadLine().ToUpper();
        bool check=true;
        foreach(StudentDetails studentInfo in studentList)
        {
            if(studentInfo.StudentID==studentID)
            {check=false;
                Console.WriteLine("Registration successful.Your ID is"+studentInfo.StudentID);
                Console.WriteLine($"Student ID: {studentInfo.StudentID}\nMy Name is: {studentInfo.Name}\nFather Name: {studentInfo.FatherName}\nGender: {studentInfo.Gender}");
                Console.WriteLine($"DOB: {studentInfo.DOB}\nPhone: {studentInfo.Phone}\nPhysics: {studentInfo.Physics}");
                Console.WriteLine($"Chemistry: {studentInfo.Chemistry}\nMaths: {studentInfo.Maths}");
                bool eligibility= studentInfo.CheckEligibility(75.0);
                if(eligibility)
                {
                    Console.WriteLine("You are eligible");
                }
                else{
                    Console.WriteLine("You aren't eligible");
                }
            }
        }
        if(check)
        {
            Console.WriteLine("Invalid User ID");
        }
    }
}