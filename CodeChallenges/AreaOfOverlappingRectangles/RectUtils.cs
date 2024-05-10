using JetBrains.Annotations;
using System;

namespace CodeChallenges.AreaOfOverlappingRectangles
{
    public static class RectUtils
    {
        [CanBeNull]
        public static Rectangle TryGetOverlappingRect(Rectangle rect1, Rectangle rect2)
        {
            Rectangle overlappingRect = new Rectangle
            {
                x = Math.Max(rect1.x, rect2.x),
                y = Math.Max(rect1.y, rect2.y),
            };

            int upperRightCornerX = Math.Min(rect1.x + rect1.Width, rect2.x + rect2.Width);
            int upperRightCornerY = Math.Min(rect1.y + rect1.Height, rect2.y + rect2.Height);

            overlappingRect.Width = upperRightCornerX - overlappingRect.x;
            overlappingRect.Height = upperRightCornerY - overlappingRect.y;

            // If the new width or height is zero or less, it means that the rectangles don't overlapp.
            if(overlappingRect.Width <= 0 || overlappingRect.Height <= 0)
            {
                return null;
            }

            return overlappingRect;
        }

        public static int GetAreaFromOverlappingRects(Rectangle rect1, Rectangle rect2)
        {
            Rectangle overlappingRect = TryGetOverlappingRect(rect1, rect2);
            if(overlappingRect == null)
            {
                return 0;
            }
            return overlappingRect.GetArea();
        }
    }
}
