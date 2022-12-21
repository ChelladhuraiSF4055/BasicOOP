using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineDrive
{

    public static class Operations
    {
        static BeneficiaryClass currentBeneficiar = new BeneficiaryClass();
        public static List<BeneficiaryClass> beneficiarList = new List<BeneficiaryClass>();
        public static List<VaccinationClass> vaccinationList = new List<VaccinationClass>();
        public static List<VaccineClass> vaccineList = new List<VaccineClass>();
        public static void MainMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("********Main Menu********");
                Console.WriteLine("\t1.Beneficiary Registration\n\t2.Login\n\t3.Get Vaccine Info\n\t4.Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("*****Beneficiary Registration*****");
                            Registation();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("*****Login*****");
                            Login();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("*****Get Vaccine Info*****");
                            GetVaccineInfo();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("*****Exit*****");
                            break;
                        }
                }
            } while (choice != 4);
        }

        static void Login()
        {
            Console.Write("Enter Your RegisterNumber: ");
            string registerNumber = Console.ReadLine().ToUpper();
            bool isValid = false;
            foreach (BeneficiaryClass beneficiar in beneficiarList)
            {
                if (registerNumber == beneficiar.RegistrationNumber)
                {
                    isValid = true;
                    currentBeneficiar = beneficiar;
                    SubMenu();
                }
            }
            if (!isValid)
            {
                Console.WriteLine("Invalid Register Number");
            }
        }

        static void SubMenu()
        {
            int action;
            do
            {
                Console.WriteLine("\t1.Show my Detials\n\t2.Take Vaccination\n\t3.My Vaccination History\n\t4.Next Due Date\n\t5.Exit");
                action = Convert.ToInt32(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        {
                            Console.WriteLine("*****Show My Details");
                            ShowMyDetials();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("*****Take Vaccination******");
                            TakeVaccine();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("******MyVaccination History******");
                            MyVaccinationHistory();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("*****Next Due Date*****");
                            NextDueDate();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("*****Exit*****");
                            break;
                        }
                }
            } while (action != 5);
        }

        public static void DefaultDetails()
        {
            BeneficiaryClass beneficiary1 = new("Ravichandran", Gender.male, 8484484, "Chennai", 21);
            beneficiarList.Add(beneficiary1);
            BeneficiaryClass beneficiary2 = new("Baskaran", Gender.male, 8484747, "Chennai", 22);
            beneficiarList.Add(beneficiary2);

            VaccineClass vaccine1 = new VaccineClass(VaccineName.Covishield, 50);
            vaccineList.Add(vaccine1);
            VaccineClass vaccine2 = new VaccineClass(VaccineName.Covaccine, 50);
            vaccineList.Add(vaccine2);

            VaccinationClass sit1 = new VaccinationClass("BID1001", "CID101", 1, new DateTime(2021, 11, 11));
            vaccinationList.Add(sit1);
            VaccinationClass sit2 = new VaccinationClass("BID1001", "CID101", 2, new DateTime(2022, 3, 11));
            vaccinationList.Add(sit2);
            VaccinationClass sit3 = new VaccinationClass("BID1002", "CID102", 1, new DateTime(2022, 4, 4));
            vaccinationList.Add(sit3);

        }

        public static void ShowMyDetials()
        {
            Console.WriteLine($"Beneficiar ID: {currentBeneficiar.RegistrationNumber} Beneficiar Name: {currentBeneficiar.Name} Age: {currentBeneficiar.Age} Gender: {currentBeneficiar.Gender}");
            Console.WriteLine($"Mobile: {currentBeneficiar.MobileNumber} City: {currentBeneficiar.City}");
        }

        public static void MyVaccinationHistory()
        {
            bool isExist = false;
            foreach (VaccinationClass vaccination in vaccinationList)
            {
                if (currentBeneficiar.RegistrationNumber == vaccination.RegistrationNumber)
                {
                    isExist = true;
                    Console.WriteLine($"Vaccination ID: {vaccination.VaccinationID} Vaccine ID:{vaccination.VaccineID} RegisterNumber: {vaccination.RegistrationNumber} DoseNumber: {vaccination.DoseNumber} vavinatedDate: {vaccination.VaccinatedDate}");
                }
            }
            if (!isExist)
            {
                Console.WriteLine("Haven't taken vaccine yet");
            }
        }

        public static void NextDueDate()
        {
            int dose = 0;
            VaccinationClass sitted = new VaccinationClass();
            foreach (VaccinationClass sitting in vaccinationList)
            {
                if (sitting.RegistrationNumber == currentBeneficiar.RegistrationNumber)
                {
                    sitted = sitting;
                }
            }
            dose = sitted.DoseNumber;
            if (dose == 0)
            {
                Console.WriteLine("You can take vaccine now");
            }
            else if (dose == 1 || dose == 2)
            {
                Console.WriteLine($"Your Next due date to vaccine: {sitted.VaccinatedDate.AddDays(30)}");
            }
            else if (dose == 3)
            {
                Console.WriteLine("You have completed all three vaccine courses");
            }
        }

        public static void TakeVaccine()
        {
            foreach(VaccineClass vaccine in vaccineList)
        {
            Console.WriteLine($"VaccineID|{vaccine.VaccineID} VaccineName|{vaccine.VaccineName}\tNoOfDoseAvailable|{vaccine.NoOfDose}");
        }
            Console.WriteLine("Enter Vaccine ID: ");
            string vaccineID = Console.ReadLine().ToUpper();
            bool isAvail = false;
            foreach (VaccineClass vaccine in vaccineList)
            {
                //validating id
                if (vaccine.VaccineID == vaccineID)
                {
                    isAvail = true;
                }
            }
            //get vaccination history of current user
            if (isAvail)
            {
                bool isExist = false;
                VaccineClass selectedVaccine = new VaccineClass();
                bool switchVaccine=false;
                bool notfound=false;
                foreach (VaccinationClass vaccined in vaccinationList)
                {
                    if (vaccined.RegistrationNumber == currentBeneficiar.RegistrationNumber)
                    {notfound=true;
                        if (vaccineID == vaccined.VaccineID)
                        {
                            isExist = true;
                            selectedVaccine.VaccineID = vaccineID;
                        }
                        else
                        {
                            switchVaccine=true;
                        }
                    }

                }
                if(switchVaccine)
                {
                    Console.WriteLine("You can't switch vaccine");
                }
                //if didnt took any vaccine-check age- inject-deduct-dount
                if (!notfound)
                {
                    if (currentBeneficiar.Age > 14)
                    {
                        VaccinationClass vac = new VaccinationClass(currentBeneficiar.RegistrationNumber, vaccineID, 1, DateTime.Now);
                        vaccinationList.Add(vac);
                        selectedVaccine.injected();
                        vac.DoseNumber++;
                        Console.WriteLine("Vaccinated");
                    }
                }
                else if (isExist)
                {
                    bool isYes = false;
                    int doseNumber = 0;
                    foreach (VaccinationClass vaccined in vaccinationList)
                    {
                        if (currentBeneficiar.RegistrationNumber == vaccined.RegistrationNumber)
                        {
                            doseNumber = vaccined.DoseNumber;
                            //if yes inject and find and deduct count in vaccine incr doseNumber
                            if (vaccined.DoseNumber < 3 && vaccined.VaccinatedDate.AddDays(30) < DateTime.Now)
                            { //if injected within 30 days not inject

                                isYes = true;
                            }
                            //if more than 3 count not inject
                            else if (vaccined.DoseNumber > 3)
                            {
                                Console.WriteLine("All three vaccination completed");
                            }

                        }
                    }
                    if (isYes && doseNumber < 3 && !switchVaccine && isExist)
                    {
                        VaccinationClass vac = new VaccinationClass(currentBeneficiar.RegistrationNumber, vaccineID, doseNumber, DateTime.Now);
                        vaccinationList.Add(vac);
                        selectedVaccine.injected();
                        vac.DoseNumber++;
                        Console.WriteLine("Vaccinated");
                    }
                    else
                    {
                        Console.WriteLine("All three vaccination completed");
                    }

                }
                
            }

        }
    public static void GetVaccineInfo()
    {
        foreach (VaccineClass vaccine in vaccineList)
        {
            Console.WriteLine($"Vaccine ID: {vaccine.VaccineID} Vaccine Name: {vaccine.VaccineName} No of dose available: {vaccine.NoOfDose}");
        }
    }

    public static void Registation()
    {
        Console.WriteLine("Enter name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter age: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Gender:(male/female) ");
        Gender gender = Enum.Parse<Gender>(Console.ReadLine().ToLower());
        Console.WriteLine("Enter phone: ");
        long phone = Convert.ToInt64(Console.ReadLine());
        Console.WriteLine("Enter city: ");
        string city = Console.ReadLine();

        BeneficiaryClass beneficiar = new BeneficiaryClass(name, gender, phone, city, age);
        beneficiarList.Add(beneficiar);
        //currentBeneficiar=beneficiar;
        Console.WriteLine($"Registration successful Your ID:{beneficiar.RegistrationNumber}");
    }
}
}