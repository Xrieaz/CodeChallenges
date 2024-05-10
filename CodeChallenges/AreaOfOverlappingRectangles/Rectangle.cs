namespace CodeChallenges.AreaOfOverlappingRectangles
{
    public class Rectangle
    {
        public int x { get; set; }
        public int y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle()
        {
        }

        public Rectangle(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            Width = width;
            Height = height;
        }

        public int GetArea()
        {
            return Width * Height;
        }
    }
}
