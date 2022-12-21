using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public class ProductDetails
    {
        public static int  s_productID=100;
        public string ProductID {get;}
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
        public int ShippingDuration { get; set; }

        public ProductDetails()
        {
            ProductName="Enter Product Name";
        }

        public ProductDetails(string productName, int stock,int price, int shippingDuration)
        {
            s_productID++;
            ProductID="PID"+s_productID;
            ProductName=productName;
            Price=price;
            Stock=stock;
            ShippingDuration=shippingDuration;
        }
        public int  TotalAmount(int reqCount)
        {
            int delivery=50;
            return delivery+(Price*reqCount);
        }

        public void Purchase()
        {
            Stock--;
        }

        public void Return()
        {
            Stock++;
        }

    }
}