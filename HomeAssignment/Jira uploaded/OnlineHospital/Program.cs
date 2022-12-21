using System;
using System.Collections.Generic;
namespace OnlineHospital;
public class Program
{
    public static void Main(string[] args)
    {
        List<PatientDetials> patientList = new List<PatientDetials>();
        List<DoctorDetails> doctorList = new List<DoctorDetails>();
        List<AppoinmentDetails> appoinmentList = new List<AppoinmentDetails>();

        PatientDetials patient1 = new PatientDetials("Arun", 45, Gender.Male, 1000);
        patientList.Add(patient1);
        PatientDetials patient2 = new PatientDetials("Kumar", 50, Gender.Male, 500);
        patientList.Add(patient2);
        PatientDetials patient3 = new PatientDetials("Malar", 30, Gender.Female, 100);
        patientList.Add(patient3);
        PatientDetials patient4 = new PatientDetials("Selvi", 20, Gender.Female, 50);
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

        int choice;
        do
        {
            Console.WriteLine("Enter choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            if (choice == 2)
            {
                int action = 0;
                do
                {

                    bool isValid = false;
                    PatientDetials commonPatient = new PatientDetials();
                    Console.WriteLine("Enter Patient ID: ");
                    string patientID = Console.ReadLine();
                    //Validating Patient ID
                    foreach (PatientDetials patient in patientList)
                    {
                        if (patientID == patient.PatientID)
                        {
                            isValid = true;
                            commonPatient = patient;
                        }
                    }
                    if (!isValid)
                    {
                        Console.WriteLine("Invalid Patient ID");
                    }
                    else if (isValid)
                    {
                        DoctorDetails pickDoctor = new DoctorDetails();
                        Console.WriteLine("Enter action: ");
                        action = Convert.ToInt32(Console.ReadLine());
                        if (action == 1)
                        {
                            //Displaying available doctors & their details
                            foreach (DoctorDetails doctor in doctorList)
                            {
                                Console.WriteLine($"DoctorName: {doctor.DoctorName} DoctorID:{doctor.DoctorID} Specialization: {doctor.Specialization} Experience:{doctor.Experience} Fees: {doctor.Fees}\nAvailable Slots: ");
                                foreach (string i in doctor.AvailableSlots)
                                {
                                    Console.Write(i + " ");
                                }
                                Console.WriteLine();
                            }
                            Console.Write("Select Doctor ID:");
                            string doctorID = Console.ReadLine();
                            Console.WriteLine("Enter Appointment Date as dd/MM/yyyy:");
                            DateTime appointmentDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                            Console.WriteLine("Appointment Slot: ");
                            string appointmentSlot = Console.ReadLine();
                            //locating & Checking doctor availability
                            bool isDoctor = false;
                            foreach (DoctorDetails doctor in doctorList)
                            {
                                if (doctor.DoctorID == doctorID)
                                {
                                    isDoctor = true;
                                    pickDoctor = doctor;
                                    bool isNotContains = false;
                                    foreach (AppoinmentDetails appointment in appoinmentList)
                                    {
                                        if (!doctor.AvailableSlots.Contains(appointmentSlot) || appointment.AppointmentDate == appointmentDate)
                                        {
                                            isNotContains = true;
                                        }
                                    }
                                    if (isNotContains)
                                    {
                                        Console.WriteLine("Can't book on that time");
                                    }
                                    else if (!isNotContains)
                                    {
                                        Console.WriteLine("Doctor is available at that time");
                                        if (appointmentDate > DateTime.Now)
                                        {
                                            appoinmentList.Add(new AppoinmentDetails(commonPatient.PatientID, pickDoctor.DoctorID, appointmentDate, appointmentSlot, Status.Booked, pickDoctor.Fees));
                                            commonPatient.Book(pickDoctor.Fees);
                                            Console.WriteLine("Appointment Booked");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Can book only for upcoming days");
                                        }
                                    }

                                }

                            }
                            if (!isDoctor)
                            {
                                Console.WriteLine("Invalid Doctor ID");
                            }


                        }
                        else if (action == 2)
                        {
                            foreach (AppoinmentDetails appoinment in appoinmentList)
                            {
                                Console.WriteLine($"Appointment: {appoinment.AppointmentID} PatientID:{appoinment.PatientID} DoctorID: {appoinment.DoctorID}");
                                Console.WriteLine($"AppoinmentDate: {appoinment.AppointmentDate.ToShortDateString()} Slot: {appoinment.AppoinmentSlot} Status: {appoinment.Status} Fee: {appoinment.Fees}");
                            }
                        }
                        else if (action == 3)
                        {
                            bool check = false;
                            foreach (AppoinmentDetails appointment in appoinmentList)
                            {
                                if (commonPatient.PatientID == appointment.PatientID && appointment.Status == Status.Booked && appointment.AppointmentDate > DateTime.Now)
                                {
                                    check = true;
                                    Console.WriteLine($"Appointment ID: {appointment.AppointmentID} Appointment Date: {appointment.AppointmentDate} Doctor ID: {appointment.DoctorID}\n Status: {appointment.Status}");
                                }
                            }
                            if (!check)
                            {
                                Console.WriteLine("No appointment yet  to found");
                            }
                            else
                            {
                                Console.Write("Enter Appointment ID to cancel: ");
                                string appointmentID = Console.ReadLine();
                                foreach (AppoinmentDetails appointment in appoinmentList)
                                {
                                    if (appointment.AppointmentID == appointmentID && commonPatient.PatientID == appointment.PatientID && appointment.Status == Status.Booked && appointment.AppointmentDate > DateTime.Now)
                                    {
                                        appointment.Cancel();
                                        Console.WriteLine($"{appointment.AppointmentID} is Cancelled");
                                    }
                                }
                            }
                        }
                        else if (action == 4)
                        {
                            Console.Write("Enter the amount to be recharged to Wallet Balance:");
                            int amount = Convert.ToInt32(Console.ReadLine());
                            commonPatient.Recharge(amount);
                            Console.WriteLine("Recharged");
                        }

                    }
                } while (action != 5);
            }
        } while (choice != 3);
    }
}