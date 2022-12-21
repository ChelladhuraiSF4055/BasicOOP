using System;
using System.Collections.Generic;
using Component;
namespace Application;
class Program{
    public static void Main(string[] args)
    {
        int choice;
        List<EmployeeDetails>employeeList=new List<EmployeeDetails>();
        do
        {
            Console.WriteLine("Press: \n1.Registration\n2.Login\n3.Exit");
            choice=int.Parse(Console.ReadLine());

            if(choice==1)
            {
                Console.WriteLine("Enter Employee name: ");
                string name=Console.ReadLine();
                Console.WriteLine("Enter Your role: ");
                string role=Console.ReadLine();
                Console.WriteLine("Enter Your WorkLocation: Eymard/Mathura/Karuna");
                WorkLocation workLoc=Enum.Parse<WorkLocation>(Console.ReadLine(),true);
                Console.WriteLine("Enter Your Gender: Male/Female");
                Gender gender=Enum.Parse<Gender>(Console.ReadLine(),true);
                Console.WriteLine("Enter Your Team Name: ");
                string teamName=Console.ReadLine();
                Console.WriteLine("Enter date of joining in dd/MM/yyyy: ");
                DateTime dateOfJoin=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                Console.WriteLine("Enter number of working days in month: ");
                int workDays=int.Parse(Console.ReadLine());
                Console.WriteLine("Enter number of leave taken: ");
                int leave=int.Parse(Console.ReadLine());

                EmployeeDetails employee=new EmployeeDetails(name,role,workLoc,teamName,dateOfJoin,workDays,leave,gender);
                Console.WriteLine($"Your Employee ID is: {employee.EmployeeID}");

                employeeList.Add(employee);
            }

            else if(choice==2)
            {
                int flag=0;
                Console.Write("Enter your Employee ID: ");
                string employeeID=Console.ReadLine();
                foreach(EmployeeDetails employeeInfo in employeeList)
                {
                    if(employeeInfo.EmployeeID==employeeID)
                    {
                        flag=1;   
                        Console.WriteLine("Press:\n1.Calculate salary\n2.display details\n3.exit");
                        int action=Convert.ToInt32(Console.ReadLine());
                        if(action==1)
                        {
                            Console.WriteLine($"Your salary for this month is:{employeeInfo.CalculateSalary(500)}");
                        }
                        else if(action==2)
                        {
                            Console.WriteLine($"Employee ID:{employeeInfo.EmployeeID}\tName{employeeInfo.Name}");
                            Console.WriteLine($"Role: {employeeInfo.Role}\tAvailable in:{employeeInfo.WorkLocation}");
                            Console.WriteLine($"Team Name:{employeeInfo.TeamName}\tGender: {employeeInfo.Gender}");
                            Console.WriteLine($"Date of joining: {employeeInfo.DateOfJoin}\nWorkingDays:{employeeInfo.WorkDays.ToString("dd")}\nLeaves:{employeeInfo.Leave}");
                        }
                    }
                }
                if(flag==0)
                {
                    Console.WriteLine("User Invalid ID");
                }        
            }
        }while(choice!=3);
    }
}