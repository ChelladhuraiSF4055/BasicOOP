using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public enum OrderStatus{Default, Ordered, Cancelled}
    public class OrderDetails
    {
        private static int s_orderID=1000;
        public string OrderID {get;}
        public string CustomerID { get;  }
        public string ProductID { get; set; }
        public int TotalPrice {get; set;}
        public DateTime PurchaseDate { get; set; }
        public int Quantity  { get; set; }
        public OrderStatus OrderStatus  { get; set; }

        public OrderDetails()
        {
            OrderID="Enter Order ID";
            ProductID="Enter Product ID";
        }

        public OrderDetails(string customerID,string productID,int totalPrice,DateTime purchaseDate,int quantity,OrderStatus status)
        {
            s_orderID++;
            OrderID="OID"+s_orderID;
            CustomerID=customerID;
            ProductID=productID;
            TotalPrice=totalPrice;
            PurchaseDate=purchaseDate;
            Quantity=quantity;
            OrderStatus=status;
        }

        public void Purchase()
        {
            OrderStatus=OrderStatus.Ordered;
        }

        public void Return()
        {
            OrderStatus=OrderStatus.Cancelled;
        }

        
    }
}