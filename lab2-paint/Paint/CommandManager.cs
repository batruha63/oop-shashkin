
using System.Collections.Generic;

namespace Paint
{
    public class CommandManager
    {
        private Stack<ICommand> _undoStack = new();
        private Stack<ICommand> _redoStack = new();

        public void Execute(ICommand command)
        {
            command.Execute();

            _undoStack.Push(command);

            _redoStack.Clear();
        }

        public void AddExecutedCommand(ICommand command)
        {
            _undoStack.Push(command);

            _redoStack.Clear();
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                ICommand command = _undoStack.Pop();

                command.Undo();

                _redoStack.Push(command);
            }
        }

        public void Redo()
        {
            if (_redoStack.Count > 0)
            {
                ICommand command = _redoStack.Pop();

                command.Execute();

                _undoStack.Push(command);
            }
        }
    }
}
