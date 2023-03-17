using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecjnology.tasks
{
    public class Task1 : ITask
    {
        public void Execute()
        {
            var input = Console.ReadLine();
            if (input == null || input.Length==0)
            {
                throw new Exception("invalid input");
            }

            var isEven = input.Length % 2 == 0;
            var result = isEven ? Even(input) : Inaccurate(input);
            Console.WriteLine(result); 
        }

        private string Even(string str)
        {
            var halfLength = str.Length / 2;
            var firstPartString = str.Substring(0, halfLength);
            var secondPartString = str.Replace(firstPartString, "");

            firstPartString = ReverseString(firstPartString);
            secondPartString = ReverseString(secondPartString);

            str = firstPartString + secondPartString;
            return str;
        }

        private string Inaccurate(string str)
        {
            var originalString = str;
            str = ReverseString(str);
            str += originalString;
            return str;
        }

        private string ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);

        }
    }
}
