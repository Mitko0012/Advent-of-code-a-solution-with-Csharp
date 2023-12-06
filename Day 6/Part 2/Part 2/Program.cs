using System;
using static System.Net.Mime.MediaTypeNames;

namespace Part1
{
    public class Program
    {
        static string[] input = File.ReadAllLines(@"C:\Users\Mitko\Projects\C#\Advent of code\Day 6\Part 2\Part 2\bin\Debug\net7.0\input.txt");
        static void Main(string[] args)
        {
            Program program = new Program();
            string timeStr = input[0].Split(':')[1];
            string recordStr = input[1].Split(':')[1];
            string[] times = timeStr.Split(' ');
            string[] records = recordStr.Split(' ');
            var timeList = new List<string>();
            var recordList = new List<string>();
            foreach (var s in times)
            {
                if (!string.IsNullOrEmpty(s))
                    timeList.Add(s);
            }
            foreach (var s in records)
            {
                if (!string.IsNullOrEmpty(s))
                    recordList.Add(s);
            }
            times = timeList.ToArray();
            records = recordList.ToArray();
            string timeStr2 = String.Join("", times);
            string recordStr2 = String.Join ("", records);
            long time = Convert.ToInt64(timeStr2);
            long record = Convert.ToInt64(recordStr2);

            long result = program.calculate(time, record);


            Console.WriteLine(result);
            Console.ReadLine();
        }

        long calculate(long time, long record)
        {
            long intRecord = record;
            long intTime = time;
            long result = 0;

            for (int i = 1; i < intTime; i++)
            {
                long myTime = intTime - i;
                if (myTime * i > intRecord)
                {
                    result += 1;
                }
            }
            return result;
        }
    }
}