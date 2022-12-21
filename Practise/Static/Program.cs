using System;
namespace Static;
public class Program{
     static void Main(string[] args)
    {
        Console.WriteLine(Student.Display());

        Console.WriteLine(Student.RegisterNumber);
        Student.RegisterNumber=22;
        Console.WriteLine(Student.RegisterNumber);
    }
}