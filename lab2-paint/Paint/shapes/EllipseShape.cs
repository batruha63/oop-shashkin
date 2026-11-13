using System.Drawing;

namespace Paint
{
    public class EllipseShape : Shape
    {
        public EllipseShape(Point start, Color color, int width)
            : base(start, color, width)
        {
        }

        public override void Draw(Graphics g)
        {
            using (Pen pen = new Pen(Color, Width))
            {
                g.DrawEllipse(pen, Bounds());
            }
        }
    }
}
