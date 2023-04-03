using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace TechnologyASP
{
    public class Execute
    {
        public string Even(string str)
        {
            var halfLength = str.Length / 2;
            var firstPartString = str.Substring(0, halfLength);
            var secondPartString = str.Substring(halfLength);

            firstPartString = ReverseString(firstPartString);
            secondPartString = ReverseString(secondPartString);

            str = firstPartString + secondPartString;
            return str;
        }

        public string Inaccurate(string str)
        {
            var originalString = str;
            str = ReverseString(str);
            str += originalString;
            return str;
        }

        public string ReverseString(string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);

        }

        public HashSet<char> StringСheck(string str)
        {
            HashSet<char> invalidCharacters = new HashSet<char>();

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
            return invalidCharacters;

        }

        public Dictionary<char, int> SymbolCount(string str)
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
            return symbols;
        }

        public string SubstringSearch(string str)
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

            if (startingIndex != 0 && endIndex != 0)
            {
                for (int i = startingIndex; i <= endIndex; i++)
                {
                    substring = substring + str[i];
                }
            }
            return substring;
        }


        //метод возвращающий индекс опорного элемента
        public static int FindPivot(char[] str, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            char temp;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (str[i] < str[maxIndex])
                {
                    pivot++;
                    temp = str[pivot];
                    str[pivot] = str[i];
                    str[i] = temp;
                }
            }

            pivot++;
            temp = str[pivot];
            str[pivot] = str[maxIndex];
            str[maxIndex] = temp;
            return pivot;
        }

        //быстрая сортировка
        public static char[] Sort(char[] str, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return str;
            }

            var pivotIndex = FindPivot(str, minIndex, maxIndex);
            Sort(str, minIndex, pivotIndex - 1);
            Sort(str, pivotIndex + 1, maxIndex);

            return str;
        }

        public  string QuickSort(string str)
        {
            char[] charStr = str.ToCharArray();
            charStr = Sort(charStr, 0, charStr.Length - 1);
            return new string(charStr);
        }

        public string TreeSort(string str)
        {
            char[] charStr = str.ToCharArray();
            var treeNode = new TreeNode(charStr[0]);
            for (int i = 1; i < str.Length; i++)
            {
                treeNode.Insert(new TreeNode(charStr[i]));
            }

            return new string(treeNode.Transform());
        }

        public int GetNumberApi(string str)
        {
            string url = string.Format("https://www.random.org/integers/?num=1&min=1&max={0}&col=1&base=10&format=plain&rnd=new", str.Length);
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpWebResponse.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Api issues");
            }
            string response;
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream()))
            {
                response = streamReader.ReadToEnd();
            }
            return int.Parse(response);
        }

        public string DeleteSymbol(string str, int number)
        {
            Console.WriteLine(number);
            if ((number > 0) && (number <= str.Length))
            {
                str = str.Remove(number - 1, 1);
                Console.WriteLine("String with character removed: {0}", str);
                return str;
            }
            throw new Exception("invalid input");
        }
        public int BadRequest()
        {
            return StatusCodes.Status400BadRequest;
            //return HttpStatusCode.BadRequest;
        }
        

    }

    public class TreeNode
    {
        //данные
        public char Data { get; set; }

        //левая ветка дерева
        public TreeNode? Left { get; set; }

        //правая ветка дерева
        public TreeNode? Right { get; set; }

        public TreeNode(char data)
        {
            Data = data;
        }

        //рекурсивное добавление узла в дерево
        public void Insert(TreeNode node)
        {
            if (node.Data < Data)
            {
                if (Left == null)
                {
                    Left = node;
                }
                else
                {
                    Left.Insert(node);
                }
            }
            else
            {
                if (Right == null)
                {
                    Right = node;
                }
                else
                {
                    Right.Insert(node);
                }
            }
        }

        //преобразование дерева в отсортированный массив
        public char[] Transform(List<char>? elements = null)
        {
            if (elements == null)
            {
                elements = new List<char>();
            }

            if (Left != null)
            {
                Left.Transform(elements);
            }

            elements.Add(Data);

            if (Right != null)
            {
                Right.Transform(elements);
            }

            return elements.ToArray();
        }
    }
}

