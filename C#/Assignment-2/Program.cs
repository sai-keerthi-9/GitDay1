using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        public static void SwapTwoNumbers(int a, int b)
        {
            Console.WriteLine("Before swapping the first is {0} and second numbers is {1}", a, b);
            int temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After swapping the first number is {0} and the second number is {1}", a, b);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            int y = Convert.ToInt32(Console.ReadLine());
            SwapTwoNumbers(x, y);
            Console.Read();
        }
    }
}
