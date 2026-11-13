namespace Paint
{
    public class DeleteShapeCommand : ICommand
    {
        private Drawing _drawing;
        private Shape _shape;

        public DeleteShapeCommand(Drawing drawing, Shape shape)
        {
            _drawing = drawing;
            _shape = shape;
        }

        public void Execute()
        {
            _drawing.Remove(_shape);
        }

        public void Undo()
        {
            _drawing.Add(_shape);
        }
    }
}
