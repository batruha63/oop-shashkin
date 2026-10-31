using System;
using System.Drawing;
using System.Windows.Forms;

namespace TodoApp
{
    public partial class MainForm : Form
    {
        private readonly TodoList _todoList;

        public MainForm()
        {
            InitializeComponent();
            _todoList = new TodoList();

            lstTasks.DrawMode = DrawMode.OwnerDrawFixed;
            lstTasks.DrawItem += LstTasks_DrawItem;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _todoList.LoadFromFile();
                UpdateStatusBar();
                RefreshTaskList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshTaskList()
        {
            lstTasks.Items.Clear();

            string currentFilter = "Все";
            if (rbFilterActive.Checked) currentFilter = "Активные";
            if (rbFilterCompleted.Checked) currentFilter = "Выполненные";

            var items = _todoList.GetFilteredAndSortedItems(currentFilter, txtSearch.Text);

            foreach (var item in items)
            {
                lstTasks.Items.Add(item);
            }
        }

        private void UpdateStatusBar()
        {
            int total = _todoList.Items.Count;
            int completed = 0;
            foreach (var item in _todoList.Items)
            {
                if (item.IsDone) completed++;
            }
            lblStatus.Text = $"{total} задач, выполнено {completed} • сохранено в tasks.json";
        }

        private void SaveAndRefresh()
        {
            _todoList.SaveToFile();
            UpdateStatusBar();
            RefreshTaskList();
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            try
            {
                _todoList.AddItem(txtTaskTitle.Text, dtpDueDate.Value.Date);
                txtTaskTitle.Clear();
                SaveAndRefresh();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnToggleStatus_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem is TodoItem selectedItem)
            {
                selectedItem.ToggleDone();
                SaveAndRefresh();
            }
        }

        private void btnRenameTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem is TodoItem selectedItem)
            {
                string newTitle = Microsoft.VisualBasic.Interaction.InputBox(
                    "Введите новое название задачи:", "Переименование", selectedItem.Title);

                try
                {
                    selectedItem.Rename(newTitle);
                    SaveAndRefresh();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItem is TodoItem selectedItem)
            {
                var result = MessageBox.Show($"Удалить задачу \"{selectedItem.Title}\"?",
                    "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _todoList.RemoveItem(selectedItem.Id);
                    SaveAndRefresh();
                }
            }
        }

        private void Filter_Changed(object sender, EventArgs e)
        {
            RefreshTaskList();
        }

        private void LstTasks_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            TodoItem item = (TodoItem)lstTasks.Items[e.Index];
            Graphics g = e.Graphics;

            Font font = e.Font;
            Brush textBrush = Brushes.Black;

            if (item.IsDone)
            {
                font = new Font(e.Font, FontStyle.Strikeout);
                textBrush = Brushes.Gray;
            }
            else if (item.DueDate.HasValue && item.DueDate.Value < DateTime.Today)
            {
                textBrush = Brushes.Red;
            }

            string dateStr = item.DueDate.HasValue ? item.DueDate.Value.ToString("dd.MM.yyyy") : "—";
            string fullText = $"{item.Title} (Срок: {dateStr})";

            g.DrawString(fullText, font, textBrush, e.Bounds);
            e.DrawFocusRectangle();
        }
    }
}
