using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConvertPigLatin(Console.ReadLine()));
            Console.ReadLine();
        }

        static string ConvertPigLatin(string s)
        {
            return (s + "-" + s.Substring(0, 1) + "ay").Remove(0, 1);
        }
    }
}
