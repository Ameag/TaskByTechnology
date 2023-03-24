using System.Runtime.InteropServices;

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
            Console.WriteLine("Result: {0}", result);
            var resultSubstring = SubstringSearch(result);
            Console.WriteLine("Final substring: {0}", resultSubstring);

            Console.Write("Choose a sorting method Quicksort(q) or Tree sort(t): ");
            var inputChoice = Console.ReadLine();
            if (inputChoice != null && inputChoice == "q")
            {
                var SortdString = QuickSort(result);
                Console.WriteLine("Sorted Array (Quick Sort): {0}", SortdString);
            }
            else if(inputChoice != null&& inputChoice=="t") 
            {
                var SortdString = TreeSort(result);
                Console.WriteLine("Sorted Array (Tree sort): {0}", SortdString);
            }
            else
            {
                Console.WriteLine("invalid input");
            }
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


        //метод возвращающий индекс опорного элемента
        private static int FindPivot(char[] str, int minIndex, int maxIndex)
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
        private static char[] Sort(char[] str, int minIndex, int maxIndex)
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

        private static string QuickSort(string str)
        {
            char[] charStr = str.ToCharArray();
            charStr = Sort(charStr, 0, charStr.Length - 1);
            return new string(charStr);
        }

        private string TreeSort(string str)
        {
            char[] charStr = str.ToCharArray();
            var treeNode = new TreeNode(charStr[0]);
            for (int i = 1; i < str.Length; i++)
            {
                treeNode.Insert(new TreeNode(charStr[i]));
            }

            return new string(treeNode.Transform());
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
