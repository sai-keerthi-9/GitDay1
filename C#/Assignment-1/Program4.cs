﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program4
    {
        //Program to print table of the given number
        public static void MultiplicationOfTable(int n)
        {
          
            for(int i=1;i<=10;i++)
            {
                Console.WriteLine("{0} * {1} ={2} ", n, i,n*i);
            }
        }
        public static void Main()
        {
            Console.WriteLine("Enter a number");
            int n = Convert.ToInt32(Console.ReadLine());
            MultiplicationOfTable(n);
            Console.Read();
        }
    }
}
