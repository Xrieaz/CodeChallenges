using System;

namespace CodeChallenges.MiserableParodyCalculator
{
    /// <summary>
    /// This is my solution to the Miserable Parody of a Calculator test found on edabit.
    /// https://edabit.com/challenge/u2j86CBJibQA5KzQp
    /// </summary>
    public class MiserableParodyCalculatorTester
    {
        private static readonly string[] _inputs = new string[]
        {
            "23+4",
            "45-15",
            "13+2-5*2",
            "49/7*2-3",
            "4?4",
            "1234",
            "2**2",
            "2-"
        };

        public static void RunTest(Action onComplete)
        {
            Console.Clear();
            Console.WriteLine("Testing inputs on the MiserableParodyCalculator.");

            var calculator = new MiserableParodyCalculator();
            foreach (var input in _inputs)
            {
                Console.WriteLine();
                Console.WriteLine($"Input: {input}");
                if (calculator.TryToCalculate(input, out double result))
                {
                    Console.WriteLine($"Result: {result}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            onComplete?.Invoke();
        }
    }

}
