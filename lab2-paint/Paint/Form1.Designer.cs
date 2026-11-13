namespace Paint
{
    partial class Form1
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
            btnLine = new Button();
            btnEllipse = new Button();
            btnRectangle = new Button();
            btnPencil = new Button();
            btnUndo = new Button();
            btnClear = new Button();
            btnColor = new Button();
            numWidth = new NumericUpDown();
            panelCanvas = new Panel();
            btnSave = new Button();
            btnOpen = new Button();
            btnExportPng = new Button();
            ((System.ComponentModel.ISupportInitialize)numWidth).BeginInit();
            SuspendLayout();
            // 
            // btnLine
            // 
            btnLine.Location = new Point(12, 12);
            btnLine.Name = "btnLine";
            btnLine.Size = new Size(97, 34);
            btnLine.TabIndex = 0;
            btnLine.Text = "Линия";
            btnLine.UseVisualStyleBackColor = true;
            btnLine.Click += btnLine_Click;
            // 
            // btnEllipse
            // 
            btnEllipse.Location = new Point(273, 12);
            btnEllipse.Name = "btnEllipse";
            btnEllipse.Size = new Size(86, 34);
            btnEllipse.TabIndex = 1;
            btnEllipse.Text = "Эллипс";
            btnEllipse.UseVisualStyleBackColor = true;
            btnEllipse.Click += btnEllipse_Click;
            // 
            // btnRectangle
            // 
            btnRectangle.Location = new Point(115, 12);
            btnRectangle.Name = "btnRectangle";
            btnRectangle.Size = new Size(152, 34);
            btnRectangle.TabIndex = 2;
            btnRectangle.Text = "Прямоугольник";
            btnRectangle.UseVisualStyleBackColor = true;
            btnRectangle.Click += btnRectangle_Click;
            // 
            // btnPencil
            // 
            btnPencil.Location = new Point(365, 12);
            btnPencil.Name = "btnPencil";
            btnPencil.Size = new Size(106, 34);
            btnPencil.TabIndex = 3;
            btnPencil.Text = "Карандаш";
            btnPencil.UseVisualStyleBackColor = true;
            btnPencil.Click += btnPencil_Click;
            // 
            // btnUndo
            // 
            btnUndo.Location = new Point(12, 52);
            btnUndo.Name = "btnUndo";
            btnUndo.Size = new Size(102, 34);
            btnUndo.TabIndex = 4;
            btnUndo.Text = "Отменить";
            btnUndo.UseVisualStyleBackColor = true;
            btnUndo.Click += btnUndo_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(120, 52);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(98, 34);
            btnClear.TabIndex = 5;
            btnClear.Text = "Очистить";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnColor
            // 
            btnColor.Location = new Point(477, 12);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(112, 34);
            btnColor.TabIndex = 6;
            btnColor.Text = "Цвет";
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // numWidth
            // 
            numWidth.Location = new Point(595, 15);
            numWidth.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            numWidth.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numWidth.Name = "numWidth";
            numWidth.Size = new Size(180, 31);
            numWidth.TabIndex = 7;
            numWidth.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // panelCanvas
            // 
            panelCanvas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCanvas.BorderStyle = BorderStyle.FixedSingle;
            panelCanvas.Location = new Point(12, 92);
            panelCanvas.Name = "panelCanvas";
            panelCanvas.Size = new Size(761, 356);
            panelCanvas.TabIndex = 8;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(545, 52);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(112, 34);
            btnSave.TabIndex = 9;
            btnSave.Text = "Сохранить";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(663, 52);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(112, 34);
            btnOpen.TabIndex = 10;
            btnOpen.Text = "Открыть";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // btnExportPng
            // 
            btnExportPng.Location = new Point(427, 52);
            btnExportPng.Name = "btnExportPng";
            btnExportPng.Size = new Size(112, 34);
            btnExportPng.TabIndex = 11;
            btnExportPng.Text = "Экспорт";
            btnExportPng.UseVisualStyleBackColor = true;
            btnExportPng.Click += btnExportPng_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 475);
            Controls.Add(btnExportPng);
            Controls.Add(btnOpen);
            Controls.Add(btnSave);
            Controls.Add(panelCanvas);
            Controls.Add(numWidth);
            Controls.Add(btnColor);
            Controls.Add(btnClear);
            Controls.Add(btnUndo);
            Controls.Add(btnPencil);
            Controls.Add(btnRectangle);
            Controls.Add(btnEllipse);
            Controls.Add(btnLine);
            Name = "Form1";
            Text = "Paint";
            ((System.ComponentModel.ISupportInitialize)numWidth).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLine;
        private Button btnEllipse;
        private Button btnRectangle;
        private Button btnPencil;
        private Button btnUndo;
        private Button btnClear;
        private Button btnColor;
        private NumericUpDown numWidth;
        private Panel panelCanvas;
        private Button btnSave;
        private Button btnOpen;
        private Button btnExportPng;
    }
}
