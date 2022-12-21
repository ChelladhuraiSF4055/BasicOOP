using System;
using System.Collections.Generic;
namespace Application;
using Component;

public class Program{
    public static void Main(string[] args)
    {
        int choice;
        List<CustomerDetails>customerList=new List<CustomerDetails>();
        do
        {
            Console.WriteLine("Press:\n1.Registration\n2.Login\n3.Exit");
            choice=Convert.ToInt32(Console.ReadLine());
            if(choice==1)
            {
                Console.WriteLine("Enter your name: ");
                string name =Console.ReadLine();
                Console.WriteLine("Enter your Gender Male/Female/Transgender:");
                Gender gender=Enum.Parse<Gender>(Console.ReadLine());
                Console.WriteLine("Enter your Phone no:");
                long phone=long.Parse(Console.ReadLine());
                Console.WriteLine("Enter you mail ID:");
                string mailID=Console.ReadLine();
                Console.WriteLine("Enter Your DOB in dd/MM/yyyy format:");
                DateTime dob=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
                CustomerDetails customer=new CustomerDetails(name,gender,phone,mailID,dob);
                customerList.Add(customer);
                Console.WriteLine($"Your customer ID is: {customer.CustomerID}");
            }
            else if(choice==2)
            {
                Console.Write("Enter your customer ID:");
                int customerID=Convert.ToInt32(Console.ReadLine());
                int flag=0;
                int action;
                double amount;
                foreach(CustomerDetails customerInfo in customerList)
                {
                    if(customerInfo.CustomerID==customerID)
                    {
                        flag=1;
                        Console.WriteLine("Press: \n1.Deposit\t2.Withdraw\n3.balance check\t4.Back");
                        action=Convert.ToInt32(Console.ReadLine());
                        if(action==1)
                        {
                            Console.Write("Enter the amount to deposit: ");
                            amount=double.Parse(Console.ReadLine());
                            Console.WriteLine($"Your remaining balance is: {customerInfo.Deposit(amount)}");
                        }
                        else if(action==2)
                        {
                            Console.Write("Enter the amount to withdrawn: ");
                            amount=double.Parse(Console.ReadLine());
                            if(customerInfo.Withdraw(amount))
                            {
                                Console.WriteLine($"You've withdrawn {amount}\nYour remaining balance is: {customerInfo.Balance}");
                            }
                            else
                            {
                                Console.WriteLine($"Insufficient Balance.\nYou have{customerInfo.Balance}");

                            }
                        }
                        else if(action==3)
                        {
                            Console.WriteLine($"Your available balance is: {customerInfo.Balance}");
                        }
                    }
                }
                if(flag==0)
                    {
                        Console.WriteLine("Invalid user ID");
                    }
            }
        }while(choice!=3);
    }
}