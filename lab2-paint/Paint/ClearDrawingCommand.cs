using System.Collections.Generic;

namespace Paint
{
    public class ClearDrawingCommand : ICommand
    {
        private Drawing _drawing;
        private List<Shape> _shapes;

        public ClearDrawingCommand(Drawing drawing)
        {
            _drawing = drawing;

            _shapes = drawing.GetShapes();
        }

        public void Execute()
        {
            _drawing.Clear();
        }

        public void Undo()
        {
            foreach (Shape shape in _shapes)
            {
                _drawing.Add(shape);
            }
        }
    }
}