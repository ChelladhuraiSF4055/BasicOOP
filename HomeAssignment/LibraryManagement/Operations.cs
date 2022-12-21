using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public static class Operations
    {
        static UserDetails currentUser = new UserDetails();
        public static List<BorrowDetails> borrowList = new List<BorrowDetails>();
        public static List<UserDetails> userList = new List<UserDetails>();
        public static List<BookDetails> bookList = new List<BookDetails>();

        public static void MainMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("********Main Menu********");
                Console.WriteLine("\t1.Registration Form\n\t2.UserLogin\n\t3.Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("******Registration Form******");
                            RegistrationForm();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("******User Login******");
                            Login();
                            currentUser = new UserDetails();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("******Exit******");
                            break;
                        }
                }
            } while (choice != 3);
        }

        public static void Login()
        {
            Console.Write("Enter Your User ID: ");
            string userID = Console.ReadLine().ToUpper();
            //validating user ID
            bool isAvail = false;
            foreach (UserDetails user in userList)
            {
                if (userID == user.UserID)
                {
                    isAvail = true;
                    currentUser = user;
                    SubMenu();
                }
            }
            if (!isAvail)
            {
                Console.WriteLine("Invalid User");
            }
        }

        static void SubMenu()
        {
            int action;
            do
            {
                Console.WriteLine("\t\n1.Borrow Book\t\n2.Show Borrowed History\t\n3.Return Books\t\n4.Exit");
                action = Convert.ToInt32(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        {
                            Console.WriteLine("******Borrow Book******");
                            BorrowBooks();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("******Show Borrowed History******");
                            ShowBorrowedHistory();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("******Return Books******");
                            ReturnBooks();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("******Exit******");
                            break;
                        }
                }
            } while (action != 4);
        }

        static void ShowBorrowedHistory()
        {bool isExist=false;
            foreach (BorrowDetails borrow in borrowList)
            {
                if (currentUser.UserID == borrow.RegistrationID)
                {
                    isExist=true;
                    Console.WriteLine($"Borrow ID: {borrow.BorrowID} Borrowed Date: {borrow.BorrowedDate} Registration ID: {borrow.RegistrationID} Book ID: {borrow.BookID} Status:{borrow.Status}");
                }
            }
            if(!isExist)
            {
                Console.WriteLine("You haven't borrowed anything yet");
            }
        }

        static void ReturnBooks()
        {
            TimeSpan elapsedDate;
            bool isAvail=false;
            foreach(BorrowDetails borrow in borrowList)
            {
                elapsedDate = DateTime.Now - borrow.BorrowedDate.AddDays(15);
                if(currentUser.UserID==borrow.RegistrationID)
                {
                    isAvail=true;
                    if(DateTime.Now>borrow.BorrowedDate.AddDays(15))
                    {
                        borrow.FineAmount();
                        Console.WriteLine($"Borrowed  ID: {borrow.BorrowID} BookDateL {borrow.BookID} Reg NO:{borrow.RegistrationID} BorrowedDate: {borrow.BorrowedDate.ToShortDateString()} status: {borrow.Status} Amount: {borrow.Fine}");
                    }
                    else
                    {
                        Console.WriteLine($"Borrowed  ID: {borrow.BorrowID} BookDateL {borrow.BookID} Reg NO:{borrow.RegistrationID} BorrowedDate: {borrow.BorrowedDate.ToShortDateString()} status: {borrow.Status} Amount: {borrow.Fine}");
                    }
                }
            }
            if(isAvail)
            {
            Console.WriteLine("Select BorrowedID to return:");
            string borrowID = Console.ReadLine().ToUpper();
            bool given = false;
            foreach (BorrowDetails borrow in borrowList)
            {
                if (borrowID == borrow.BorrowID && borrow.Status == Status.Borrowed)
                {
                    given = true;
                    Console.WriteLine($"Amount to be paid:{borrow.FineAmount()}");
                    if(borrow.FineAmount()!=0)
                    {
                    Console.Write($"Pay in INR:");
                    }
                    int rupee = Convert.ToInt32(Console.ReadLine());
                    if (rupee == borrow.Fine)
                    {
                        Console.WriteLine("Book Returned");
                        borrow.Status = Status.Returned;
                        foreach (BookDetails book in bookList)
                        {
                            if (borrow.BookID == book.BookID)
                            {
                                book.IncreaseBookCount();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("return failed due to inaccurate Fine submission");
                    }
                }
            }
            if (given == false)
            {
                Console.WriteLine("You've returned it");
            }
            }
        }

        static void BorrowBooks()
        {

            foreach(BookDetails book in bookList)
            {
                Console.WriteLine($"Book ID: {book.BookID} BookName: {book.BookName} Author: {book.Author} BookCOunt:{book.BookCount}");
            }
            Console.WriteLine("Enter BookID to borrow:");
            string bookID=Console.ReadLine().ToUpper();
            //check book count available
            bool isAvail=false;
            BookDetails selectBook=new BookDetails();
            DateTime availDate=new DateTime();

            foreach(BookDetails book in bookList)
            {
                if(book.BookID==bookID)
                {
                    selectBook=book;
                    if(book.BookCount>0)
                    {
                        isAvail=true;
                    }
                    //if not display check next available date
                    else if(book.BookCount==0)
                    {
                        foreach(BorrowDetails borrow in borrowList)
                        {
                            if(borrow.BookID==book.BookID)
                            {
                                availDate=borrow.BorrowedDate.AddDays(15).Date;
                            }
                        }
                        Console.WriteLine($"Books aren't available, will be available on {availDate}");
                    }
                }
            }
            //check user borrowed 3 books already
            if(isAvail)
            {
                int count=0;
                foreach(BorrowDetails borrow in borrowList)
                {
                    if(currentUser.UserID==borrow.RegistrationID && borrow.Status==Status.Borrowed)
                    {
                        count++;
                    }
                }
                if(count<3)
                {
                    BorrowDetails borrow=new BorrowDetails(selectBook.BookID,currentUser.UserID,DateTime.Now,Status.Borrowed);
                    borrowList.Add(borrow);
                    selectBook.BookCount--;
                    Console.WriteLine("Borrowes successful");
                }
                else
                {
                    Console.WriteLine("You cant borrow more than 3 books in a time");

                }
            }

            
        }

        public static void DefaultData()
        {
            UserDetails user1 = new UserDetails("Ravichandran", Gender.male, Department.EEE, 9938388333, "ravi@gmail.com");
            userList.Add(user1);
            UserDetails user2 = new UserDetails("Priyadharshini", Gender.female, Department.CSE, 9944444455, "priya@gmail.com");
            userList.Add(user2);


            BookDetails book1 = new BookDetails("C#", "Author1", 3);
            bookList.Add(book1);
            BookDetails book2 = new BookDetails("HTML", "Author2", 5);
            bookList.Add(book2);
            BookDetails book3 = new BookDetails("CSS", "Author1", 3);
            bookList.Add(book3);
            BookDetails book4 = new BookDetails("JS", "Author1", 3);
            bookList.Add(book4);
            BookDetails book5 = new BookDetails("TS", "Author2", 2);
            bookList.Add(book5);

            BorrowDetails borDet1 = new BorrowDetails("BID101", "SF3001", new DateTime(2022, 4, 10), Status.Borrowed);
            borrowList.Add(borDet1);
            BorrowDetails borDet2 = new BorrowDetails("BID103", "SF3001", new DateTime(2022, 12, 1), Status.Borrowed);
            borrowList.Add(borDet2);
            BorrowDetails borDet3 = new BorrowDetails("BID104", "SF3002", new DateTime(2022, 4, 15), Status.Returned);
            borrowList.Add(borDet3);
            BorrowDetails borDet4 = new BorrowDetails("BID102", "SF3002", new DateTime(2022, 4, 11), Status.Borrowed);
            borrowList.Add(borDet4);
            BorrowDetails borDet5 = new BorrowDetails("BID105", "SF3002", new DateTime(2022, 11, 10), Status.Returned);
            borrowList.Add(borDet5);

        }

        public static void RegistrationForm()
        {
            Console.Write("Enter Your Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Your Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine().ToLower());
            Console.Write("Enter Your Department: ");
            Department department = Enum.Parse<Department>(Console.ReadLine().ToUpper());
            Console.Write("Enter Your Phone Number:");
            long phone = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Mail ID: ");
            string mailID = Console.ReadLine();

            currentUser = new UserDetails(name, gender, department, phone, mailID);
            userList.Add(currentUser);
            Console.WriteLine($"Registration successful :{currentUser.UserID}");
        }
    }
}

