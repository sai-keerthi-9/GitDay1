using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculateConcessionForTravel;

namespace Assignment_6
{
    class Program_4
    {
        const int total_fare = 500;
        static string Name;
        static int Age;
        static void Main()
        {
            Console.WriteLine("Enter the name : ");
            Name = Console.ReadLine();
            Console.WriteLine("Enter the age :");
            Age = Convert.ToInt32(Console.ReadLine());
            Calculate obj = new Calculate();
            obj.CalculateConcession(Name,Age);
            Console.Read();
        }
    }
}
