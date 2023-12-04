using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
namespace Day3Part1 
{
     public class Program
     {
     
   static string[] input = File.ReadAllLines(@"C:\Users\Mitko\Projects\C#\Advent of code\Day 4\Part 1\input.txt");
   static List<int> points = new List<int>();       
         static public void Main(string[] args)
        {
            Program prog = new Program();
             int curr = 0;
             foreach(string s in input)
             {
               string values = input[curr];
               
               points.Add(prog.Parse(values));
              

                curr++;
             }
               
            Console.WriteLine(points.Sum());
            Console.ReadLine();
        }
    
      int Parse(string value)
      {
        string workingValues = value.Substring(value.LastIndexOf(":") + 1);
        string winningValuesVar = workingValues.Substring(1, workingValues.IndexOf("|") - 1);
        string myValuesVar = workingValues.Substring(workingValues.LastIndexOf("|") + 1);
        string[] winningValues = winningValuesVar.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string[] myValues = myValuesVar.Split(" ", StringSplitOptions.RemoveEmptyEntries);
       
        int[] wValues = Array.ConvertAll(winningValues, int.Parse);
        int[] mValues = Array.ConvertAll(myValues, int.Parse);
        int points = 0;
        int currentItem = 0;

        foreach(int i in mValues)
        {
          
          
           int match = mValues[currentItem];
           if(wValues.Contains(match))

           {
            if(points == 0)
            {
               points = 1;
            }
            else
            {
              points = points * 2;
            }
                  
           }

           currentItem++;
        }  
         return points;
      }    



     }


}
