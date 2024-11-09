using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program1
    {
        public static void EqualOrNot(int a,int b)
        {
            if (a == b)
            {
                Console.WriteLine("{0} and {1} are equal", a, b);
            }
            else
            {
                Console.WriteLine("{0} and {1} are not equal", a, b);
            }
        }
        public static void PostiveOrNegative(int a)
        {
            if (a > 0)
            {
                Console.WriteLine("{0} is a positive number", a);
            }
            else
            {
                Console.WriteLine("{0} is a Negative number", a);
            }

        }
        public static void Calculations(int a, char op, int b)
        {
            switch (op)
            {

                case '+':
                    Console.WriteLine(a + b);
                    break;
                case '-':
                    Console.WriteLine(a - b);
                    break;
                case '*':
                    Console.WriteLine(a * b);
                    break;
                case '/':
                    Console.WriteLine(a / b);
                    break;
                default:
                    Console.WriteLine("Invalid Operator");
                    break;

            }
        }

    }
    class Driver
    {
        static void Main(string[] args)
        {
            //To check two numbers are equal or not
            Console.WriteLine("Enter first number");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter second number");
            int b = Convert.ToInt32(Console.ReadLine());
            Program1.EqualOrNot(a, b);
            Console.Read();
        }
    }
}
