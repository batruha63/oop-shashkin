using System.Drawing;

namespace Paint
{
    public abstract class Shape
    {
        public Point Start { get; protected set; }
        public Point End { get; protected set; }
        public Color Color { get; }
        public int Width { get; }

        protected Shape(Point start, Color color, int width)
        {
            Start = End = start;
            Color = color;
            Width = width;
        }

        public virtual void MoveEnd(Point p) => End = p;

        public virtual void MoveBy(Point offset)
        {
            Start = new Point(Start.X + offset.X, Start.Y + offset.Y);
            End = new Point(End.X + offset.X, End.Y + offset.Y);
        }

        protected Rectangle Bounds() => new(
            Math.Min(Start.X, End.X), Math.Min(Start.Y, End.Y),
            Math.Abs(End.X - Start.X), Math.Abs(End.Y - Start.Y));

        public Rectangle GetBounds()
        {
            return Bounds();
        }

        public abstract void Draw(Graphics g);

        public virtual bool Contains(Point p)
        {
            Rectangle bounds = Bounds();

            bounds.Inflate(5, 5);

            return bounds.Contains(p);
        }
    }
}
