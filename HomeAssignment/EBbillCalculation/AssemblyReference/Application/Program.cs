using System;
using System.Collections.Generic;
using Component;
namespace Application{
    class Program{
        public static void Main(string[] args)
        {
          int choice;
          List<EbBill> EbBillList=new List<EbBill>();
          do
          {
          int unit;     
          Console.WriteLine("Press\n1.Registration\n2.Login\n3.Exit");
          choice=Convert.ToInt32(Console.ReadLine());
          if(choice==1)
          {
               Console.Write("User name ");
               string name=Console.ReadLine();
               Console.WriteLine("Phone No: ");
               long phone=long.Parse(Console.ReadLine());
               Console.Write("Enter Your mail ID:");
               string mailId=Console.ReadLine();
               Console.Write("Unit Consumed:");
               unit=Convert.ToInt32(Console.ReadLine());
          
               EbBill ebBill= new EbBill(name,phone,mailId,unit);
               Console.WriteLine($"Your Meter ID is: {ebBill.MeterID}");
               EbBillList.Add(ebBill);
          }
          else if(choice==2)
          {
               foreach(EbBill customerBill in EbBillList)
               {
                    Console.WriteLine("Enter your Meter ID: ");
                    string meterId=Console.ReadLine();
                    if(meterId==customerBill.MeterID)
                    {
                         Console.WriteLine("Press\n1.Calculate Amount\n2.Display User\n3.Exit");
                         int action=Convert.ToInt32(Console.ReadLine());
                         if(action==1)
                         {    
                              Console.WriteLine(customerBill.BillCalc());
                         }
                         else if(action==2)
                         {
                              Console.WriteLine($"Meter ID: {customerBill.MeterID}\tName: {customerBill.Name}");
                              Console.WriteLine($"Phone: {customerBill.Phone}\tMailID:{customerBill.MailID}");
                              Console.WriteLine($"Unit used: {customerBill.Unit}");
                         }
                    }
               }
          }
     }while(choice!=3);
        }
}
}
          
        
    
