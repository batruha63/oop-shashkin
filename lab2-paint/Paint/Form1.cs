using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Drawing.Imaging;

namespace Paint
{
    public partial class Form1 : Form
    {
        private Drawing _drawing = new Drawing();

        private CommandManager _commandManager = new CommandManager();

        private Shape _currentShape;

        private string _currentTool = "LineShape";

        private Color _currentColor = Color.Black;

        private Point _lastMousePosition;

        private Point _moveStartPosition;

        private Shape _movingShape;

        private bool _isMoving = false;

        public Form1()
        {
            InitializeComponent();

            SelectTool("LineShape", btnLine);

            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;

            panelCanvas.Paint += panelCanvas_Paint;
            panelCanvas.MouseDown += panelCanvas_MouseDown;
            panelCanvas.MouseMove += panelCanvas_MouseMove;
            panelCanvas.MouseUp += panelCanvas_MouseUp;
        }

        private void SelectTool(string tool, Button selectedButton)
        {
            _currentTool = tool;

            btnLine.BackColor = SystemColors.Control;
            btnRectangle.BackColor = SystemColors.Control;
            btnEllipse.BackColor = SystemColors.Control;
            btnPencil.BackColor = SystemColors.Control;

            selectedButton.BackColor = Color.LightBlue;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Z)
            {
                _commandManager.Undo();
                panelCanvas.Invalidate();
            }

            if (e.Control && e.KeyCode == Keys.Y)
            {
                _commandManager.Redo();
                panelCanvas.Invalidate();
            }

            if (e.KeyCode == Keys.Delete)
            {
                if (_drawing.SelectedShape != null)
                {
                    Shape selectedShape = _drawing.SelectedShape;

                    _commandManager.Execute(
                        new DeleteShapeCommand(_drawing, selectedShape)
                    );

                    _drawing.Select(Point.Empty);

                    panelCanvas.Invalidate();
                }
            }
        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            _drawing.Draw(e.Graphics);

            if (_currentShape != null)
            {
                _currentShape.Draw(e.Graphics);
            }

            if (_drawing.SelectedShape != null)
            {
                Rectangle bounds = _drawing.SelectedShape.GetBounds();
                bounds.Inflate(5, 5);

                using Pen pen = new Pen(Color.Blue, 1);
                pen.DashStyle =
                    System.Drawing.Drawing2D.DashStyle.Dash;

                e.Graphics.DrawRectangle(pen, bounds);
            }
        }

        private void panelCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _drawing.Select(e.Location);

                if (_drawing.SelectedShape != null)
                {
                    _isMoving = true;

                    _lastMousePosition = e.Location;
                    _moveStartPosition = e.Location;

                    _movingShape = _drawing.SelectedShape;
                }
                else
                {
                    _currentShape = ShapeFactory.Create(
                        _currentTool,
                        e.Location,
                        _currentColor,
                        (int)numWidth.Value
                    );
                }

                panelCanvas.Invalidate();
            }
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMoving && _movingShape != null)
            {
                int dx = e.X - _lastMousePosition.X;
                int dy = e.Y - _lastMousePosition.Y;

                _movingShape.MoveBy(new Point(dx, dy));

                _lastMousePosition = e.Location;

                panelCanvas.Invalidate();
            }
            else if (_currentShape != null && e.Button == MouseButtons.Left)
            {
                _currentShape.MoveEnd(e.Location);
                panelCanvas.Invalidate();
            }
        }

        private void panelCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (_currentShape != null)
            {
                _commandManager.Execute(
                    new AddShapeCommand(_drawing, _currentShape)
                );

                _currentShape = null;
            }

            if (_isMoving && _movingShape != null)
            {
                int dx = e.X - _moveStartPosition.X;
                int dy = e.Y - _moveStartPosition.Y;

                if (dx != 0 || dy != 0)
                {
                    _commandManager.AddExecutedCommand(
                        new MoveShapeCommand(
                            _movingShape,
                            new Point(dx, dy)
                        )
                    );
                }
            }

            _isMoving = false;
            _movingShape = null;

            panelCanvas.Invalidate();
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            SelectTool("LineShape", btnLine);
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            SelectTool("RectShape", btnRectangle);
        }

        private void btnEllipse_Click(object sender, EventArgs e)
        {
            SelectTool("EllipseShape", btnEllipse);
        }

        private void btnPencil_Click(object sender, EventArgs e)
        {
            SelectTool("PencilShape", btnPencil);
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            _commandManager.Undo();
            panelCanvas.Invalidate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _commandManager.Execute(
                new ClearDrawingCommand(_drawing)
            );

            panelCanvas.Invalidate();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _currentColor = colorDialog.Color;
                btnColor.BackColor = _currentColor;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "JSON файлы (*.json)|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string json = JsonSerializer.Serialize(
                    _drawing.ToData(),
                    new JsonSerializerOptions { WriteIndented = true }
                );

                File.WriteAllText(dialog.FileName, json);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "JSON файлы (*.json)|*.json";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(dialog.FileName);

                List<ShapeData> data =
                    JsonSerializer.Deserialize<List<ShapeData>>(json);

                if (data != null)
                {
                    _drawing.LoadData(data);
                    panelCanvas.Invalidate();
                }
            }
        }
        private void btnExportPng_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Filter = "PNG изображения (*.png)|*.png";
            dialog.FileName = "drawing.png";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap bitmap = new Bitmap(
                    panelCanvas.Width,
                    panelCanvas.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.Clear(panelCanvas.BackColor);
                        _drawing.Draw(g);
                    }

                    bitmap.Save(dialog.FileName, ImageFormat.Png);
                }

                MessageBox.Show("Изображение сохранено!");
            }
        }
    }
}
