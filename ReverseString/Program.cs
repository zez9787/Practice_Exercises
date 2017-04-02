using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseString
{
    public class Program
    {
        static void Main(string[] args)
        {
            string reverseString = Console.ReadLine();
            Console.WriteLine(ReverseThisString(reverseString));
            Console.ReadLine();
        }

        public static string ReverseThisString(string s)
        {
            char[] sArray = s.ToCharArray();
            Array.Reverse(sArray);
            return new string(sArray);
        }
    }
}
