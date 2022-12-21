using System;
using System.Collections.Generic;
namespace StudentAdmission;

class Program
{
    public static void Main(string[] args)
    {
        List<StudentDetails> studentList = new List<StudentDetails>();

        StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 1), Gender.Male, 95, 95, 95);
        studentList.Add(student1);
        StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 1, 11), Gender.Male, 95, 95, 95);
        studentList.Add(student2);

        List<DepartmentDetails> departmentList = new List<DepartmentDetails>();

        DepartmentDetails department1 = new DepartmentDetails(Department.EEE, 29);
        departmentList.Add(department1);
        DepartmentDetails department2 = new DepartmentDetails(Department.CSE, 29);
        departmentList.Add(department2);
        DepartmentDetails department3 = new DepartmentDetails(Department.MECH, 30);
        departmentList.Add(department3);
        DepartmentDetails department4 = new DepartmentDetails(Department.ECE, 30);
        departmentList.Add(department4);

        List<AdmissionDetails> admissionList = new List<AdmissionDetails>();

        AdmissionDetails admission1 = new AdmissionDetails("SF3001", "DID101", new DateTime(2022, 5, 11), Status.Booked);
        admissionList.Add(admission1);
        AdmissionDetails admission2 = new AdmissionDetails("SF3002", "DID102", new DateTime(2022, 5, 12), Status.Booked);
        admissionList.Add(admission2);

        int choice;
        do
        {
            Console.WriteLine("Press:\n1.StudentRegistration\n2.StudentLogin\n3.Check Department Details\n4.Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 1)
            {

            }
            else if (choice == 2)
            {
                StudentDetails commonUserName = new StudentDetails();
                Console.WriteLine("Enter StudentID:");
                string studentID = Console.ReadLine();
                //locating Student Detials
                bool isAvailable = false;
                foreach (StudentDetails student in studentList)
                {
                    if (student.StudentID == studentID)
                    {
                        isAvailable = true;
                        commonUserName = student;
                    }
                }
                if (isAvailable)
                {
                    char action;
                    do
                    {
                        Console.WriteLine("Press:\na.Check Eligibility\nb.Show Details\nc.Take Admission\nd.Cancel Admission\ne.Show Admission Details\nf.Exit");
                        action = char.Parse(Console.ReadLine());
                        //Login Submenu
                        AdmissionDetails bookAdmission = new AdmissionDetails();
                        DepartmentDetails selectDepartment = new DepartmentDetails();
                        if (action == 'a')
                        {
                            if (commonUserName.CheckEligiblity(75.0))
                            {
                                Console.WriteLine("Student is eligible");
                            }
                            else
                            {
                                Console.WriteLine("Student is not eligible");
                            }
                        }
                        else if (action == 'b')
                        {
                            foreach (StudentDetails student in studentList)
                            {
                                if (studentID == student.StudentID)
                                {
                                    Console.WriteLine($"StudentID|{commonUserName.StudentID}\tStudent Name|{commonUserName.StudentName}\tFatherName|{commonUserName.FatherName}");
                                    Console.WriteLine($"DOB|{commonUserName.DOB.ToShortDateString()}\tGender|{commonUserName.Gender}");
                                    Console.WriteLine($"Physics|{commonUserName.Physics}\tChemistry|{commonUserName.Chemistry}\tMaths{commonUserName.Maths}");
                                }
                            }
                        }
                        else if (action == 'c')
                        {
                            foreach (DepartmentDetails department in departmentList)
                            {
                                Console.WriteLine($"Department ID|{department.DepartmentID}\tDepartmentName|{department.Department}\tNumberOfSeats|{department.NumberOfSeats}");
                            }
                            Console.WriteLine("Select Department ID:");
                            string departmentID = Console.ReadLine();
                            bool check = false;
                            //verifying the department
                            foreach (DepartmentDetails department in departmentList)
                            {
                                if (department.DepartmentID == departmentID)
                                {
                                    check = true;
                                    selectDepartment = department;
                                }
                            }
                            if (check == false)
                            {
                                Console.WriteLine("Enter valid Department ID.");
                            }
                            else if (check == true)
                            {
                                if (commonUserName.CheckEligiblity(75))
                                {
                                    bool admitted = false;
                                    foreach (AdmissionDetails admission in admissionList)
                                    {
                                        if (commonUserName.StudentID == admission.StudentID)
                                        {
                                            admitted = true;
                                            Console.WriteLine("You've already been admitted");
                                        }
                                    }
                                    if (admitted == false)
                                    {
                                        bookAdmission = new AdmissionDetails(commonUserName.StudentID, departmentID, DateTime.Now, Status.Booked);
                                        selectDepartment.AddSeat();
                                        admissionList.Add(bookAdmission);

                                        Console.WriteLine($"Admission took successfully, Your Admission ID is: :{bookAdmission.AdmissionID}");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You are not eligible");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid UserID");
                            }
                        }
                        else if (action == 'd')
                        {
                            bool admitted = false;
                            string answer = "";
                            foreach (AdmissionDetails admission in admissionList)
                            {
                                if (commonUserName.StudentID == admission.StudentID && admission.Status == Status.Booked)
                                {
                                    admitted = true;
                                    bookAdmission = admission;
                                    Console.WriteLine($"AdmissionID: {admission.AdmissionID} StudentID:{admission.StudentID}\nDepartmene ID: {admission.DepartmentID} Status:{admission.Status} ");
                                    Console.Write($"Do you want to cancel(yes/no):");
                                    answer = Console.ReadLine().ToLower();
                                }
                            }
                            if (admitted == true && answer == "yes")
                            {
                                Console.WriteLine("Admission Cancelled");
                                foreach (DepartmentDetails department in departmentList)
                                {
                                    if (selectDepartment.DepartmentID == bookAdmission.DepartmentID)
                                    {
                                        selectDepartment = department;
                                    }
                                }

                                bookAdmission.CancelAdmission();
                                admissionList.Remove(bookAdmission);
                                selectDepartment.RemoveSeat();
                                Console.WriteLine("Seat cancelled succesfully");
                            }

                            if (admitted == false)
                            {
                                Console.WriteLine("You've not admitted yet");
                            }

                        }
                        else if (action == 'e')
                        {
                            bool admitted=true;
                            foreach (AdmissionDetails admission in admissionList)
                            {
                                if (admission.StudentID == studentID)
                                {
                                    admitted=true;
                                    Console.WriteLine($"Admission ID|{admission.AdmissionID}\tStudent ID|{admission.StudentID}\tDepartment ID|{admission.DepartmentID}\tAdmissionDate|{admission.AdmissionDate} ");
                                }
                            }
                            if(!admitted)
                            {
                                Console.WriteLine("You've not been admitted yet");
                            }
                        }
                    } while (action != 'f');
                }
            }
            else if (choice == 3)
            {
                foreach (DepartmentDetails department in departmentList)
                {
                    Console.WriteLine($"Department ID:{department.DepartmentID}\tDepartmentName:{department.Department}\tNumberOfSeats:{department.NumberOfSeats}");
                }
            }

        } while (choice != 4);
    }
}
