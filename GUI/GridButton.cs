using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GUI
{
    class GridButton : System.Windows.Forms.Button
    {
        public GridButton(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void AnimateButtonColor(Color color)
        {
            var oldColor = BackColor;
            Task.Run(()=>Animation(color, oldColor));
        }

        private void Animation(Color color, Color oldColor)
        {
            for(int i = 0; i < 4; ++i)
            {
                BackColor = color;
                Thread.Sleep(250);
                BackColor = oldColor;
                Thread.Sleep(250);
            }
            BackColor = color;
        }

        public readonly int Row;
        public readonly int Column;
    }
}
