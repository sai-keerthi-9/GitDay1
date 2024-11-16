using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    class Program_2
    {
        static void Main()
        {
            List<string> str = new List<string>();
            Console.WriteLine("Enter the number of elements in the list : ");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                Console.WriteLine("Enter the {0} element n the list : ", i + 1);
                string name = Console.ReadLine();
                str.Add(name);
            }
            var result_names = from s in str
                               where s.StartsWith("a") && s.EndsWith("m")
                               select s;
            Console.WriteLine("The output list lis : ");
            foreach(var i in result_names)
            {
                Console.WriteLine(i + " ");
            }
            Console.Read();

        }
        
}
}
