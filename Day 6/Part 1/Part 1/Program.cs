using System;
using static System.Net.Mime.MediaTypeNames;

namespace Part1
{
    public class Program
    {
        static string[] input = File.ReadAllLines(@"C:\Users\Mitko\Projects\C#\Advent of code\Day 6\Part 1\Part 1\bin\Debug\net7.0\input.txt");
        static void Main(string[] args)
        {
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

            int result = 0;
            List<int> values = new List<int>();
            Program program = new Program();
            foreach (string record in records ) 
            { 
              int i = Array.IndexOf(records, record);
                values.Add(program.calculate(times[i], records[i]));

            }

            int finalResult = 1;
            for (int i = 0; i < values.Count; i++)
            {
                finalResult = finalResult * values[i]; 
            }


            Console.WriteLine(finalResult);
            Console.ReadLine();
        }

        int calculate(string time, string record)
        {
           int intRecord = Convert.ToInt32(record);
           int intTime = Convert.ToInt32(time);
           int result = 0; 
                      
            for(int i = 1; i < intTime; i++)
            {
               int myTime = intTime - i;
              if(myTime * i > intRecord)
              {
                result += 1;    
              }       
            }   
            Console.WriteLine(result);
           return result;
        }
    }    
}