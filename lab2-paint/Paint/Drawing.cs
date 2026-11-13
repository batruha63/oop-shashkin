using System.Collections.Generic;
using System.Drawing;

namespace Paint
{
    public class Drawing
    {
        private List<Shape> _shapes = new();

        public Shape SelectedShape { get; private set; }

        public void Add(Shape shape)
        {
            _shapes.Add(shape);
        }

        public void Remove(Shape shape)
        {
            _shapes.Remove(shape);

            if (SelectedShape == shape)
            {
                SelectedShape = null;
            }
        }

        public List<Shape> GetShapes()
        {
            return new List<Shape>(_shapes);
        }

        public void Undo()
        {
            if (_shapes.Count > 0)
            {
                _shapes.RemoveAt(_shapes.Count - 1);
                SelectedShape = null;
            }
        }

        public void Clear()
        {
            _shapes.Clear();
            SelectedShape = null;
        }

        public void Draw(Graphics g)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(g);
            }
        }

        public void Select(Point p)
        {
            SelectedShape = null;

            for (int i = _shapes.Count - 1; i >= 0; i--)
            {
                if (_shapes[i].Contains(p))
                {
                    SelectedShape = _shapes[i];
                    break;
                }
            }
        }

        public void DeleteSelected()
        {
            if (SelectedShape != null)
            {
                _shapes.Remove(SelectedShape);
                SelectedShape = null;
            }
        }

        public List<ShapeData> ToData()
        {
            List<ShapeData> dataList = new List<ShapeData>();

            foreach (var shape in _shapes)
            {
                ShapeData data = new ShapeData();

                data.Type = shape.GetType().Name;
                data.Start = shape.Start;
                data.End = shape.End;
                data.ColorArgb = shape.Color.ToArgb();
                data.Width = shape.Width;

                if (shape is PencilShape pencil)
                {
                    data.Points.AddRange(pencil.Points);
                }

                dataList.Add(data);
            }

            return dataList;
        }

        public void LoadData(List<ShapeData> dataList)
        {
            _shapes.Clear();
            SelectedShape = null;

            foreach (var data in dataList)
            {
                Shape shape = ShapeFactory.Create(
                    data.Type,
                    data.Start,
                    Color.FromArgb(data.ColorArgb),
                    data.Width
                );

                if (shape is PencilShape pencil)
                {
                    for (int i = 1; i < data.Points.Count; i++)
                    {
                        pencil.MoveEnd(data.Points[i]);
                    }
                }
                else
                {
                    shape.MoveEnd(data.End);
                }

                _shapes.Add(shape);
            }
        }
    }
}
