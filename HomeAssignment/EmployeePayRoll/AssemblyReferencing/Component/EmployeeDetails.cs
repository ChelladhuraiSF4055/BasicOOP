using System;
namespace Component
{
    public enum WorkLocation{Select,Eymard,Mathura,Karuna}
    public enum Gender {Select,Male,Female}
    public class EmployeeDetails
    {
        private static int s_employeeId=1000;
        public string  EmployeeID{ get;}
        public string Name { get; set; }
        public  string Role { get; set; }
        public WorkLocation WorkLocation { get; set; }
        public string TeamName{ get; set; }
        public DateTime DateOfJoin {get; set;}
        public int WorkDays{ get; set; }
        public int Leave {get; set;}
        public Gender Gender { get; set; }
       

    public EmployeeDetails ()
    {
        Name="Enter Your name: ";
        Role="Enter Your role:";
        WorkLocation=WorkLocation.Select;
        Gender=Gender.Select;
        TeamName="Enter Team Name";
    }

    public EmployeeDetails(string name,string role,WorkLocation workLocation,
    string teamName,DateTime dateOfJoin, int workDays,int leave, Gender gender)
    {
        s_employeeId++;
        EmployeeID="SF"+s_employeeId;
        Name=name;
        Role=role;
        WorkLocation=workLocation;
        Gender=gender;
        WorkDays=workDays;
        Leave=leave;
        DateOfJoin=dateOfJoin;
        TeamName=  teamName;
    }

    public int CalculateSalary(int salary)
    {
         return((WorkDays-Leave)*salary);
         
    }
    }
    
}


