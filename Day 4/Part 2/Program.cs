﻿using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.ComponentModel;
namespace Day3Part1 
{
     public class Program
     {
     
   static string[] input = File.ReadAllLines(@"C:\Users\Mitko\Projects\C#\Advent of code\Day 4\Part 2\input.txt");
   static List<int> scratchcards = new List<int>();       
         static public void Main(string[] args)
        {
            int num = 1;
            foreach(string s in input)
            {
                scratchcards.Add(num);
                
              num++;
            }          
            Program prog = new Program();
             int curr = 0;
             int add;
             for(int i = 0; i > -1; i++)
             {
              try{
              int inputPos = scratchcards[i] - 1;
               add = inputPos + 1;
                for(int ie = 0; ie < prog.Parse(input[inputPos]); ie++)
                {
                   add++;
                   scratchcards.Add(add);
                  

                }
              }

              catch
              {
               break;
              }

             
             }
               
            Console.WriteLine(scratchcards.Count);
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
           points++;
                  
           }

           currentItem++;
        }  
         return points;
      }    



     }


}
