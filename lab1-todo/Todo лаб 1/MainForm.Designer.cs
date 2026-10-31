namespace TodoApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTaskTitle = new TextBox();
            dtpDueDate = new DateTimePicker();
            btnAddTask = new Button();
            rbFilterAll = new RadioButton();
            rbFilterActive = new RadioButton();
            rbFilterCompleted = new RadioButton();
            txtSearch = new TextBox();
            lstTasks = new ListBox();
            btnToggleStatus = new Button();
            btnRenameTask = new Button();
            btnDeleteTask = new Button();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtTaskTitle
            // 
            txtTaskTitle.Location = new Point(12, 17);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.PlaceholderText = "Название задачи...";
            txtTaskTitle.Size = new Size(352, 31);
            txtTaskTitle.TabIndex = 0;
            txtTaskTitle.TextChanged += Filter_Changed;
            // 
            // dtpDueDate
            // 
            dtpDueDate.Location = new Point(370, 15);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(300, 31);
            dtpDueDate.TabIndex = 1;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(676, 12);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(112, 34);
            btnAddTask.TabIndex = 2;
            btnAddTask.Text = "Добавить";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // rbFilterAll
            // 
            rbFilterAll.AutoSize = true;
            rbFilterAll.Location = new Point(60, 66);
            rbFilterAll.Name = "rbFilterAll";
            rbFilterAll.Size = new Size(64, 29);
            rbFilterAll.TabIndex = 3;
            rbFilterAll.Text = "Все";
            rbFilterAll.UseVisualStyleBackColor = true;
            rbFilterAll.CheckedChanged += Filter_Changed;
            // 
            // rbFilterActive
            // 
            rbFilterActive.AutoSize = true;
            rbFilterActive.Location = new Point(130, 66);
            rbFilterActive.Name = "rbFilterActive";
            rbFilterActive.Size = new Size(122, 29);
            rbFilterActive.TabIndex = 4;
            rbFilterActive.Text = " Активные";
            rbFilterActive.UseVisualStyleBackColor = true;
            rbFilterActive.CheckedChanged += Filter_Changed;
            // 
            // rbFilterCompleted
            // 
            rbFilterCompleted.AutoSize = true;
            rbFilterCompleted.Location = new Point(258, 66);
            rbFilterCompleted.Name = "rbFilterCompleted";
            rbFilterCompleted.Size = new Size(151, 29);
            rbFilterCompleted.TabIndex = 5;
            rbFilterCompleted.Text = "Выполненные";
            rbFilterCompleted.UseVisualStyleBackColor = true;
            rbFilterCompleted.CheckedChanged += Filter_Changed;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(552, 66);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Поиск задачи...";
            txtSearch.Size = new Size(150, 31);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += Filter_Changed;
            // 
            // lstTasks
            // 
            lstTasks.FormattingEnabled = true;
            lstTasks.ItemHeight = 25;
            lstTasks.Location = new Point(60, 122);
            lstTasks.Name = "lstTasks";
            lstTasks.Size = new Size(642, 129);
            lstTasks.TabIndex = 7;
            // 
            // btnToggleStatus
            // 
            btnToggleStatus.Location = new Point(60, 365);
            btnToggleStatus.Name = "btnToggleStatus";
            btnToggleStatus.Size = new Size(134, 34);
            btnToggleStatus.TabIndex = 8;
            btnToggleStatus.Text = "Выполнено";
            btnToggleStatus.UseVisualStyleBackColor = true;
            btnToggleStatus.Click += btnToggleStatus_Click;
            // 
            // btnRenameTask
            // 
            btnRenameTask.Location = new Point(218, 365);
            btnRenameTask.Name = "btnRenameTask";
            btnRenameTask.Size = new Size(158, 34);
            btnRenameTask.TabIndex = 9;
            btnRenameTask.Text = "Переименовать";
            btnRenameTask.UseVisualStyleBackColor = true;
            btnRenameTask.Click += btnRenameTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Location = new Point(403, 365);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(112, 34);
            btnDeleteTask.TabIndex = 10;
            btnDeleteTask.Text = "Удалить";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
            statusStrip1.Location = new Point(0, 418);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 32);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(73, 25);
            lblStatus.Text = "0 задач";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(btnDeleteTask);
            Controls.Add(btnRenameTask);
            Controls.Add(btnToggleStatus);
            Controls.Add(lstTasks);
            Controls.Add(txtSearch);
            Controls.Add(rbFilterCompleted);
            Controls.Add(rbFilterActive);
            Controls.Add(rbFilterAll);
            Controls.Add(btnAddTask);
            Controls.Add(dtpDueDate);
            Controls.Add(txtTaskTitle);
            Name = "MainForm";
            Text = "Todo App";
            Load += MainForm_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTaskTitle;
        private DateTimePicker dtpDueDate;
        private Button btnAddTask;
        private RadioButton rbFilterAll;
        private RadioButton rbFilterActive;
        private RadioButton rbFilterCompleted;
        private TextBox txtSearch;
        private ListBox lstTasks;
        private Button btnToggleStatus;
        private Button btnRenameTask;
        private Button btnDeleteTask;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}
