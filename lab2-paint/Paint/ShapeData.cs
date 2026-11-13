using System.Collections.Generic;
using System.Drawing;

namespace Paint
{
    public class ShapeData
    {
        public string Type { get; set; }

        public Point Start { get; set; }

        public Point End { get; set; }

        public int ColorArgb { get; set; }

        public int Width { get; set; }

        public List<Point> Points { get; set; } = new List<Point>();
    }
}
