namespace _4laba
{
    
    class Program
    {
        public delegate void ColorConsoleWrite(ConsoleColor color, string text);
        public static event ColorConsoleWrite? PrintColor;
        static void Colorized(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            PrintColor += Colorized;
            string[,] text1 = new string[4, 4]
            {
                { "C0", "C0", "C0", "CE" },
                { "CE", "C0", "C0", "C0" },
                { "C0", "CE", "C0", "C0" },
                { "C0", "C0", "CE", "C0" }
            };
            string[,] text2 = new string[4, 4]
            {
                { "DC", "DC", "DC", "F1" },
                { "F1", "DC", "DC", "DC" },
                { "DC", "F1", "DC", "DC" },
                { "DC", "DC", "F1", "DC" }
            };
            char[] text = new char[16] { 'f', 'i', 'l', 'i', 'p', 'e', 'n', 'k', 'o', 'm', 'a', 'x', 'i', 'm', 'v', 'a' };

            PrintColor.Invoke(ConsoleColor.Yellow, "ПIБ");
            for (int i = 0; i < 16; i++)
            {
                text1[i / 4, i % 4] = Convert.ToString((int)text[i], 16).ToUpper();
                Console.Write(text1[i / 4, i % 4] + " ");
                if ((i + 1) % 4 == 0) Console.WriteLine();
            }
            Console.WriteLine();

            AEScrypt solution1 = new AEScrypt(text1);
            AEScrypt solution2 = new AEScrypt(text2);

            
            
            AEScrypt result;
            result = AEScrypt.ByteSubstitutionMethod(solution1, solution2);
            PrintColor.Invoke(ConsoleColor.Yellow, "Замiна байтiв");
            AEScrypt.PrintMatrix(result);
            Console.WriteLine();

            
            result = AEScrypt.MixColumnsMethod(result);
            AEScrypt.PrintMatrix(result);
            Console.WriteLine();

            
            AEScrypt key;
            key = AEScrypt.KeyAddition(solution2);
            AEScrypt.PrintMatrix(key);
            Console.WriteLine();

            
            AEScrypt final;
            final = AEScrypt.FinalXOR(result, key);
            AEScrypt.PrintMatrix(final);

            Console.ResetColor();
        }
    }
}