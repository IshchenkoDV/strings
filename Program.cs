namespace ConsoleApp1
{

    public class Program
    {
        public static string CreatePhoneNumber(int[] num)
        {
            if (num.Length != 10)
                throw new ArgumentException("только 10 цифр");
            return $"8 ({num[0]}{num[1]}{num[2]}) {num[3]}{num[4]}{num[5]}-{num[6]}{num[7]}-{num[8]}{num[9]}";
        }

        public static string TrimString(string phrase, int len)
        {
            if (string.IsNullOrEmpty(phrase))
            {
                return phrase;
            }
            if (phrase.Length <= len)
            {
                return phrase;
            }
            if (len <= 3)
            {
                return phrase.Substring(0, Math.Max(0, len - 3)) + "...";
            }
            return phrase.Substring(0, len - 3) + "...";
        }

        public static long SquareDigits(long n)
        {
            string result = "";
            foreach (char digit in n.ToString())
                result += ((digit - '0') * (digit - '0')).ToString();
            return long.Parse(result);
        }

        public static string Likes(string[] names)
        {
            int count = names.Length;
            switch (count)
            {
                case 0: return "no one likes this";
                case 1: return $"{names[0]} likes this";
                case 2: return $"{names[0]} and {names[1]} like this";
                case 3: return $"{names[0]}, {names[1]} and {names[2]} like this";
                default: return $"{names[0]}, {names[1]} and {count - 2} others like this";
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("10 цифр через пробел");
            string[] phoneDigitsStr = Console.ReadLine().Split(' ');
            int[] phoneDigits = new int[10];
            for (int i = 0; i < 10; i++)
            {
                if (!int.TryParse(phoneDigitsStr[i], out phoneDigits[i]))
                {
                    return;
                }
            }
            Console.WriteLine(CreatePhoneNumber(phoneDigits));

            Console.WriteLine("строка");
            string phrase = Console.ReadLine();
            Console.WriteLine("длина для обрезки");
            if (!int.TryParse(Console.ReadLine(), out int len))
            {
                return;
            }
            Console.WriteLine(TrimString(phrase, len));


            Console.WriteLine("число");
            if (!long.TryParse(Console.ReadLine(), out long n))
            {
                return;
            }
            Console.WriteLine(SquareDigits(n));


            Console.WriteLine("имена через запятую");
            string[] names = Console.ReadLine().Split(',');
            for (int i = 0; i < names.Length; i++)
                names[i] = names[i].Trim();
            Console.WriteLine(Likes(names));
        }
    }

}
