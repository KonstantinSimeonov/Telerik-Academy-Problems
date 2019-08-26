namespace UnitsOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Unit : IComparable<Unit>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Attack { get; set; }

        public Unit(string name, string type, int attack)
        {
            this.Name = name;
            this.Type = type;
            this.Attack = attack;
        }

        public override string ToString()
        {
            return this.Name + "[" + this.Type + "](" + this.Attack + ")";
        }

        public override bool Equals(object obj)
        {
            var objAsUnit = obj as Unit;

            if (objAsUnit == null)
            {
                return false;
            }

            return objAsUnit.Name == this.Name;
        }

        public int CompareTo(Unit other)
        {
            if (this.Attack - other.Attack != 0)
            {
                return other.Attack - this.Attack;
            }

            return other.Name.CompareTo(this.Name);
        }
    }

    public class Solution
    {
        private static Dictionary<string, Unit> byName = new Dictionary<string, Unit>();
        private static Dictionary<string, ICollection<Unit>> byType = new Dictionary<string, ICollection<Unit>>();
        private static Dictionary<int, ICollection<Unit>> byPower = new Dictionary<int, ICollection<Unit>>();
        private static StringBuilder output = new StringBuilder();

        static void Main()
        {
            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            while (true)
            {
                switch (input[0].ToLower())
                {
                    case "end":
                        Console.WriteLine(output.ToString().Trim());
                        return;
                    case "add":
                        var unitToAdd = new Unit(input[1], input[2], int.Parse(input[3]));

                        if (byName.ContainsKey(unitToAdd.Name))
                        {
                            output.AppendLine("FAIL: " + unitToAdd.Name + " already exists!");
                            break;
                        }

                        byName.Add(unitToAdd.Name, unitToAdd);

                        if (!byType.ContainsKey(unitToAdd.Type))
                        {
                            byType.Add(unitToAdd.Type, new List<Unit>());
                        }

                        byType[unitToAdd.Type].Add(unitToAdd);

                        if (!byPower.ContainsKey(unitToAdd.Attack))
                        {
                            byPower.Add(unitToAdd.Attack, new List<Unit>());
                        }

                        byPower[unitToAdd.Attack].Add(unitToAdd);

                        output.AppendLine("SUCCESS: " + unitToAdd.Name + " added!");

                        break;
                    case "remove":

                        var name = input[1];

                        if (!byName.ContainsKey(name))
                        {
                            output.AppendLine("FAIL: " + name + " could not be found!");
                            break;
                        }

                        var toRemove = byName[name];
                        byName.Remove(name);

                        byType[toRemove.Type].Remove(toRemove);
                        byPower[toRemove.Attack].Remove(toRemove);

                        output.AppendLine("SUCCESS: " + name + " removed!");
                        break;

                    case "find":
                        if (!byType.ContainsKey(input[1]))
                        {
                            output.AppendLine("RESULT: ");
                            break;
                        }

                        var result = byType[input[1]]
                                                .OrderByDescending(x => x.Attack)
                                                .ThenBy(x => x.Name)
                                                .Take(10)
                                                .ToList();

                        output.AppendLine("RESULT: " + string.Join(", ", result));
                        break;

                    case "power":
                        output.Append(GetByPower(int.Parse(input[1])));
                        break;

                    default:
                        break;
                }

                input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }
        }

        public static string GetByPower(int power)
        {
            var counter = 0;

            var topTen = new List<Unit>();

            var keys = byPower.Keys.OrderByDescending(x => x).ToList();

            foreach (var k in keys)
            {
                var next = byPower[k].OrderBy(x => x.Name).ToList();

                foreach (var item in next)
                {
                    topTen.Add(item);
                    counter++;

                    if (counter >= power)
                    {
                        return "RESULT: " + string.Join(", ", topTen);
                    }
                }
            }

            return "RESULT: " + string.Join(", ", topTen);
        }
    }
}