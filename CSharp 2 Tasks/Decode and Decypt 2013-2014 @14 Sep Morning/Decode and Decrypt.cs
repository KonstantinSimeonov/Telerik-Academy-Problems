namespace DecryptDecode
{
    using System;
    using System.Text;

    class Program
    {
        public static StringBuilder workplace = new StringBuilder();

        public static string Encrypt(string message, string cypher)
        {
            if (message.Length > cypher.Length)
            {
                var result = new StringBuilder();
                for (int i = 0; i < message.Length; i++)
                {
                    result.Append((char)(((message[i] - 65) ^ (cypher[i % cypher.Length] - 65)) + 65));
                }

                return result.ToString();
            }
            else
            {
                var result = new StringBuilder(message);

                for (int i = 0; i < cypher.Length; i++)
                {
                    result[i % message.Length] = (char)(((result[i % message.Length] - 65) ^ (cypher[i] - 65)) + 65);
                }
                return result.ToString();
            }
        }

        public static string Encode(string message)
        {
            for (int i = 0; i < message.Length - 1; i++)
            {
                int repeat = i;
                while (message[i] == message[i + 1])
                {
                    i++;
                    if (i >= message.Length - 1)
                        break;
                }

                if (repeat <= i - 2)
                {
                    message = message.Remove(repeat, i - repeat + 1).Insert(repeat, i - repeat + 1 + message[i].ToString());
                    i = repeat + 1;
                }

            }

            return message;

        }

        public static string Decode(string message)
        {
            var result = new StringBuilder(message);

            for (int i = 0; i < result.Length; i++)
            {
                if (char.IsDigit(result[i]))
                {

                    int start = i;
                    workplace.Append(result[i++]);
                    while (char.IsDigit(result[i]))
                    {
                        workplace.Append(result[i++]);
                    }

                    char toInsert = result[i];

                    string str = workplace.ToString();

                    workplace.Clear();

                    int numz = int.Parse(str);

                    result.Remove(start, str.Length);
                    result.Insert(start, toInsert.ToString(), numz - 1);

                }
            }

            return result.ToString();
        }



        public static string Decrypt(string message)
        {
            workplace.Clear();
            int save = 0;

            for (int i = message.Length - 1; char.IsDigit(message[i]); i--)
            {
                workplace.Insert(0, message[i]);
                save = i;
            }

            int cypherLength = int.Parse(workplace.ToString());

            workplace.Clear();


            string decoded = Decode(message.Remove(save, message.Length - save));
            string cypher = decoded.Substring(decoded.Length - cypherLength, cypherLength);
            message = decoded.Remove(decoded.Length - cypherLength, cypherLength);
            return Encrypt(message, cypher);

        }

        static void Main(string[] args)
        {
            Console.WriteLine(Decrypt(Console.ReadLine()));
        }
    }
}