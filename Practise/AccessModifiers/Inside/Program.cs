using System;
namespace Inside;
class Program: {
    public static void Main(string[] args)
    {
        First one=new First();
        Console.WriteLine(one.PublicNumber);
        //Console.WriteLine(one.PrivateNumber);
        Console.WriteLine(one.PrivateOut);
        Console.WriteLine(one.InternalNumber);
        //Console.WriteLine(one.ProtectedNumber);
        Console.WriteLine(one.ProtectedLevel);

        Second two=new Second();
       // Console.WriteLine(two.ProtectedInherited);
        //Console.WriteLine(two.ProtectedInternal);

    }
}