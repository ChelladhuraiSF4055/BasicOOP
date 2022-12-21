using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineHospital
{
    public static class OperationClaass
    {
        static List<PatientDetials>patientList=new List<PatientDetials>();
        static List<DoctorDetails>doctorList = new List<DoctorDetails>();
        static List<AppoinmentDetails>appoinmentList = new List<AppoinmentDetails>();
        static PatientDetials currentPatient=new PatientDetials();
        public  static void MainMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("*****Main Menu*****");
                Console.WriteLine("\t1.UserRegistration\n\t2.UserLogin\n\t3.Exit");
                choice=Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1: 
                    {
                        Console.WriteLine("*****Patient Registraiton*****");
                        PatientRegistration();
                        break;
                    }
                    case 2: 
                    {
                        Console.WriteLine("*****User Login*****");
                        UserLogin();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("*****Exit*****");
                        break;
                    }
                }
            }while(choice!=3);
            
        }
    
        public static void PatientRegistration()
        {
            Console.Write("Enter Patient Name: ");
            string name=Console.ReadLine();
            Console.Write("Enter Age: ");
            int age=Convert.ToInt32(System.Console.ReadLine());
            Console.Write("Enter Gender: ");
            Gender gender=Enum.Parse<Gender>(System.Console.ReadLine().ToLower());
            System.Console.WriteLine("Enter Wallet Balance: ");
            int balance=Convert.ToInt32(Console.ReadLine());

            PatientDetials patient=new PatientDetials(name,age,gender,balance);
            patientList.Add(patient);
            Console.WriteLine($"Registration Successful\nYour Patient ID: {patient.PatientID}");
            
        }
    
        public static void UserLogin()
        {
            Console.Write("Enter Patient ID: ");
            string patientID=Console.ReadLine().ToUpper();
            bool isValid=false;
            foreach(PatientDetials patient in patientList)
            {
                if(patient.PatientID==patientID)
                {
                    isValid=true;
                    currentPatient=patient;
                    SubMenu();
                }
            }
            if(!isValid)
            {
                Console.WriteLine("Invalid Patient ID");
            }
        }
    
        public static void SubMenu()
        {
            int action;
            do
            {
                Console.WriteLine($"\t1.Book Appointment\n\t2.Appointment History\n\t3.Cancel Appoinment\n\t4.Wallet Recharge\n\t5.Exit");
                action=Convert.ToInt32(System.Console.ReadLine());
                switch(action)
                {
                    case 1:
                    {
                        Console.WriteLine("****Book Appointment****");
                        BookAppointment();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("****Appointment History****");
                        AppointmentHistory();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("****Cancel Appointment****");
                        CancelAppoinment();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("****Wallet Recharge****");
                        WalletRecharge();
                        break;
                    }
                    case 5:
                    {
                        Console.WriteLine("****Exit****");
                        break;
                    }
                }
            }while(action!=5);
        }
    
        public static void AppointmentHistory()
        {
            foreach(AppoinmentDetails appointment in appoinmentList)
            {
                if(currentPatient.PatientID==appointment.PatientID)
                {
                    Console.WriteLine($"Appointment ID: {appointment.AppointmentID} Appointment Date:{appointment.AppointmentDate} Status:{appointment.Status}");
                    Console.WriteLine($"Doctor ID:{appointment.DoctorID} Appointmetn Slot: {appointment.AppoinmentSlot} Fees: {appointment.Fees} ");
                }
            }
            
        }

        public static void DefaultData()
        {
        PatientDetials patient1 = new PatientDetials("Arun", 45, Gender.male, 1000);
        patientList.Add(patient1);
        PatientDetials patient2 = new PatientDetials("Kumar", 50, Gender.male, 500);
        patientList.Add(patient2);
        PatientDetials patient3 = new PatientDetials("Malar", 30, Gender.female, 100);
        patientList.Add(patient3);
        PatientDetials patient4 = new PatientDetials("Selvi", 20, Gender.female, 50);
        patientList.Add(patient4);

        DoctorDetails doctor1 = new DoctorDetails("John", 20, "General", 200, new List<string> { "6.00-6.30", "6.30-7.00", "7.00-7.30", "7.30-8.00", "8.00-8.30", "8.30-9.00" });
        doctorList.Add(doctor1);
        DoctorDetails doctor2 = new DoctorDetails("Saravanan", 30, "Heart", 500, new List<string> { "6.00-6.30", "6.30-7.00", "7.00-7.30", "7.30-8.00" });
        doctorList.Add(doctor2);
        DoctorDetails doctor3 = new DoctorDetails("Kavi", 40, "Ortho", 100, new List<string> { "7.30-8.00", "8.00-8.30", "8.30-9.00" });
        doctorList.Add(doctor3);

        AppoinmentDetails appointment1 = new AppoinmentDetails("PID1001", "DID301", new DateTime(2022, 4, 27), "6.00-6.30", Status.Booked, 200);
        appoinmentList.Add(appointment1);
        AppoinmentDetails appointment2 = new AppoinmentDetails("PID1002", "DID302", new DateTime(2022, 4, 27), "6.30-7.00", Status.Booked, 500);
        appoinmentList.Add(appointment2);
        }
    
        public static void WalletRecharge()
        {
            System.Console.Write("Enter the amount to be recharged: ");
            int amount=Convert.ToInt32(Console.ReadLine());
            currentPatient.Recharge(amount);
            Console.WriteLine($"Recharge successful.\nAmount Deducted: {amount}");
            Console.WriteLine($"Your Wallet Balance is: {currentPatient.WalletBalance}");
        }
    
        public static void BookAppointment()
        {
            foreach(DoctorDetails doctor in doctorList)
            {
                Console.WriteLine($"Doctor Name: {doctor.DoctorName} Doctor ID: {doctor.DoctorID}");
                Console.WriteLine($"Appointment slots:");
                PrintSlot(doctor.AvailableSlots);
                Console.WriteLine($"Specialzation: {doctor.Specialization} Experience: {doctor.Experience} Fee: {doctor.Fees}");
            }
            Console.Write($"Select Doctor ID: ");
            string doctorID=Console.ReadLine().ToUpper();
            Console.Write("Choose Appointment Date as dd/MM/yyyy format: ");
            DateTime appointmentDate=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            Console.Write("Choose Appointment slot: ");
            string appointmentSlot=Console.ReadLine();
            bool isExist=false;
            bool isAvailable=false;
            bool isValid=false;
            int fees=0;
            // bool isAvailable=false;
            foreach(DoctorDetails doctor in doctorList)
            {
                //locating doctor
                if(doctor.DoctorID==doctorID)
                {
                    isExist=true;
                    if(doctor.AvailableSlots.Contains(appointmentSlot))
                    {
                        isValid=true;
                        foreach(AppoinmentDetails appointment in appoinmentList)
                        {
                            //locating particular doctor in appointment List & checking his availablity
                            if(appointment.DoctorID==doctorID)
                            {
                                //checking his slot was booked
                                if(appointment.AppointmentDate==appointmentDate && appointment.AppoinmentSlot==appointmentSlot)
                                {
                                    //isAvailable=false;
                                    Console.WriteLine($"{doctor.DoctorName} is Not Available on chosen slot. try someother date or slots");
                                }
                                else
                                {
                                    //Book Slot is appointment is in future
                                    if(DateTime.Now<=appointmentDate)
                                    {
                                        fees=doctor.Fees;
                                        isAvailable=true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Booking should be in future");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if(!isExist)
            {
                Console.WriteLine("Entered Doctor ID is Invalid");
            }
            if(!isValid)
            {
                Console.WriteLine("Doctor won't be available in chosen slot.");
            }
            if(isAvailable)
            {
                AppoinmentDetails incl=new AppoinmentDetails(currentPatient.PatientID,doctorID,appointmentDate,appointmentSlot,Status.Booked,fees);
                appoinmentList.Add(incl);
                Console.WriteLine("Your appointment has been fixed.");
            }
        }

        public static void PrintSlot(List<string>slots)
        {
            foreach(string slot in slots)
            {
                Console.Write($"{slot+" "}");
            }
        }
        
        public static void CancelAppoinment()
        {
            bool isExist=false;
            foreach(AppoinmentDetails appointment in  appoinmentList)
            {
                if(appointment.Status==Status.Booked && appointment.AppointmentDate>DateTime.Now)
                {
                    isExist=true;
                    Console.WriteLine($"Appointment ID: {appointment.AppointmentID} Appointment Date:{appointment.AppointmentDate} Status:{appointment.Status}");
                    Console.WriteLine($"Doctor ID:{appointment.DoctorID} Appointmetn Slot: {appointment.AppoinmentSlot} Fees: {appointment.Fees} ");
                    Console.WriteLine();
                }
            }    
            if(!isExist)
            {
                Console.WriteLine($"You've No Appointments to cancel.");
            }   
            else
            {
                Console.WriteLine("Enter an Appointment ID to cancel: ");
                string appointmentID=Console.ReadLine().ToUpper();
                bool isValid=false;
                foreach(AppoinmentDetails appointment in appoinmentList )
                {
                    if(appointment.AppointmentID==appointmentID)
                    {
                        isValid=true;
                        appointment.Status=Status.Cancelled;
                        Console.WriteLine("Your Appointment has been cancelled.");
                    }
                }
                if(!isValid)
                {
                    Console.WriteLine("Invalid Appointment ID");
                }
            }

        }
    
    }
}