using System;
using System.Collections.Generic;
namespace CollegeAdmission;//File Scoped namespace
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

            /*
            //student2
            Console.WriteLine("*****Registration Form2****");
            StudentDetails student2=new StudentDetails();
            student2.Name=Console.ReadLine();;//Set Operation
            Console.WriteLine("Enter Your father name: ");
            student2.FatherName=Console.ReadLine();
            Console.WriteLine("Enter Your Gender: ");
            student2.Gender=Console.ReadLine();
            Console.WriteLine("Enter DOB");
            student2.DOB=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.WriteLine("Enter Your Phone: ");
            student2.Phone=long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Physics mark: ");
            student2.Physics=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Chemistry mark: ");
            student2.Chemistry=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Maths Mark: ");
            student2.Maths=int.Parse(Console.ReadLine());
            studentList.Add(student);


            //student3
            Console.WriteLine("*****Registration Form3****");
            StudentDetails student3=new StudentDetails();
            student3.Name=Console.ReadLine();;//Set Operation
            Console.WriteLine("Enter Your father name: ");
            student3.FatherName=Console.ReadLine();
            Console.WriteLine("Enter Your Gender: ");
            student3.Gender=Console.ReadLine();
            Console.WriteLine("Enter DOB");
            student3.DOB=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.WriteLine("Enter Your Phone: ");
            student3.Phone=long.Parse(Console.ReadLine());
            Console.WriteLine("Enter Physics mark: ");
            student3.Physics=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Chemistry mark: ");
            student3.Chemistry=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Maths Mark: ");
            student3.Maths=int.Parse(Console.ReadLine());
            studentList.Add(student);
            */


            Console.WriteLine("Do You Want to add one more user? say yes/no");
            choice=Console.ReadLine().ToLower();
        }while(choice=="yes");
        

        /*
        //Printing filled form
        //student
        Console.WriteLine($"My Name is: {student.Name}\nFather Name: {student.FatherName}\nGender: {student.Gender}");
        Console.WriteLine($"DOB: {student.DOB}\nPhone: {student.Phone}\nPhysics: {student.Physics}");
        Console.WriteLine($"Chemistry: {student.Chemistry}\nMaths: {student.Maths}");
        //student2
        Console.WriteLine($"My Name is: {student2.Name}\nFather Name: {student2.FatherName}\nGender: {student2.Gender}");
        Console.WriteLine($"DOB: {student2.DOB}\nPhone: {student2.Phone}\nPhysics: {student2.Physics}");
        Console.WriteLine($"Chemistry: {student2.Chemistry}\nMaths: {student2.Maths}");
        //student3
        Console.WriteLine($"My Name is: {student3.Name}\nFather Name: {student3.FatherName}\nGender: {student3.Gender}");
        Console.WriteLine($"DOB: {student3.DOB}\nPhone: {student3.Phone}\nPhysics: {student3.Physics}");
        Console.WriteLine($"Chemistry: {student3.Chemistry}\nMaths: {student3.Maths}");
        */

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