using System;
using System.Collections.Generic;
namespace Component
{
    public class EbBill

    {
        private static int s_meterId=1000;
        public string MeterID  { get; }

        public string Name { get; set; }

        public long Phone { get; set; }

        public string MailID {get; set;}

        public int Unit {get; set;}

        public EbBill()
        {
            Name="Enter Your Name";
            MailID="Enter Your MailId";
        }

        public EbBill(string name, long phone,string mailid,int unit)
        {
            s_meterId++;
            MeterID="EB"+s_meterId;
            Name=name;
            Phone=phone;
            MailID=mailid;
            Unit=unit;
        }

        public double  BillCalc()
        {
            double perUnit=0;
                         for(int i=1;i<=Unit;i++)
                         {
                              if(i<=100)
                              {
                                   perUnit+=0;
                              }
                              else if(i>100 && i<=199)
                              {
                                   perUnit+=1.5f;
                              }
                              else if(i>=200 && i<400)
                              {
                                   perUnit+=3f;
                              }
                              else if(i>=400 && i <600)
                              {
                                   perUnit+=5f;
                              } 
                         }   
                         return perUnit;   
        }
    }  
}