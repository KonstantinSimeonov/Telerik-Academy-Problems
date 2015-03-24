namespace FTML
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;

    class FTMLParser
    {
        static StringBuilder input = new StringBuilder(200000);
        static string closing;


        static string GetClosingTag(int start, string text)
        {
            switch (text[start + 2])
            {
                case 'd': return del;
                case 'u': return upper;
                case 'l': return lower;
                case 'r': return rev;
                case 't': return toggle;
                default: throw new ArgumentException();
            }
        }

        static string InvertCase(string s)
        {
            StringBuilder invert = new StringBuilder(s);

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsLower(invert[i]))
                {
                    invert[i] = char.ToUpper(invert[i]);
                }
                else
                {
                    invert[i] = char.ToLower(invert[i]);
                }
            }

            return invert.ToString();
        }

        static string Reverse(string toReverse)
        {
            StringBuilder s = new StringBuilder();

            for (int i = 0; i < toReverse.Length; i++)
            {
                s.Append(toReverse[toReverse.Length - i - 1]);
            }

            return s.ToString();
        }

        static int arrowPos;
        static int startClosing;

        const string lower = "</lower>";
        const string upper = "</upper>";
        const string rev = "</rev>";
        const string del = "</del>";
        const string toggle = "</toggle>";


        static void Main()
        {

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                input.Append(Console.ReadLine());
                if (i != n - 1)
                {
                    input.Append("\n");
                }
            }

            var text = input.ToString();


            while (true)
            {

                arrowPos = text.IndexOf("</");
                startClosing = arrowPos;

                if (arrowPos == -1)
                    break;

                closing = GetClosingTag(arrowPos, text);
                arrowPos--;

                while (text[arrowPos] != '<')
                    arrowPos--;

                switch (closing)
                {
                    case lower:
                        text = text.Remove(arrowPos, startClosing + closing.Length - arrowPos)
                            .Insert(arrowPos, text.Substring(arrowPos + closing.Length - 1, startClosing - arrowPos - closing.Length + 1)
                            .ToLower());
                        break;

                    case upper:
                        text = text.Remove(arrowPos, startClosing + closing.Length - arrowPos)
                            .Insert(arrowPos, text.Substring(arrowPos + closing.Length - 1, startClosing - arrowPos - closing.Length + 1)
                            .ToUpper());
                        break;

                    case del:
                        text = text.Remove(arrowPos, startClosing + closing.Length - arrowPos);
                        break;

                    case rev:
                        text = text.Remove(arrowPos, startClosing + closing.Length - arrowPos)
                            .Insert(arrowPos, Reverse(text.Substring(arrowPos + closing.Length - 1, startClosing - arrowPos - closing.Length + 1)));
                        break;

                    case toggle:
                        text = text.Remove(arrowPos, startClosing + closing.Length - arrowPos)
                            .Insert(arrowPos, InvertCase(text.Substring(arrowPos + closing.Length - 1, startClosing - arrowPos - closing.Length + 1)));
                        break;

                    default:
                        break;
                }

            }

            Console.WriteLine(text);
        }
    }
}
