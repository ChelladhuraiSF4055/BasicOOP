using System;
using System.Collections.Generic;

namespace PhaseIIAssignment
{
    //alternative for content in main program to keep simple

    public static class OperationClass
    {
        /// <summary>
        /// Currently Logged In User 
        /// </summary>
        static UserDetailClass currentUser = new UserDetailClass();
        static List<UserDetailClass> userList = new List<UserDetailClass>();
        static List<OrderDetailClass> orderList = new List<OrderDetailClass>();
        static List<MedicineDetailsClass> medicineList = new List<MedicineDetailsClass>();
        //displaying Main Menu
        public static void MainMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("\t1.UserRegistration\n\t2.UserLogin\n\t3.OrderHistory");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("*****User Registraiton*****");
                            UserRegistration();
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
                            Console.WriteLine("*****Order History*****");
                            OrderHistory();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("******Exit******");
                            break;
                        }
                }
            } while (choice != 4);
        }
        //validating userID
        public static void UserLogin()
        {
            Console.Write("Enter Your User ID: ");
            string userID = Console.ReadLine().ToUpper();
            bool isExist = false;
            foreach (UserDetailClass user in userList)
            {
                if (user.UserID == userID)
                {
                    isExist = true;
                    currentUser = user;
                    SubMenu();
                }
            }
            if (!isExist)
            {
                Console.WriteLine("Invalid User ID");
            }
        }
        //breakdown the login menu
        public static void SubMenu()
        {
            int action;
            do
            {
                Console.WriteLine("\t1.Show Medicine List\n\t2.Purchase Medicine\n\t3.Cancel Purchase\n\t4.Show Purchse History\n\t5.Recharge\n\t6.Exit");
                action = Convert.ToInt32(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        {
                            Console.WriteLine("Show Medicine List");
                            ShowMedicineList();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("****Purchase Medicine****");
                            Purchase();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("****Cancel Purchase****");
                            CancelPurchase();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("****Show Purchase History****");
                            ShowPurchaseHistory();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("****Recharge****");
                            Recharge();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("****Exit****");
                            break;
                        }
                }
            } while (action != 6);
        }
        //Default Data
        public static void DefaultData()
        {
            UserDetailClass user1 = new UserDetailClass("Ravi", 33, "Theni", 9877774440, 400);
            userList.Add(user1);
            UserDetailClass user2 = new UserDetailClass("Baskaran", 33, "Chennai", 8847757470, 500);
            userList.Add(user2);

            MedicineDetailsClass medicine1 = new MedicineDetailsClass("MD101", "Paracitamol", 40, 5, new DateTime(2022, 6, 30));
            medicineList.Add(medicine1);
            MedicineDetailsClass medicine2 = new MedicineDetailsClass("MD102", "Calpol", 10, 5, new DateTime(2023, 5, 30));
            medicineList.Add(medicine2);
            MedicineDetailsClass medicine3 = new MedicineDetailsClass("MD103", "Gelucil", 3, 40, new DateTime(2023, 4, 30));
            medicineList.Add(medicine3);
            MedicineDetailsClass medicine4 = new MedicineDetailsClass("MD104", "Metrogel", 5, 50, new DateTime(2022, 12, 30));
            medicineList.Add(medicine4);
            MedicineDetailsClass medicine5 = new MedicineDetailsClass("MD105", "Povidin Iodin", 10, 50, new DateTime(2022, 10, 30));
            medicineList.Add(medicine5);

            OrderDetailClass order1 = new OrderDetailClass("UID1001", "MD101", 3, 15, new DateTime(2022, 11, 13), Status.Purchased);
            orderList.Add(order1);
            OrderDetailClass order2 = new OrderDetailClass("UID1001", "MD102", 2, 10, new DateTime(2022, 11, 13), Status.Cancelled);
            orderList.Add(order2);
            OrderDetailClass order3 = new OrderDetailClass("UID1001", "MD104", 2, 100, new DateTime(2022, 11, 13), Status.Purchased);
            orderList.Add(order3);
            OrderDetailClass order4 = new OrderDetailClass("UID1002", "MD103", 3, 120, new DateTime(2022, 11, 15), Status.Cancelled);
            orderList.Add(order4);
            OrderDetailClass order5 = new OrderDetailClass("UID1002", "MD105", 5, 250, new DateTime(2022, 11, 15), Status.Purchased);
            orderList.Add(order5);
            OrderDetailClass order6 = new OrderDetailClass("UID1002", "MD102", 3, 15, new DateTime(2022, 11, 15), Status.Purchased);
            orderList.Add(order6);
        }
        //Registers User Details
        public static void UserRegistration()
        {
            Console.Write("Enter Your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Your City: ");
            string city = Console.ReadLine();
            Console.Write("Enter Your Phone Number: ");
            long phone = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Your Initial Balance to deposit: ");
            int balance = Convert.ToInt32(Console.ReadLine());

            UserDetailClass user = new UserDetailClass(name, age, city, phone, balance);
            userList.Add(user);
            Console.WriteLine($"Registration Successful.\n Your User ID:{user.UserID}");
        }
        //Displays Medicine List
        public static void ShowMedicineList()
        {
            foreach (MedicineDetailsClass medicine in medicineList)
            {
                Console.WriteLine($"MedicineID: {medicine.MedicineID} Medicine Name:{medicine.MedicineName} AvailableCount:{medicine.AvailableCount}\nPrice:{medicine.Price} DateOfExpiry:{medicine.DateOfExpiry.ToShortDateString()}\n");
            }

        }
        //Displays Purchase History of user
        public static void ShowPurchaseHistory()
        {
            foreach (OrderDetailClass order in orderList)
            {
                if (currentUser.UserID == order.UserID)
                {
                    Console.WriteLine($"OrderID:{order.OrderID} UserID:{order.UserID} MedicineID:{order.MedicineID} MedicineCount: {order.MedicineCount} ");
                    Console.WriteLine($"TotalPrice: {order.TotalPrice} OrderDate: {order.OrderDate.ToShortDateString()} Order Status:{order.OrderStatus}\n");
                }
            }
        }
        //Recharge method used to recharge
        public static void Recharge()
        {
            Console.WriteLine("Enter the amount to be deposited In INR: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            currentUser.Recharge(amount);
            Console.WriteLine("Recharged Successfully");
        }
        //Purchasing Medicine
        public static void Purchase()
        {
            foreach (MedicineDetailsClass medicine in medicineList)
            {
                Console.WriteLine($"MedicineID: {medicine.MedicineID} MedicineName: {medicine.MedicineName} MedicineCount:  {medicine.AvailableCount}");
                Console.WriteLine($"Price: {medicine.Price} \t DateOfExpiry:{medicine.DateOfExpiry.ToShortDateString()}\n");
            }
            Console.Write("Enter Medicine ID: ");
            string medicineID = Console.ReadLine().ToUpper();
            Console.Write("Enter the Count: ");
            int count = Convert.ToInt32(Console.ReadLine());
            bool isValid = false;
            //iterating through medicine List
            foreach (MedicineDetailsClass medicine in medicineList)
            {
                //validating entered medicine ID
                if (medicine.MedicineID == medicineID)
                {
                    isValid = true;
                    //checking medicine available count
                    if (count <= medicine.AvailableCount)
                    {
                        //checking current user balance
                        if (currentUser.Balance >= (medicine.Price * count))
                        {
                            //checking medicine's date of expiry
                            if (medicine.DateOfExpiry > DateTime.Now)
                            {
                                int amount = medicine.Price * count;
                                Console.Write($"Pay ({amount}) in INR: ");
                                int given = Convert.ToInt32(Console.ReadLine());
                                if (given == amount)
                                {
                                    //providing medicine & deducting amount user
                                    medicine.DeductCount(count);
                                    currentUser.Purchase(amount);
                                    OrderDetailClass order = new OrderDetailClass(currentUser.UserID, medicine.MedicineID, count, amount, DateTime.Now, Status.Purchased);
                                    orderList.Add(order);
                                    Console.WriteLine($"Successfully Purchased {count} - {medicine.MedicineName}");
                                    Console.WriteLine($"An Amount of {amount} has been deducted from your wallet");
                                }
                                else
                                {
                                    Console.WriteLine("Transaction failed due to inappropriate attempt");
                                }

                            }
                            else
                            {
                                Console.WriteLine("Medicine Expired");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Balance Insufficient");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Specified Count not available");
                    }
                }
            }
            if (!isValid)
            {
                Console.WriteLine("Invalid Medicine ID");
            }
        }

        public static void CancelPurchase()
        {
            foreach (OrderDetailClass order in orderList)
            {
                if (currentUser.UserID == order.UserID && order.OrderStatus == Status.Purchased)
                {
                    Console.WriteLine($"OrderID:{order.OrderID} UserID:{order.UserID} MedicineID:{order.MedicineID} MedicineCount: {order.MedicineCount} ");
                    Console.WriteLine($"TotalPrice: {order.TotalPrice} OrderDate: {order.OrderDate.ToShortDateString()} Order Status:{order.OrderStatus}\n");
                }
            }
            string orderID = "";
            Console.Write("Enter Order ID: ");
            orderID = Console.ReadLine().ToUpper();
            bool check = false;
            foreach (OrderDetailClass order in orderList)
            {
                if (orderID == order.OrderID && order.OrderStatus == Status.Purchased)
                {
                    order.OrderStatus = Status.Cancelled;
                    currentUser.Recharge(order.TotalPrice);
                    Console.WriteLine("Ordered Cancelled successfully");
                    Console.WriteLine($"Your wallet has been refunded with the {order.TotalPrice}");
                }
            }
        }

        public static void OrderHistory()
        {
            foreach (OrderDetailClass order in orderList)
            {
                Console.WriteLine($"OrderID:{order.OrderID} UserID:{order.UserID} MedicineID:{order.MedicineID}");
                Console.WriteLine($"MedicineCount: {order.MedicineCount} TotalPrice: {order.TotalPrice} OrderDate: {order.OrderDate}");
                Console.WriteLine();
            }
        }
    }
}