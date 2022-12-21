using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce
{
    public static class Operations
    {
        public static List<CustomerDetails>customerList=new List<CustomerDetails>();
        public static List<OrderDetails>orderDetailsList=new List<OrderDetails>();
        public static List<ProductDetails>productDetailsList=new List<ProductDetails>();
        static CustomerDetails currentCustomer=new CustomerDetails();
        public static void  MainMenu()
        {
            int choice;
            do
            {
                Console.WriteLine("********Main Menu********");
                Console.WriteLine("\t1.Registration\n\t2.Login\n\t3.Exit");
                choice=Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                    {
                        Console.WriteLine("******Registration Form******");
                        Registration();
                        break;
                    }
                    case 2: 
                    {
                        Console.WriteLine("******Login******");
                        Login();
                        break;
                    }
                    case 3: 
                    {
                        Console.WriteLine("******Exit******");
                        break;
                    }
                    
                }
            }while(choice!=3);
        }

        static void Registration()
        {
            Console.Write("Enter Your Name: ");
            string name=Console.ReadLine();
            Console.Write("Enter Your city: ");
            string city=Console.ReadLine();
            Console.Write("Enter Phone Numbr: ");
            long phone=Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Mail ID: ");
            string mailID=Console.ReadLine();
            Console.Write("Enter Wallet initial Balance: ");
            int WallentIntBalance=Convert.ToInt32(Console.ReadLine());

            CustomerDetails customer=new CustomerDetails(name,city,phone,WallentIntBalance,mailID);
            customerList.Add(customer);
            Console.WriteLine($"Registration Successful\nYour Customer ID: {customer.CustomerID}");
        }
    
        static void Login()
        {
            Console.Write("Enter Your Custmer ID: ");
            string customerID=Console.ReadLine();
            bool check=false;
            foreach(CustomerDetails customer in customerList)
            {
                if(customer.CustomerID==customerID)
                {
                    check=true;
                    currentCustomer=customer;
                    Console.WriteLine("Login successful");
                    SubMenu();
                }
            }
            if(!check)
            {
                Console.WriteLine("Invalid User ID");
            }
        }
    
        static void SubMenu()
        {
            int action;
            do
            {
                Console.WriteLine("\t1.Purchase\n\t2.Order History\n\t3.Cancel Order\n\t4.Wallet Balance\n\t5.Exit");
                action=Convert.ToInt32(Console.ReadLine());
                switch(action)
                {
                    case 1:
                    {
                        Console.WriteLine("******Purchase******");
                        Purchase();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("******Order History******");
                        OrderHistory();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("******Cancel Order******");
                        CancelOrder();
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("******Wallet Balance******");
                        WalletBalance();
                        break;
                    }
                    case 5: 
                    {
                        Console.WriteLine("******Exit******");
                        break;
                    }
                }
            }while(action!=5);
        }

        public static void DefaultData()
        {
            CustomerDetails customer1=new CustomerDetails("Ravi","Chennai",98858588,50000,"ravi@gmail.com");
            customerList.Add(customer1);
            CustomerDetails customer2=new CustomerDetails("Baskaran","Chennai",9888475757,60000,"baskaran@gmail.com");
            customerList.Add(customer2);

            ProductDetails product1 = new ProductDetails("Mobile",10,10000,3);
            productDetailsList.Add(product1);
            ProductDetails product2= new ProductDetails("Tablet",5,15000,2);
            productDetailsList.Add(product2);
            ProductDetails product3=new ProductDetails("Camera",5,15000,2);
            productDetailsList.Add(product3);
            ProductDetails product4=new ProductDetails("IPhone",5,50000,6);
            productDetailsList.Add(product4);
            ProductDetails product5=new ProductDetails("Laptop",3,40000,3);
            productDetailsList.Add(product5);

            OrderDetails order1=new OrderDetails(customer1.CustomerID,product1.ProductID,20000,DateTime.Now,2,OrderStatus.Ordered);
            orderDetailsList.Add(order1);
            OrderDetails order2=new OrderDetails(customer2.CustomerID,product3.ProductID,4000,DateTime.Now,2,OrderStatus.Ordered);
            orderDetailsList.Add(order2);
        }
    
        public static void OrderHistory()
        {
            bool isPurchased=false;
            foreach(OrderDetails order in orderDetailsList)
            {
                if(currentCustomer.CustomerID==order.CustomerID)
                {
                    isPurchased=true;
                    Console.WriteLine($"Order ID: {order.OrderID} Product ID: {order.ProductID} Purchased Date: {order.PurchaseDate} Status: {order.OrderStatus}");
                }
            }
            if(!isPurchased)
            {
                Console.WriteLine("You have'nt purchase any product ");
            }  
        }
    
        public static void WalletBalance()
        {
            Console.WriteLine($"Your Wallet Balance is: {currentCustomer.WalletBalance}");
        }

        public static void CancelOrder()
        {
            //fetch order details
            foreach(OrderDetails order in orderDetailsList)
            {
                //match customer id, orderStatus.Ordered
                if(order.CustomerID==currentCustomer.CustomerID && order.OrderStatus==OrderStatus.Ordered)
                {
                    Console.WriteLine($"Order ID: {order.OrderID} ProductID: {order.ProductID} Purchased Date: {order.PurchaseDate} Quantity: {order.Quantity}");
                }
            }
            //ask for order id to cancel
            Console.Write("Enter Order ID to cancel the order:");
            string orderID=Console.ReadLine();
            //fetch order details
            bool ordered=false;
            foreach(OrderDetails order in orderDetailsList)
            {
            //match customer id, order id,orderStatus.Ordered
                if(orderID==order.OrderID && order.CustomerID==currentCustomer.CustomerID && order.OrderStatus==OrderStatus.Ordered)
                {
                //change order status - cancelled
                    ordered=true;
                    order.OrderStatus=OrderStatus.Cancelled;
                
                //fetch product details
                //Match product ID
                    foreach(ProductDetails product in productDetailsList)
                    {
                        if(product.ProductID==order.ProductID)
                        {
                            //using user's recharge method return amount to user
                            currentCustomer.Refund(product.Price);
                            //Increase product count by adding with the order count
                            product.Return(order.Quantity);
                            //show order cancelled successfully
                            Console.WriteLine("Order cancelled successfully");
                        }
                    }
                
                }
            }
            //match order id, status ordered - no - invalid order id
            if(!ordered)
            {
                Console.WriteLine("Invalid order ID");
            }
                    
        }
    
        public static void Purchase()
        {
            //Fetch and show product List
            foreach(ProductDetails product in productDetailsList)
            {
                Console.WriteLine($"Prodeuct Name: {product.ProductName} Product ID: {product.ProductID} Available Stocks: {product.Stock} Price: {product.Price} shipping Duration: {product.ShippingDuration}");
            }
            Console.WriteLine("Enter Product ID to purchase: ");
            //get product id
            string productID=Console.ReadLine();
            Console.WriteLine("Enter the count: ");
            //get product count
            int count=Convert.ToInt32(Console.ReadLine());
            //fetch product details
            bool isAvail=false;
            foreach(ProductDetails product in productDetailsList)
            {
                if(product.ProductID==productID)
                {
                    isAvail=true;
                    if(product.Stock>=count && currentCustomer.WalletBalance>product.TotalAmount(count))
                    {
                        product.Purchase(count);
                        OrderDetails order=new OrderDetails(currentCustomer.CustomerID,productID,product.TotalAmount(count),DateTime.Now,count,OrderStatus.Ordered);
                        orderDetailsList.Add(order);
                        currentCustomer.Purchase(product.TotalAmount(count));
                        Console.WriteLine($"Product Purchased successfully. Your order ID: {order.OrderID}");
                    }
                    else
                    {
                        Console.WriteLine("Cant make transaction, something went wrong");
                        Console.WriteLine("check whether specified count is available or make sure you've sufficient balance in your wallet");
                    }
                }
            }
            if(!isAvail)
            {
                Console.WriteLine("Invalid Product ID");
            }
        }
    }
}