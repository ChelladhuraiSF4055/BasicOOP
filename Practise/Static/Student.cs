using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Static
{
    public static class Student
    {
        public static int RegisterNumber;
        public static string Name {get; set;}

        static Student()
        {
            RegisterNumber=1;
            Name="Chella";
        }
        public static string  Display()
        {
            return Name+=RegisterNumber;
        }
    }
}