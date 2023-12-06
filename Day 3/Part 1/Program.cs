using System;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;

namespace Part1
{
    public class Program
    {
        static string[] input = File.ReadAllText(@"C:\Users\Mitko\Projects\C#\Advent of code\Day 3\Part 1\bin\Debug\net7.0\input.txt").Split("\n");
        static char[] symbols = {'@', '#', '$', '%', '&', '*', '/', '+', '-', '='};
        public static void Main(string[] args)
        {
            Program program = new Program();
            int sum = 0;

            foreach(string s in input)
            {
              int row = Array.IndexOf(input, s); 
              for(int i = 0; i < s.Length; i++)
              {
                 char position = s[i];
                 if (position == '.')
                 {
                     continue;
                 }
                 else if (symbols.Contains(position))
                 {
                    sum += program.calculate(row, i);
                        if (row < input.Length - 1)
                        {
                            sum += program.calculate(row + 1, i);
                        }
                        if (row == 0)
                        {
                            continue;
                        }
                        else
                        {
                            sum += program.calculate(row - 1, i);
                        }           
                    }
                }
            }
         Console.WriteLine(sum);
            Console.ReadLine();
         }

        public int calculate(int rowNum, int colNum)
        {
            string row = input[rowNum];
            List<int> list = new List<int> {colNum - 1, colNum, colNum + 1};         
            int numCount = 0;
            Regex regex = new Regex(@"\d+");
            MatchCollection matches = regex.Matches(row);

            foreach (Match m in matches)
            {
                string number = m.Value;
                if (AnyIndexInList(list, m.Index, m.Length))
                {         
                    numCount = numCount + Convert.ToInt32(number);
                }
            }
            return numCount;
        }
        static bool AnyIndexInList(List<int> list, int startIndex, int length)
        {
            for (int i = startIndex; i < startIndex + length; i++)
            {
                if (list.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
