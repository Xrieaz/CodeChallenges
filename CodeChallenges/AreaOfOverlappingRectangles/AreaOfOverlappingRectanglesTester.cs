using System;

namespace CodeChallenges.AreaOfOverlappingRectangles
{
    /// <summary>
    /// This is my solution to the Area of Overlapping Rectangles test found on edabit.
    /// https://edabit.com/challenge/Jj6S7qQgtfAo4L2QR
    /// </summary>
    public class AreaOfOverlappingRectanglesTester
    {
        public static void RunTest(Action onComplete)
        {
            Console.Clear();
            Console.WriteLine("Running tests on RectUtils.GetAreaFromOverlappingRects().");
            Console.WriteLine();

            Console.WriteLine("Example 1 Rectangle1(2, 1, 3, 4), Rectangle2(3, 2, 2, 5): " + RectUtils.GetAreaFromOverlappingRects(new Rectangle(2, 1, 3, 4), new Rectangle(3, 2, 2, 5)));
            Console.WriteLine("Example 2 Rectangle1(2, -9, 11, 5), Rectangle2(5, -11, 2, 9): " + RectUtils.GetAreaFromOverlappingRects(new Rectangle(2, -9, 11, 5), new Rectangle(5, -11, 2, 9)));
            Console.WriteLine("Example 3 Rectangle1(-8, -7, 4, 7), Rectangle2(-5, -9, 4, 7): " + RectUtils.GetAreaFromOverlappingRects(new Rectangle(-8, -7, 4, 7), new Rectangle(-5, -9, 4, 7)));
            Console.WriteLine("Example 4 Rectangle1(2, 1, 3, 4), Rectangle2(6, 2, 3, 4): " + RectUtils.GetAreaFromOverlappingRects(new Rectangle(2, 1, 3, 4), new Rectangle(6, 2, 3, 4)));

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            onComplete?.Invoke();
        }
    }
}
