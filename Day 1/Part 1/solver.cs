using System;
using System.Linq;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.IO;

namespace AdventOfCodeDay01
{
   class Program{


static string[] input = File.ReadAllLines("input.txt");
static int selectedLine = 0;

static List<int> CalibrationValues = new List<int>();          
public static void Main(string[] args)

{
  for(int i = 0; i < input.Length; i++)
  {
     selectedLine = i;
    Console.WriteLine(solve());
    CalibrationValues.Add(solve());
      
         


  }
  
 int solution = CalibrationValues.Sum(); 
Console.WriteLine(solution);
Console.ReadLine();

}

public static int solve()
{
string workingString = input[selectedLine];
Regex regex = new Regex(@"\d", RegexOptions.IgnoreCase);
Regex regex2 = new Regex(@"\d", RegexOptions.RightToLeft);
Match match = regex.Match(workingString);
Match match2 = regex2.Match(workingString);
string first = match.Value;
string last = match2.Value;
return(parseMatch(first) * 10 + parseMatch(last));


}

static int parseMatch(string st) => st switch{

"one" => 1,
        "two" => 2,
        "three" => 3,
        "four" => 4,
        "five" => 5,
        "six" => 6,
        "seven" => 7,
        "eight" => 8,
        "nine" => 9,
        var d => int.Parse(d)
};

   }



}