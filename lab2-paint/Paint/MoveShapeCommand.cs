using System.Drawing;

namespace Paint
{
    public class MoveShapeCommand : ICommand
    {
        private Shape _shape;
        private Point _offset;

        public MoveShapeCommand(Shape shape, Point offset)
        {
            _shape = shape;
            _offset = offset;
        }

        public void Execute()
        {
            _shape.MoveBy(_offset);
        }

        public void Undo()
        {
            _shape.MoveBy(new Point(-_offset.X, -_offset.Y));
        }
    }
}
