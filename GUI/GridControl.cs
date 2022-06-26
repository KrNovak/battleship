using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GridControl : UserControl
    {
        public event EventHandler ButtonClick;

        private readonly GridButton[,] buttons = new GridButton[Rows,Columns];
        private readonly Label[] verticalLabels = new Label[Rows];
        private readonly Label[] horizontalLabels = new Label[Columns];

        private const int Rows = 10;
        private const int Columns = 10;


        public GridControl()
        {
            AddButtons();
            AddLabels();
            InitializeComponent();
        }
        public void SetButtonColor(int row, int column, Color color)
        {
            buttons[row, column].BackColor = color;
        }
        public void SetButtonColorEvidence(int row, int column, Color color)
        {
            buttons[row, column].BackColor = color;
            buttons[row,column].UseVisualStyleBackColor = true;
        }
        public void ResetButtonColor()
        {
            foreach(var button in buttons)
            {
                button.BackColor = default(Color);
                button.UseVisualStyleBackColor = true;
            }
        }
        public void AnimateColor(int row, int column, Color color)
        {
            buttons[row, column].AnimateButtonColor(color);
        }

        private void AddLabels()
        {
            for(int r = 0; r < Rows; ++r)
            {
                Label l = new Label { Text = (r + 1).ToString(), TextAlign = ContentAlignment.MiddleCenter };
                verticalLabels[r] = l;
                Controls.Add(l);
            }
            for (int c = 0; c < Columns; ++c)
            {
                Label l = new Label { Text = ((char)(c + 'A')).ToString(), TextAlign = ContentAlignment.MiddleCenter };
                horizontalLabels[c] = l;
                Controls.Add(l);
            }
        }

        private void AddButtons()
        {
            for (int r = 0; r < Rows; ++r)
            {
                for (int c = 0; c < Columns; ++c)
                {
                    var button = new GridButton(r, c);
                    button.Click += Button_Click;
                    buttons[r, c] = button;
                    Controls.Add(button);
                }
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResizeButtons();
        }
        private void ResizeButtons()
        {
            int buttonWidth = Width / (Columns + 1);
            int buttonHeight = Height / (Rows + 1);
            int top = buttonHeight; 
            for(int r = 0; r < Rows; ++r)
            {
                int left = buttonWidth;
                for(int c = 0; c < Columns; ++c)
                {
                    var button = buttons[r, c];
                    button.Left = left;
                    button.Top = top;
                    button.Width = buttonWidth;
                    button.Height = buttonHeight;
                    left += buttonWidth;
                }
                top += buttonHeight;
            }
            PlaceLabels(buttonWidth, buttonHeight);
        }

        private void PlaceLabels(int buttonWidth, int buttonHeight)
        {
            int x = buttonWidth;
            int y = 0;
            for(int c = 0; c < Columns; ++c)
            {
                horizontalLabels[c].Width = buttonWidth;
                horizontalLabels[c].Height = buttonHeight;
                horizontalLabels[c].Left = x;
                horizontalLabels[c].Top = y;
                x += buttonWidth;
            }
            x = 0;
            y = buttonHeight;
            for(int r = 0; r < Rows; ++r)
            {
                verticalLabels[r].Width = buttonWidth;
                verticalLabels[r].Height = buttonHeight;
                verticalLabels[r].Left = x;
                verticalLabels[r].Top = y;
                y += buttonHeight;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(sender, e);
        }
    }
}
