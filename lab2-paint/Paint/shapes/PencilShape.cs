
using System.Drawing;
using System.Collections.Generic;

namespace Paint
{
    public class PencilShape : Shape
    {
        private readonly List<Point> _points = new();

        public List<Point> Points => _points;

        public PencilShape(Point start, Color color, int width)
            : base(start, color, width)
        {
            _points.Add(start);
        }

        public override void MoveEnd(Point p)
        {
            base.MoveEnd(p);
            _points.Add(p);
        }

        public override void MoveBy(Point offset)
        {
            base.MoveBy(offset);

            for (int i = 0; i < _points.Count; i++)
            {
                _points[i] = new Point(
                    _points[i].X + offset.X,
                    _points[i].Y + offset.Y
                );
            }
        }

        public override void Draw(Graphics g)
        {
            if (_points.Count < 2) return;

            using var pen = new Pen(Color, Width);
            g.DrawLines(pen, _points.ToArray());
        }
    }
}
