using System;
using System.Collections.Generic;
namespace VaccineDrive;
class Program
{
    public static void Main(string[] args)
    {
        List<BeneficiaryClass> beneficiaryList = new List<BeneficiaryClass>();
        List<VaccinationClass> vaccinationList = new List<VaccinationClass>();
        List<VaccineClass> vaccineList = new List<VaccineClass>();

        BeneficiaryClass beneficiary1 = new("Ravichandran", Gender.Male, 8484484, "Chennai", 21);
        beneficiaryList.Add(beneficiary1);
        BeneficiaryClass beneficiary2 = new("Baskaran", Gender.Male, 8484747, "Chennai", 22);
        beneficiaryList.Add(beneficiary2);

        VaccineClass vaccine1 = new VaccineClass(VaccineName.Covishield, 50);
        vaccineList.Add(vaccine1);
        VaccineClass vaccine2 = new VaccineClass(VaccineName.Covaccine, 50);
        vaccineList.Add(vaccine2);

        VaccinationClass slot1 = new VaccinationClass("BID1001", "CID101", 1, new DateTime(2021, 11, 11));
        vaccinationList.Add(slot1);
        VaccinationClass slot2 = new VaccinationClass("BID1001", "CID101", 2, new DateTime(2022, 3, 11));
        vaccinationList.Add(slot2);
        VaccinationClass slot3 = new VaccinationClass("BID1002", "CID102", 1, new DateTime(2022, 4, 4));
        vaccinationList.Add(slot3);

        int choice;
        Console.WriteLine("Enter Choice:");
        choice = Convert.ToInt32(Console.ReadLine());
        do
        {
            if (choice == 2)
            {
                int action = 0;
                do
                {
                    //validating & Locating Beneficiary
                    bool check = false;
                    BeneficiaryClass commonBeneficiar = new BeneficiaryClass();
                    Console.Write("Enter Registration Number to continue:");
                    string registerNumber = Console.ReadLine();
                    foreach (BeneficiaryClass beneficiar in beneficiaryList)
                    {
                        if (beneficiar.RegistrationNumber == registerNumber)
                        {
                            check = true;
                            commonBeneficiar = beneficiar;
                        }
                    }
                    if (!check)
                    {
                        Console.WriteLine("Invalid Registration Number");
                    }
                    else if (check)
                    {
                        Console.WriteLine("Press\n1.Show My Details\n2.Take Admission\n3.My vaccination History\n4.Next Due Date\n5.Exit");
                        action = int.Parse(Console.ReadLine());
                        if (action == 2)
                        {
                            foreach (VaccineClass vaccine in vaccineList)
                            {
                                Console.WriteLine($"VaccineID|{vaccine.VaccineID}  VaccineName|{vaccine.VaccineName} NoOfDoseAvailable|{vaccine.NoOfDose}");
                            }
                            Console.Write("Enter a Vaccine ID: ");
                            string vaccineID = Console.ReadLine();
                            bool isAvailable = false;
                            VaccineClass selectedVaccine = new VaccineClass();
                            //verifying & Locating VaccineID
                            foreach (VaccineClass vaccine in vaccineList)
                            {
                                if (vaccineID == vaccine.VaccineID)
                                {
                                    isAvailable = true;
                                    selectedVaccine = vaccine;
                                }
                            }
                            //verifying dose Number
                            if (!isAvailable)
                            {
                                Console.WriteLine("InValid Vaccine ID");
                            }
                            else if (isAvailable)
                            {
                                VaccinationClass vaccined = new VaccinationClass();
                                int doseNumber = 0;
                                //Ensuring correct vaccine
                                foreach (VaccinationClass vaccinated in vaccinationList)
                                {
                                    if (vaccinated.VaccineID == vaccineID && registerNumber == commonBeneficiar.RegistrationNumber)
                                    {
                                        doseNumber = vaccinated.DoseNumber;
                                        vaccined = vaccinated;
                                    }
                                }
                                //Ensuring 30 days passed
                                bool passed = false;
                                if (vaccined.VaccinatedDate.AddDays(30) < DateTime.Now)
                                {
                                    passed = true;
                                }

                                //check eligible for vaccination
                                if (doseNumber == 0)
                                {
                                    bool checkEligible = false;
                                    if (commonBeneficiar.Age > 14)
                                    {
                                        checkEligible = true;
                                        VaccinationClass inject = new VaccinationClass(registerNumber, vaccineID, 1, DateTime.Now);
                                        vaccinationList.Add(inject);
                                        selectedVaccine.injected();
                                        Console.WriteLine("Congrats!, You have taken your first dose");
                                    }
                                    else if (!checkEligible)
                                    {
                                        Console.WriteLine("You are Under age");
                                    }
                                }
                                //checking doseNumber
                                else if (doseNumber == 1 && passed)
                                {
                                    VaccinationClass inject = new VaccinationClass(registerNumber, vaccineID, 2, DateTime.Now);
                                    vaccinationList.Add(inject);
                                    selectedVaccine.injected();
                                    Console.WriteLine($"You have been Injected your {vaccined.DoseNumber + 1}");
                                }
                                else if (doseNumber == 2 && passed)
                                {
                                    VaccinationClass inject = new VaccinationClass(registerNumber, vaccineID, 3, DateTime.Now);
                                    vaccinationList.Add(inject);
                                    selectedVaccine.injected();
                                    Console.WriteLine($"You have been injected your {vaccined.DoseNumber + 1} dose vaccine");
                                }


                                else if (doseNumber >= 3)
                                {
                                    Console.WriteLine("All the three vaccinated course are completed\n You cannot vaccinated now.");
                                }

                            }
                        }
                        else if (action == 3)
                        {
                            foreach (VaccinationClass cav in vaccinationList)
                            {
                                if (commonBeneficiar.RegistrationNumber == cav.RegistrationNumber)
                                {
                                    Console.WriteLine($"{cav.VaccinationID} {cav.RegistrationNumber} {cav.VaccineID} {cav.DoseNumber} {cav.VaccinatedDate}");
                                }
                            }
                        }
                        else if (action == 4)
                        {
                            bool isTrue = false;
                            VaccinationClass vaccined = new VaccinationClass();
                            foreach (VaccinationClass vac in vaccinationList)
                            {
                                if (vac.RegistrationNumber == commonBeneficiar.RegistrationNumber)
                                {
                                    isTrue = true;
                                    vaccined = vac;
                                }
                            }
                            if (isTrue)
                            {
                                if (vaccined.VaccinatedDate.AddDays(30) < DateTime.Now)
                                {
                                    Console.WriteLine("You can take vaccine now");
                                }
                                else
                                {
                                    Console.WriteLine($"You can't take vaccine now\nYour next due date is: {vaccined.VaccinatedDate.AddDays(30).ToShortDateString()}");
                                }
                            }
                            else if (!isTrue)
                            {
                                Console.WriteLine("You can take Vaccine now");
                            }
                        }
                    }


                } while (action != 5);
            }
            else if(choice==3)
            {
                foreach(VaccineClass vaccine in vaccineList)
                {
                    Console.WriteLine($"Vaccine ID: {vaccine.VaccineID} Vaccine Name{vaccine.VaccineName} Available No Of Doses: {vaccine.NoOfDose}");
                }
            }
        } while (choice != 4);
    }
}