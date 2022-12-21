using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public static class Operations
    {
        public static List<StudentDetails>studentList=new List<StudentDetails>();
        public static List<DepartmentDetails>departmentList=new List<DepartmentDetails>();
        public static List<AdmissionDetails> admissionList = new List<AdmissionDetails>();
        static StudentDetails currentStudent;

        public static void MainMenu()
        {
            int option;
            do
            {
                System.Console.WriteLine("********Main Menu********");
                Console.WriteLine("\t1.Registration\n\t2.Login\n\t3.Exit");

                 option= int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            Console.WriteLine("******Registration Form******");
                            Registration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("******Login Form******");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("******Exit from Main Menu******");
                            break;
                        }
                }

            } while (option != 3);
        }
    
        public static void Registration()
        {
            Console.Write("Enter Your Name: ");
            string name=Console.ReadLine();
            Console.Write("Enter Your Father Name: ");
            string fatherName=Console.ReadLine();
            Console.Write("Enter Your DOB in dd/MM/yyyy: ");
            DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Enter Your Gender(Male/Female): ");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine());
            Console.Write("Enter your Phone Number: ");
            long phone=Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Your Physics mark: ");
            int physics=Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Your Chemistry mark: ");
            int chemistry=Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Maths Mark: ");
            int maths=Convert.ToInt32(Console.ReadLine());

            StudentDetails students= new StudentDetails(name,fatherName,dob,gender,phone,physics,chemistry,maths);
            studentList.Add(students);
            Console.WriteLine($"Registration successful\nYour ID is {students.StudentID}");
            
        }
    
        static void Login()
        {
            Console.Write("Enter Your Student ID: ");
            string studentID=Console.ReadLine().ToUpper();
            bool check=true;
            foreach(StudentDetails student in studentList)
            {
                if(student.StudentID==studentID)
                {
                    check=false;
                    Console.WriteLine("Login successful");
                    currentStudent=student;
                    SubMenu();
                }
            }
            if(check)
            {
                Console.WriteLine("Invalid User ID");
            }
        }
    
        static void SubMenu()
        {
            int action;
            do
            {
            Console.WriteLine("******Sub Menu******");
            Console.WriteLine("\t1.Check Eligibility\n\t2.Show Details\n\t3.Take Admission");
            Console.WriteLine("\t4.Cancel Admission\n\t5.Show Admission Detials\n\t6.Exit");
            action=int.Parse(Console.ReadLine());
            switch(action)
            {
                case 1:
                {
                    Console.WriteLine("******Check Eligibility******");
                    CheckEligiblity();
                    break;
                }
                case 2: 
                {
                    Console.WriteLine("******Show Details******");
                    ShowDetails();
                    break;
                }
                case 3: 
                {
                    Console.WriteLine("******Take Admission******");
                    TakeAdmission();
                    break;
                }
                case 4: 
                {
                    Console.WriteLine("******Cancel Admission******");
                    CancelAdmission();
                    break;
                }
                case 5: 
                {
                    Console.WriteLine("******Show Admission Details******");
                    ShowAdmissionDetails();
                    break;
                }
                case 6: 
                {
                    Console.WriteLine("******Exit******");
                    break;
                }
            }
                
            }while(action!=6);
           
        }
    
        public static void DefaultData()
        {
            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 1), Gender.Male,928373923, 95, 95, 95);
            studentList.Add(student1);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 1, 11), Gender.Male,9329389838, 95, 95, 95);
            studentList.Add(student2);

            DepartmentDetails department1 = new DepartmentDetails(Department.EEE, 29);
            departmentList.Add(department1);
            DepartmentDetails department2 = new DepartmentDetails(Department.CSE, 29);
            departmentList.Add(department2);
            DepartmentDetails department3 = new DepartmentDetails(Department.MECH, 30);
            departmentList.Add(department3);
            DepartmentDetails department4 = new DepartmentDetails(Department.ECE, 30);
            departmentList.Add(department4);
            
            AdmissionDetails admission1 = new AdmissionDetails(student1.StudentID,department1.DepartmentID, new DateTime(2022, 5, 11), Status.Booked);
            admissionList.Add(admission1);
            AdmissionDetails admission2 = new AdmissionDetails(student2.StudentID,department2.DepartmentID, new DateTime(2022, 5, 12), Status.Booked);
            admissionList.Add(admission2);
        }
    
        public static void  CheckEligiblity()
        {
            bool eligible=currentStudent.CheckEligiblity(75.0);
            if(eligible)
            {
                Console.WriteLine("You are Eligible");
            }
            else
            {
                Console.WriteLine("You are'nt Eligible");
            }
        }
    
        public static void ShowDetails()
        {
            Console.WriteLine($"Student Name: {currentStudent.StudentName} Student ID: {currentStudent.StudentID} FatherName: {currentStudent.FatherName}");
            Console.WriteLine($"Gender: {currentStudent.Gender} DOB: {currentStudent.DOB} Phone: {currentStudent.Phone}");
            Console.WriteLine($"Physics mark: {currentStudent.Physics} Chemistry mark: {currentStudent.Chemistry} Maths mark: {currentStudent.Maths}");
        }

        static void ShowAdmissionDetails()
        {
            bool isAvailable=false;
            foreach(AdmissionDetails admission in admissionList)
            {
                if(currentStudent.StudentID==admission.StudentID)
                {
                    isAvailable=true;
                    Console.WriteLine($"Admission ID: {admission.AdmissionID} Admission Date: {admission.AdmissionDate.ToString("dd/MM/yyyy")} Department ID: {admission.DepartmentID}");
                    Console.WriteLine($"Student ID:{admission.StudentID} Status: {admission.Status}");
                }
                if(!isAvailable)
                {
                    Console.WriteLine("You've not take admission yet");
                }
            }
        }
    
        static void CancelAdmission()
        {
            //fetch admission List
            foreach(AdmissionDetails admission in admissionList)
            {
            //check student id and admission status is Booked
                if(admission.StudentID==currentStudent.StudentID && admission.Status==Status.Booked)
                {
            //admission status is cancelled
                    admission.Status=Status.Cancelled;
            //locate & return seat to the department
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(department.DepartmentID==admission.DepartmentID)
                        {
            //Increase a seat to that department
                            department.AddSeat();
                        }
                    }
                }
            }
            Console.WriteLine("Your Admission was cancelled successfully");
        }
    
        static void TakeAdmission()
        {
            //show department details
            foreach(DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"Department: {department.Department} DepartmentID: {department.DepartmentID} Number of seats: {department.NumberOfSeats}");
            }
            //Ask a department ID for process admission
            Console.Write("Enter department ID: ");
            string departmentID=Console.ReadLine();
            //Fetch department details
            bool temp=true;
            foreach(DepartmentDetails department in departmentList)
            {
            //check student id and admission status is admitted
                if(department.DepartmentID==departmentID)
                {
                    temp=false;
            //yes - check number of seat > 0 - no - No seat available
                    if(department.NumberOfSeats>0)
                    {
                        if(currentStudent.CheckEligiblity(75))
                        {
                            int count=0;
                            //yes - fetch admission list - count if he had admission - yes - show you already taken admission
                            foreach(AdmissionDetails admission in admissionList)
                            {
                                if(currentStudent.StudentID==admission.StudentID && admission.Status==Status.Booked)
                                {
                                    count++;
                                }
                            }
                            if(count>0)
                            {
                            //yes - check he is eligible - no - Not eligible to take admission
                                Console.WriteLine("You've already taken admission");
                            }
                            else
                            {
                                department.RemoveSeat();
                            //no - create admission, reduce set count in department
                                AdmissionDetails admission=new AdmissionDetails(currentStudent.StudentID,department.DepartmentID,DateTime.Now, Status.Booked);
                                admissionList.Add(admission);
                            //show admission succesful
                                Console.WriteLine($"Admission was successful. Your admission ID: {admission.AdmissionID}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You are not eligible");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Seats are filled");
                    }

                }
            }
            if(temp)
            {
                Console.WriteLine("Invalid Department ID");
            }
        }
    }
}