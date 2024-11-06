using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class LargestNumber
    {
        public void Largest(int a,int b,int c)
        {
            if(a>b && a>c)
            {
                Console.WriteLine("The largest number is {0} ", a);
            }
            else if(b>a && b>c)
            {
                Console.WriteLine("The largest number is {0} ", b);
            }
            else
            {
                Console.WriteLine("The largest number is {0} ", c);
            }
        }
        public static void Main()
        {
            Console.WriteLine("Enter the first Number : ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Second Number : ");
            int b= Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Third Number : ");
            int c= Convert.ToInt32(Console.ReadLine());
            LargestNumber ob = new LargestNumber();
            ob.Largest(a, b, c);
            Console.Read();
        }
    }
}
