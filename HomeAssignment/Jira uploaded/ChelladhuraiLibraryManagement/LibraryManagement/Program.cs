using System;
using System.Collections.Generic;
namespace LibraryManagement;
class Program{
public static void Main(string[] args)
{
    List<UserDetails>userList=new List<UserDetails>();
    List<BookDetails>bookList=new List<BookDetails>();
    List<BorrowDetails>borrowList=new List<BorrowDetails>();

    UserDetails user1=new UserDetails("Ravichandran",Enum.Parse<Gender>("Male"),Enum.Parse<Department>("EEE"),9938388333,"ravi@gmail.com");
    userList.Add(user1);
    UserDetails user2=new UserDetails("Priyadharshini",	Enum.Parse<Gender>("Female"),	Enum.Parse<Department>("CSE")	,9944444455,"priya@gmail.com");
    userList.Add(user2);


    BookDetails book1=new BookDetails("C#","Author1",  3);
    bookList.Add(book1);
    BookDetails book2=new BookDetails("HTML","Author2",5);
    bookList.Add(book2);
    BookDetails book3=new BookDetails("CSS","Author1",	3);
    bookList.Add(book3);
    BookDetails book4=new BookDetails("JS","Author1",	3);
    bookList.Add(book4);
    BookDetails book5=new BookDetails("TS","Author2",	2);
    bookList.Add(book5);

    BorrowDetails borDet1=new BorrowDetails("BID101","SF3001",new DateTime(2022,4,10),Status.Borrowed);
    borrowList.Add(borDet1);
    BorrowDetails borDet2=new BorrowDetails("BID103","SF3001",new DateTime(2022,12,1),Status.Borrowed);
    borrowList.Add(borDet2);
    BorrowDetails borDet3=new BorrowDetails("BID104","SF3002",new DateTime(2022,4,15),Status.Returned);
    borrowList.Add(borDet3);
    BorrowDetails borDet4=new BorrowDetails("BID102","SF3002",new DateTime(2022,4,11),Status.Borrowed);
    borrowList.Add(borDet4);
    BorrowDetails borDet5=new BorrowDetails("BID105","SF3002",new DateTime(2022,11,10),Status.Returned);
    borrowList.Add(borDet5);

    int choice;
    do
    {  
        UserDetails CommonUser=new UserDetails();
        Console.WriteLine("Press:\n1.UserRegistration\n2.UserLogin\n3.Exit ");
        choice=Convert.ToInt32(Console.ReadLine());
        //UserLogin
        if(choice==1)
        {
            Console.Write("Enter UserName:");
            string name=Console.ReadLine();
            Console.Write("Enter Your Gender:");
            Gender gender=Enum.Parse<Gender>(Console.ReadLine());
            Console.Write("Enter Your Department:");
            Department department=Enum.Parse<Department>(Console.ReadLine());
            Console.Write("Enter Your Mobile Number:");
            long phone=Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Your MailID:");
            string mailID=Console.ReadLine();
            UserDetails user=new UserDetails(name,gender,department,phone,mailID);
            userList.Add(user);
            Console.WriteLine($"Your UserID:{user.UserID}");
        }

        else if(choice==2)
        {
            int action=0;
            Console.WriteLine("Login:");
            //Asking User ID
            Console.Write("Enter UserID: ");
            string userID=Console.ReadLine();
            //Validating its id
            bool check=false;
            foreach(UserDetails user in userList)
            {
                if(userID==user.UserID)
                {
                    check=true;
                    CommonUser=user;
                }      
            }
            if(check==false)
            {
                Console.WriteLine("Invalid UserID");
            }
            else if(check==true)
            {
            do
            {
                Console.WriteLine("1.Borrow Book\n2.Show Borrowed History\n3.Return Books\n4.Exit");
                action=int.Parse(Console.ReadLine());

                //Action-1 Borrow Books
                if(action==1)
                {   string searchBookID;
                    foreach(BookDetails book in bookList)
                    {
                        Console.WriteLine($"BookID: {book.BookID}\t BookName: {book.BookName}\t Author: {book.Author}\t BookCount: {book.BookCount}");
                    } 
                    Console.WriteLine("Enter book ID");
                    searchBookID=Console.ReadLine();
                    BookDetails TakenBook;
                    BorrowDetails BookToBorrow;
                    bool flag=false;
                    foreach(BookDetails book in bookList)
                    {
                        if(searchBookID==book.BookID)
                        {flag=true;
                            TakenBook=book;
                            if(TakenBook.BookCount>0)
                            {
                                int borrowCOunt=0;
                                foreach(BorrowDetails bookie in borrowList)
                                {
                                    if(bookie.RegistrationID==CommonUser.UserID)
                                    {
                                        borrowCOunt++;
                                    }
                                }
                                if(borrowCOunt>2)
                                {
                                    Console.WriteLine("You've alreadly availed 3 books\nYou cant borrow more than 3 books ");
                                }
                                else
                                {
                                    BookToBorrow=new BorrowDetails(searchBookID,CommonUser.UserID,DateTime.Now,Status.Borrowed);
                                    borrowList.Add(BookToBorrow);   
                                    TakenBook.ReduceBookCount();
                                    BookToBorrow.Borrow();
                                    Console.WriteLine("Book borrowed successfully");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Books are not available for selected Count");
                                foreach(BorrowDetails borrow in borrowList)
                                {
                                    if(TakenBook.BookID==borrow.BookID)
                                    {
                                        Console.WriteLine("The Book will be available on: ");
                                        Console.WriteLine(borrow.BorrowedDate.AddDays(15).ToShortDateString());
                                    }
                                }
                            }
                        }
                    }
                    if(flag==false)
                    {
                        Console.WriteLine("Enter Valid BookID");
                    }
                }

                //Action2-show borrowed History
                else if(action==2)
                {
                    //To display borrowed details of individual
                    foreach(BorrowDetails borrow in borrowList)
                    {
                        if(CommonUser.UserID==borrow.RegistrationID)
                        {
                            Console.WriteLine($"BorrowedID:{borrow.BorrowID} BookDate:{borrow.BookID} Registration:{borrow.RegistrationID} BorrowedDate:{borrow.BorrowedDate} Status: {borrow.Status}");
                        }
                    }
                }
            
                //Action-3 To return books
                else if(action==3)
                {
                    TimeSpan elapsedDate;
                    foreach(BorrowDetails borrow in borrowList)
                    {
                        elapsedDate=DateTime.Now-borrow.BorrowedDate.AddDays(15);
                        if(CommonUser.UserID==borrow.RegistrationID)
                        {
                            if(elapsedDate.Days>15)
                            {
                                borrow.Amount(elapsedDate.Days);
                                Console.WriteLine($"BorrowedID:{borrow.BorrowID} BookDate:{borrow.BookID} Registration:{borrow.RegistrationID} BorrowedDate:{borrow.BorrowedDate.ToShortDateString()} Status: {borrow.Status} Amount:{borrow.Fine}");
                            }
                            else
                            {
                                Console.WriteLine($"BorrowedID:{borrow.BorrowID} BookDate:{borrow.BookID} Registration:{borrow.RegistrationID} BorrowedDate:{borrow.BorrowedDate.ToShortDateString()} Status: {borrow.Status} Amount:{borrow.Fine}");
                            }
                            
                        }
                    }
                    Console.WriteLine("Select BorrowedID to return:");
                    string borrowID=Console.ReadLine();
                    bool given=false;
                    foreach(BorrowDetails borrow in borrowList)
                    {
                        if(borrowID==borrow.BorrowID && borrow.Status==Status.Borrowed)
                        {
                            given=true;
                            Console.WriteLine($"Amount to be paid:{borrow.Fine}");
                            Console.Write($"Pay in INR:");
                            int rupee=Convert.ToInt32(Console.ReadLine());
                            if(rupee==borrow.Fine)
                            {
                               Console.WriteLine("Fine recieved"); 
                               borrow.Status=Status.Returned;
                               foreach(BookDetails book in bookList)
                               {
                                if(borrow.BookID==book.BookID)
                                {
                                    book.IncreaseBookCount();
                                }
                               }
                            }
                            else
                            {
                                Console.WriteLine("Transaction failed due to inaccurate Fine submission");
                            }
                        }   
                    }
                    if(given==false)
                    {
                        Console.WriteLine("You've returned it");
                    }
                }   
            }while(action!=4);   
            }
        }         
    }while(choice!=4);
}
}

