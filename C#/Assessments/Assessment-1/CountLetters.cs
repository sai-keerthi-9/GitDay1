using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_1
{
    class CountLetters
    {
        public static int Count_OccurencesOfLetter(string s1,char ch)
        {
            int count = 0;
            foreach(char c in s1.ToLower())
            {
                if(c==char.ToLower(ch))
                {
                    count++;
                }
            }
            return count;
        }
        public static void Main()
        {
            Console.WriteLine("Enter the string : ");
            string s1 = Console.ReadLine();
            Console.WriteLine("Enter the character to count : ");
            char ch = Convert.ToChar(Console.ReadLine());
            Console.WriteLine("The number of occurrences of the given letter in the given string : {0}", Count_OccurencesOfLetter(s1, ch));
            Console.Read();
        }
    }
}
