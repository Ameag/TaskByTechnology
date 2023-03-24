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

            SymbolCount(input);
            var isEven = input.Length % 2 == 0;
            var result = isEven ? Even(input) : Inaccurate(input);
            SubstringSearch(result);
            Console.WriteLine("Result: {0}",result);
            string resultSubstring = SubstringSearch(result);
            Console.WriteLine("Final substring: {0}", resultSubstring);
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

            if (invalidCharacters.Count > 0) 
            {
                string unsuitableСharacters = string.Join(" ", invalidCharacters);
                throw new Exception(string.Format("invalid characters entered: {0} ", unsuitableСharacters));
            }


        }

        private void SymbolCount(string str)
        {
            Dictionary<char, int> symbols = new Dictionary<char, int>();
            foreach (char s in str)
            {
                if (symbols.ContainsKey(s))
                {
                    symbols[s] += 1;
                    continue;
                }
                symbols.Add(s, 1);
            }
            foreach (var m in symbols)
            {
                Console.WriteLine($"Symbol: {m.Key}   Count: {m.Value}");
            }
        }

        private string SubstringSearch(string str)
        {
            const string givenLine = "aeiouy";
            var substring = "";
            int startingIndex = 0;
            int endIndex = 0;

            for (int i = 0; i < str.Length; i++)
            {
                var ch = str[i];
                if (givenLine.Contains(ch))
                {
                    startingIndex = i;
                    break;
                }
            }

            for (int i = str.Length - 1; i > 0; i--)
            {
                var ch = str[i];
                if (givenLine.Contains(ch))
                {
                    endIndex = i;
                    break;
                }
            }

            for (int i = startingIndex; i <= endIndex; i++)
            {
                substring = substring + str[i];
            }
            return substring;
        }
    }
}
