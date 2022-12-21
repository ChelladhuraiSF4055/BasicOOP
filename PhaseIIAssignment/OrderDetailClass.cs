using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhaseIIAssignment
{
    public enum Status { Select, Purchased, Cancelled };

    /// <summary>
    /// OrderDetailClass provides class for OrderDetials object
    /// </summary>
    public class OrderDetailClass
    {
        public static int s_orderID = 2000;
        public string OrderID { get; set; }
        public string UserID { get; set; }
        public string MedicineID { get; set; }
        public int MedicineCount { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public Status OrderStatus { get; set; }

        //To avoid Null type exception
        public OrderDetailClass()
        {
            OrderStatus = Status.Purchased;
        }
        /// <summary>
        /// parametric Constructor for creating instances
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="medicineID"></param>
        /// <param name="medicineCount"></param>
        /// <param name="totalPrice"></param>
        /// <param name="orderDate"></param>
        /// <param name="status"></param>
        //creating order instances
        public OrderDetailClass(string userID, string medicineID, int medicineCount, int totalPrice, DateTime orderDate, Status status)
        {
            s_orderID++;
            OrderID = "OID" + s_orderID;
            UserID = userID;
            MedicineID = medicineID;
            MedicineCount = medicineCount;
            TotalPrice = totalPrice;
            OrderDate = orderDate;
            OrderStatus = status;
        }
    }
}