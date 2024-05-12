using CodeChallenges.AreaOfOverlappingRectangles;
using CodeChallenges.MiserableParodyCalculator;
using System;

namespace CodeChallenges
{
    public class Program
    {
        private static readonly string[] _challenges = new string[]
        {
            "AreaOfOverlappingRectangles",
            "MiserableParodyCalculator"
        };

        private static void Main(string[] args)
        {
            ShowMenu();
        }

        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Available code challenges: ");
            Console.WriteLine();

            for (int i = 0; i < _challenges.Length; i++)
            {
                string challenge = _challenges[i];
                Console.WriteLine($"{i+1}. {challenge}");
            }

            Console.WriteLine();
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                AreaOfOverlappingRectanglesTester.RunTest(OnTestComplete);
            }
            else if (key.Key == ConsoleKey.D2)
            {
                MiserableParodyCalculatorTester.RunTest(OnTestComplete);
            }

            return;

            void OnTestComplete()
            {
                ShowMenu();
            }
        }
    }
}
