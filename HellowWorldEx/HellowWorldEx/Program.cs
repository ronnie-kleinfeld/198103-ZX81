using System.Reflection;

namespace HellowWorldEx
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            Console.WriteLine("Hello World Ex");

            string str;

            if (args.Length > 0)
            {
                str = args[0];
            }
            else
            {
                Console.WriteLine("Enter your state ment or number");

                str = Console.ReadLine() ?? "";
            }

            str = str.Trim();

            if (int.TryParse(str, out int number))
            {
                await Hello(number);
            }
            else
            {
                str = str == string.Empty ? "Back to triangle" : str;

                await Hello(str);
            }
        }

        public async static Task Hello(int number)
        {
            Console.WriteLine(number);
            Console.WriteLine();

            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }

        public async static Task Hello(string text)
        {
            Console.WriteLine(text);

            int delay = 75;

            string alphaNumeric = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string str = string.Empty;

            var line = Console.CursorTop + 1;

            for (int i = 0; i < text.Length; i++)
            {
                if (alphaNumeric.Contains(text[i]))
                {
                    var ascii = (text[i].ToString() == text[i].ToString().ToLower()) ? 97 : 65;

                    for (int j = ascii; j < text[i] + 1; j++)
                    {
                        Console.SetCursorPosition(0, line);
                        Console.WriteLine(str + (char)j);

                        await Task.Delay(delay);
                    }

                    str += text[i];
                    line++;
                }
                else
                {
                    await Task.Delay(delay);

                    Console.WriteLine(str + text[i]);

                    str += text[i];
                    line++;
                }
            }
        }
    }
}