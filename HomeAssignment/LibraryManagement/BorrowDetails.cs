using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public enum Status{Default,Borrowed,Returned}
    public class BorrowDetails
    {
        private static int s_borrowID=300;
        public string BorrowID { get;}
        public string BookID { get; set; }
        public string RegistrationID { get; set; }
        public DateTime BorrowedDate {get; set;}
        public Status Status {get; set;}
        public int Fine {get; set;}

        public BorrowDetails()
        {
            BookID="Book ID here";
            Status =Status.Default;
            RegistrationID="Enter your Registration ID";
        }

        public BorrowDetails(string bookID, string registrationID,DateTime borrowedDate,Status status)
        {
            s_borrowID++;
            BorrowID="LB"+s_borrowID;
            BookID=bookID;
            RegistrationID=registrationID;
            BorrowedDate=borrowedDate;
            Status=status;
        }

        public void Borrow()
        {                
            Status=Status.Borrowed;
        }
        public void Return()
        {
            Status=Status.Returned;
        }
       public int FineAmount()
       {
        TimeSpan days=DateTime.Now-BorrowedDate;
         Fine=days.Days;
        return days.Days;
       }

    }

}