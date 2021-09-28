
using System;
using System.Collections.Immutable;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\Work\FunctionalProgrammingConsole\FunctionalProgrammingConsole1\ConsoleApp\ConsoleApp\Data.txt");
            
            var linesImmutableList = lines.ToImmutableList();
            
            var wordsData = linesImmutableList[0];
            var places = linesImmutableList.Skip(2).ToImmutableList();

            var crosswordData = new CrosswordData(wordsData, places);

            var crosswordSolutions = CrosswordResolver.GetAllSolutions(crosswordData);
            
            Console.WriteLine("crosswordSolutionCount = " + crosswordSolutions.Count);
            // crosswordSolutions.ForEach(solution => Console.WriteLine(solution.ToString()));

            Console.WriteLine("lol");
        }
    }
}