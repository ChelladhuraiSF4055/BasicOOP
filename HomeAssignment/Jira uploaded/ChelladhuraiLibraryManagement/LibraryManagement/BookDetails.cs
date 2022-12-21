using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement
{
    public class BookDetails
    {
        private static int s_bookID=100;
        public string BookID { get;}
        public  int BookCount { get; set;}
        public string BookName { get; set; }
        public string Author { get; set;}
        public BookDetails()
        {
            BookID="BookID";
            BookName="Enter BookName";
            Author="Enter Author name";
        }

        public BookDetails(string bookName,string author,int bookCount)
        {
         s_bookID++;   
         BookID="BID"+s_bookID;
         BookName=bookName;
         Author=author; 
         BookCount=bookCount;  
        }    

        public void ReduceBookCount()
        {
            BookCount--;
        }
        public void IncreaseBookCount()
        {
            BookCount++;
        }

        

    }
}