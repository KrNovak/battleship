using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

using Vsite.Oom.Battleship.Model;

namespace GUI
{
    class EvidenceGridControl : GridControl
    {
        public void PlaceFleet(Fleet fleet)
        {
            ResetButtonColor();
            foreach(Ship ship in fleet.Ships)
            {
                foreach(Square square in ship.Squares)
                {
                    SetButtonColorEvidence(square.Row, square.Column, shipColor);
                }
            }
        }
        static readonly Color shipColor = default(Color);

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // EvidenceGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "EvidenceGridControl";
            this.Size = new System.Drawing.Size(422, 389);
            this.ResumeLayout(false);

        }
    }
}
