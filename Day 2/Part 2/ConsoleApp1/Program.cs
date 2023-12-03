using System;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.IO;

namespace Part1
{
    public class Program
    {
        public static List<int> powers = new List<int>();
        public static string[] input = File.ReadAllLines("input.txt");
        public static void Main()
        {

            for (int i = 0; i < 100; i++)
            {

                powers.Add(power(i));

            }

            Console.WriteLine(powers.Sum());
            Console.ReadLine();
        }

        static int power(int gnumber)

        {
            string line = input[gnumber];






            int red = ParseInts(line, @"(\d+) red").Max();
            int green = ParseInts(line, @"(\d+) green").Max();
            int blue = ParseInts(line, @"(\d+) blue").Max();

            return red * green * blue;






        }
        static IEnumerable<int> ParseInts(string input, string pattern)
        {
            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                yield return int.Parse(match.Groups[1].Value);
            }

        }

    }


}
