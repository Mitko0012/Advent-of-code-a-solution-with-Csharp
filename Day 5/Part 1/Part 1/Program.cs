using System;
using System.Linq.Expressions;

namespace Part1 
{ 
    public class Program 
    {

        static string inputString = File.ReadAllText(@"C:\Users\Mitko\Projects\C#\Advent of code\Day 5\Part 1\Part 1\bin\Debug\net7.0\input.txt");
        static string[] input = inputString.Split(new string[] { "\r\n\r\n" },
                              StringSplitOptions.RemoveEmptyEntries);
        public static void Main(string[] args)
        {
           
            string seedsStr = input[0].Substring(input[0].IndexOf(":") + 2);
            string[] seedsArr = seedsStr.Split(" ");
            List<long> locations = new List<long>();
            long[] seeds = Array.ConvertAll(seedsArr, s => long.Parse(s));
            long index = 0;
            foreach (var seed in seeds)
            {

                long final = 0;
                long sum;
                long location = 1;
                sum = convert(seeds[index], location);
                final = sum;
                location++;
                for (long i = 0; i < 6; i++)

                {
                    
                    sum = convert(final, location);
                    final = sum;
                    location++;
                }
                locations.Add(sum);
                index++;
            }

            Console.WriteLine(locations.Min());
            Console.ReadKey();

        }


        static long convert(long seed, long map) 
        {
            long newSeed = seed;
            string conversionMap = input[map];
            string[] conversionGrid = conversionMap.Split(Environment.NewLine);

            foreach (var conversion in conversionGrid)
            {
                long index1 = Array.IndexOf(conversionGrid, conversion);
                if (index1 == 0) { }
                else
                {
                    

                    string[] strIndex = conversion.Split(" ");
                    long[] data = Array.ConvertAll(strIndex, s => long.Parse(s));
                    long data2;
                    if (data[2] == 0) { data2 = 1;}
                    else { data2 = data[2];}
            
                   
                        if (seed >= data[1] && seed < data[1] + data2)
                        {
                            newSeed = seed + data[0] - data[1];
                        }
                   
                    
                    
                }
            }
            return newSeed;
        }
            
          

       }
   
    }

