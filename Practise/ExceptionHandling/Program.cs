using System;
namespace ExceptionHandling;
class Program{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter num1");
            int number1=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter num2");
            int number2=Convert.ToInt32(Console.ReadLine());
            if(number2!=0)
            {
                int result=number1/number2;
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Infinitive");
            }
        }
        catch(FormatException e)
        {
            Console.WriteLine(e.Message);
        }
        catch(DivideByZeroException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine(e.StackTrace);
        }
        finally
        {
            Console.WriteLine("All Exception handled");
            Console.WriteLine("Closing database and file connection");
        }
        Console.WriteLine("Hello");
    }
}