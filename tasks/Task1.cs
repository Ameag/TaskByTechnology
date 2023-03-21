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
            Console.Write("Enter the string ");
            var input = Console.ReadLine();
            try
            {
                if (input == null || input.Length == 0)
                {
                    throw new Exception("invalid input");
                }
                StringСheck(input);
            }
            catch (Exception ex) 
            {
                Console.Write(ex.Message);
                System.Environment.Exit(1);
            }
            
            var isEven = input.Length % 2 == 0;
            var result = isEven ? Even(input) : Inaccurate(input);
            Console.WriteLine("Result: {0}",result); 
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

        private void StringСheck(string str)
        {
            List<char> invalidCharacters = new List<char>();

            for (int i = 0; i < str.Length; i++)
            {
                char character = str[i];
                if (character >= 'a' && character <= 'z') { continue; }
                invalidCharacters.Add(character);
            }

            if (invalidCharacters.Count == 0) 
            {
                string unsuitableСharacters = string.Join(" ", invalidCharacters);
                throw new Exception(string.Format("invalid characters entered: {0} ", unsuitableСharacters));
            }


        }
    }
}
