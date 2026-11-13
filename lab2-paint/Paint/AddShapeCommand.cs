namespace Paint
{
    public class AddShapeCommand : ICommand
    {
        private Drawing _drawing;
        private Shape _shape;

        public AddShapeCommand(Drawing drawing, Shape shape)
        {
            _drawing = drawing;
            _shape = shape;
        }

        public void Execute()
        {
            _drawing.Add(_shape);
        }

        public void Undo()
        {
            _drawing.Remove(_shape);
        }
    }
}