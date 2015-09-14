namespace Flyweight
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var factory = new EmoticonFactory();

            var emotesText = new string[] { ":D", "T_T", ":P", "^_-" };
            var users = new string[] { "Pesho", "Tosho", "Ivan", "Mariya" };

            var rng = new Random();

            for (int i = 0; i < 20; i++)
            {
                factory.GetEmoticon(emotesText[rng.Next() % emotesText.Length]).Print(users[rng.Next() % users.Length], 0, i);
            }

            Console.SetCursorPosition(0, 21);
            Console.WriteLine("Created emoticons: " + factory.ObjectsCreated);
        }
    }
}
