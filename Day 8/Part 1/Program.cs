using System;

namespace Part2
{
    class Program
    {
        static string[] input = File.ReadAllLines(@"C:\Users\Mitko\Projects\C#\Advent of code\Day 8\Part 1\bin\Debug\net7.0\input.txt");
        static void Main(string[] args)
        {
            Program solution = new Program();
            char[] instructions = input[0].ToCharArray();
            int i = 0;
            int currentLine = solution.calculateStartPositon();
            int steps = 0;
            bool zNotFound = true;  

            while(zNotFound == true)
            {
                int direction = 0;
                if(i == instructions.Length)
                {
                    i = 0;
                }
                switch(instructions[i])
                {
                    case 'L':
                    direction = 0;
                    break;

                    case 'R':
                    direction = 1;
                    break;
                }
                
                currentLine = solution.calculatePath(currentLine, direction);
                i++;
                steps++;
                if(currentLine == -1)
                {
                    zNotFound = false;
                }

            }
            Console.WriteLine(steps);
            Console.ReadLine();
        }

        int calculatePath(int arrayNum, int direction)
        {
            string leftPath = input[arrayNum].Substring(input[arrayNum].IndexOf("(") + 1, 3);
            string rightPath = input[arrayNum].Substring(input[arrayNum].IndexOf(",") + 2, 3);
            string searchingFor = "e";
            
            switch(direction)
            {
                case 0:
                searchingFor = leftPath;
                break;

                case 1:
                searchingFor = rightPath;
                break;
            }

            foreach(string s in input)
            {
                try
                {                
                  if (s.Substring(0, 3) == searchingFor)
                  {
                      if(s.Substring(0, 3) == "ZZZ")
                      {
                          return -1;
                      }
                      return Array.IndexOf(input, s);
                                   
                  }
                }
               catch
               {
                  continue;  
               }
            }
            
            return 2;
        }

        int calculateStartPositon()
        {
            foreach(string s in input)
            {
                try
                {                
                  if (s.Substring(0, 3) == "AAA")
                  {
                      
                      return Array.IndexOf(input, s);
                                   
                  }
                }
               catch
               {
                  continue;  
               }
            }
            
            return 2;
        }
    }
}
