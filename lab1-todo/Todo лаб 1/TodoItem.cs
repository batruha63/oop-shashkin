using System;

namespace TodoApp
{
    public class TodoItem
    {
        private string _title = "";
        private bool _done;
        private DateTime? _dueDate;

        public Guid Id { get; private set; }

        public TodoItem(string title, DateTime? dueDate = null)
        {
            Id = Guid.NewGuid();
            Rename(title);
            _done = false;
            _dueDate = dueDate;
        }

        public string Title => _title;
        public bool IsDone => _done;
        public DateTime? DueDate => _dueDate;

        public void ToggleDone()
        {
            _done = !_done;
        }

        public void Rename(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Название не может быть пустым");

            _title = title.Trim();
        }

        public void ChangeDueDate(DateTime? newDueDate)
        {
            _dueDate = newDueDate;
        }
    }
}
