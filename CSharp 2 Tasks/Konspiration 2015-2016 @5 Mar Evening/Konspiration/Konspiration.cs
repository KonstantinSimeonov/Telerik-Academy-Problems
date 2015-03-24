using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static string nextLine;
    static string stat = "static";
    static long openBrackets = 0;
    static StringBuilder scope = new StringBuilder();
    static StringBuilder result = new StringBuilder();
    static int counter = 0;

    static void Main()
    {

        int n = int.Parse(Console.ReadLine());
        int cake = 0;

        for (int i = 1; i < n; i++)
        {

            nextLine = Console.ReadLine();



            bool st = nextLine.IndexOf(stat) != -1;
            bool first = st;
            bool none = false;


            while (st || openBrackets > 0)
            {
                if (nextLine.IndexOf("new") > nextLine.IndexOf("(") || nextLine.IndexOf("new") == -1)
                    scope.Append(nextLine);

                nextLine = Console.ReadLine();
                i++;

                st = false;
                if (nextLine.IndexOf("{") != -1)
                    openBrackets++;
                if (nextLine.IndexOf("}") != -1)
                    openBrackets--;

            }

            int next = 0;

            string sc = scope.ToString();
            scope.Clear();


            while (next != -1)
            {
                bool has = false;

                if (next + 1 < sc.Length)
                    next = sc.IndexOf("(", next + 1);
                else
                    break;


                if (next == -1)
                    break;
                int index = next;

                index--;
                if (index >= 0)
                {
                    while (sc[index] == ' ')
                    {
                        if (index > 0)
                        {
                            index--;

                        }
                        else
                            break;
                    }
                }

                int store = index;

                if (index >= 0)
                {
                    while (char.IsLetter(sc[index]))
                    {
                        if (char.IsUpper(sc[index]))
                        {
                            if (index > 0)
                            {
                                if (char.IsLetter(sc[index]))
                                {
                                    while (char.IsLetter(sc[index]) && index > 0)
                                        index--;
                                }
                            }
                            if (store - index >= 1 && sc.Substring(index + 1, store - index) != string.Empty && sc.Substring(index + 1, store - index) != " ")
                            {
                                result.Append(sc.Substring(index + 1, store - index));

                                has = true;
                                none = true;
                                break;
                            }
                        }
                        index--;
                        if (index < 0)
                            break;
                    }
                }


                if (first)
                {
                    result.Append(" -> ");
                    cake = result.ToString().Length;
                    first = false;
                }
                else if (has)
                {
                    none = false;
                    result.Append(", ");
                    counter++;
                }
            }

            if (result.Length - 2 >= 1 && !none)
            {
                result.Remove(result.Length - 2, 2);
                result.AppendLine();

                if (counter > 0)
                    result.Insert(cake, counter.ToString() + " -> ");

                cake = 0;
                counter = 0;
            }
            else if (none)
            {
                result.Append("None");
                result.AppendLine();
            }
        }

        cake = 0;

        while (!char.IsLetter(result[cake]))
            cake++;

        result.Remove(0, cake);

        Console.WriteLine(result);
    }
}