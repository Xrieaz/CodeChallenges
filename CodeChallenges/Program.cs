using CodeChallenges.AreaOfOverlappingRectangles;
using System;

namespace CodeChallenges
{
    public class Program
    {
        private static readonly string[] _challenges = new string[]
        {
            "AreaOfOverlappingRectangles"
        };

        private static void Main(string[] args)
        {
            AreaOfOverlappingRectsTester.RunTest();

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
