using System;
namespace ValueRefer;
class Program{
    public static void Main(string[] args)
    {
        int number1=10;
        int number2=number1;
        Console.WriteLine($"Number1:{number1},Number2:{number2}");
        number2=20;
        Console.WriteLine($"Number1:{number1}, Number2:{number2}");

        ClassRefer object1;//allocates memory in heap 
        object1=new ClassRefer();//Object created (Null)
                                //allocates memory in stack with the address stored in stack memory
        object1.Number=20;
        ClassRefer object2=object1;//allocates same memory address in stack
        
        Console.WriteLine($"Number1:{object1.Number} Number2:{object2.Number}");
        object2.Number=40;
        Console.WriteLine($"Number1:{object1.Number} Number2:{object2.Number}");
    }
}