using System;
using System.Collections.Generic;
namespace Ecommerce;
class Program{
    public static void Main(string[] args)
    {
        List<CustomerDetails>customerList=new List<CustomerDetails>();
        List<OrderDetails>orderDetailsList=new List<OrderDetails>();
        List<ProductDetails>productDetailsList=new List<ProductDetails>();

        CustomerDetails customer1=new CustomerDetails("Ravi","Chennai",98858588,50000,"ravi@gmail.com");
        customerList.Add(customer1);
        CustomerDetails customer2=new CustomerDetails("Baskaran","Chennai",9888475757,60000,"baskaran@gmail.com");
        customerList.Add(customer2);

        OrderDetails order1=new OrderDetails("CID1001","PID101",20000,DateTime.Now,2,OrderStatus.Ordered);
        orderDetailsList.Add(order1);
        OrderDetails order2=new OrderDetails("CID1002","PID103",4000,DateTime.Now,2,OrderStatus.Ordered);
        orderDetailsList.Add(order2);

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

        int choice;
        Console.WriteLine("Press choice:");
        choice=Convert.ToInt32(Console.ReadLine());
        char action;
        CustomerDetails commonCustomer=new CustomerDetails();
        if(choice==2)
        {
            Console.Write("Enter the CustomerID:");
            string customerID=Console.ReadLine();
            bool check=false;
            ProductDetails locateProduct=new ProductDetails();
            foreach(CustomerDetails customer in customerList)
            {
                if(customerID==customer.CustomerID)
                {
                    check=true;
                    commonCustomer=customer;
                }
            }
            if(check==false)
            {
                Console.WriteLine("No CustomerID found");
            }
            else if(check)
            {
                DateTime today=DateTime.Now;
                do{
                Console.WriteLine("Press:\na.Purchase\nb.OrderHistory\nc.Cancel Order\nd.Wallet Balance\ne.Exit");
                action=char.Parse(Console.ReadLine());
                if(action=='a')
                {
                    foreach(ProductDetails product in productDetailsList)
                    {
                        Console.WriteLine($"Product ID: {product.ProductID}\tProduct: {product.ProductName}\tStock Quantity:{product.Stock}");
                        Console.WriteLine($"Price per Quantity: {product.Price}\t Shipping duration: {product.ShippingDuration}");
                    }
                    Console.Write("Enter product ID:");
                    string productID=Console.ReadLine();
                    Console.Write("Enter the number of products required: ");
                    int count=Convert.ToInt32(Console.ReadLine());
                    bool isProductAvail=false;
                    bool stockExist=false;
                    foreach(ProductDetails product in productDetailsList)
                    {
                        if(productID==product.ProductID)
                        {  
                            locateProduct=product;
                            isProductAvail=true;
                            if(locateProduct.Stock>count)
                            {
                                stockExist=true;   
                                int amount=locateProduct.TotalAmount(count);
                                if(commonCustomer.WalletBalance<amount)
                                {   
                                     Console.WriteLine("Insufficient wallet balance\nPlease recharge your wallet");   
                                }
                                else
                                {
                                    Console.Write($"Pay Now: ({amount}): ");
                                    int amountPayed=Convert.ToInt32(Console.ReadLine());
                                    if(amountPayed==amount)
                                    {
                                        commonCustomer.Purchase(amountPayed);
                                        locateProduct.Purchase();
                                        OrderDetails order=new(commonCustomer.CustomerID,productID,amount,today,count,OrderStatus.Ordered);
                                        orderDetailsList.Add(order);
                                        Console.WriteLine($"Order Placed:\nOrderID: {order.OrderID}  Purchased Date: {today}  Quantity: {order.Quantity}\nOrderStatus:{order.OrderStatus} ");
                                        Console.WriteLine($"Order will be delivered by{today.AddDays(locateProduct.ShippingDuration).ToShortDateString()}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Transaction failed due to inappropriate amount");
                                    }
                                }
                            }
                        }
                    }
                    if(isProductAvail==false)
                    {
                        Console.WriteLine("Enter Valid ProductID");
                    }
                    if(stockExist==false)
                    {
                        Console.WriteLine($"Required count is not available\nAvaiality is:{locateProduct.Stock}");
                    }

                }
                else if(action == 'b')
                {
                    foreach(OrderDetails order in orderDetailsList)
                    {
                        if(commonCustomer.CustomerID==order.CustomerID)
                        {
                            {
                                Console.WriteLine($"customerID:{order.CustomerID}  ProductName: {order.ProductID}  TotalPrice: {order.TotalPrice}");
                                Console.WriteLine($"PurchasedDate: {order.PurchaseDate.ToShortDateString()}   Quantity:{order.Quantity} Order Status: {order.OrderStatus}");
                            }
                        }
                    }
                }
                else if(action == 'c')
                {
                    bool ordered=false;
                    foreach(OrderDetails order in orderDetailsList)
                    {
                        if(commonCustomer.CustomerID==order.CustomerID && order.OrderStatus==OrderStatus.Ordered)
                        {
                            ordered=true;
                            Console.WriteLine($"Placed Orders :\nOrderID: {order.OrderID}  Purchased Date: {today} ProductID:{order.ProductID}");
                            Console.WriteLine($"Quantity: {order.Quantity} TotalAmount: {order.TotalPrice} OrderStatus:{order.OrderStatus} ");
                            Console.WriteLine($"Order will be delivered by{today.AddDays(locateProduct.ShippingDuration).ToShortDateString()}");
                        }
                    }
                    if(ordered==false)
                    {
                        Console.WriteLine("You've not placed any order");
                    }
                    if(ordered)
                    {
                            Console.WriteLine("Enter the Order ID:");
                            string orderID=Console.ReadLine();
                            foreach(OrderDetails order in orderDetailsList)
                            {
                                if(orderID==order.OrderID)
                                {
                                    Console.WriteLine("Proceed to Cancel (yes/no): ");
                                    string answer=Console.ReadLine().ToLower();
                                    if(answer=="yes")
                                    {
                                        locateProduct.Return();
                                        order.Return();
                                        commonCustomer.Refund(order.TotalPrice);
                                        Console.WriteLine("Ordered Cancelled");
                                    }
                                }
                            }
                    }
                }
                else if(action == 'd')
                {
                    Console.WriteLine($"Your Balance: {commonCustomer.WalletBalance}");
                }
            }while(action!= 'e');
            }

        }



        

    }
}