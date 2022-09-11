namespace GUI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlaceFleetButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.MyFleetLabel = new System.Windows.Forms.Label();
            this.EvidenceLabel = new System.Windows.Forms.Label();
            this.enemyLastTargetLabel = new System.Windows.Forms.Label();
            this.myShipsLabel = new System.Windows.Forms.Label();
            this.mySquaresLabel = new System.Windows.Forms.Label();
            this.myLastTargetLabel = new System.Windows.Forms.Label();
            this.enemyShipsLabel = new System.Windows.Forms.Label();
            this.enemySquaresLabel = new System.Windows.Forms.Label();
            this.evidenceGridControl1 = new GUI.EvidenceGridControl();
            this.fleetGridControl1 = new GUI.FleetGridControl();
            this.VerifyPlacementButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlaceFleetButton
            // 
            this.PlaceFleetButton.Location = new System.Drawing.Point(400, 524);
            this.PlaceFleetButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PlaceFleetButton.Name = "PlaceFleetButton";
            this.PlaceFleetButton.Size = new System.Drawing.Size(100, 28);
            this.PlaceFleetButton.TabIndex = 2;
            this.PlaceFleetButton.Text = "Place Fleet";
            this.PlaceFleetButton.UseVisualStyleBackColor = true;
            this.PlaceFleetButton.Click += new System.EventHandler(this.PlaceFleetButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(520, 524);
            this.StartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(100, 28);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MyFleetLabel
            // 
            this.MyFleetLabel.AutoSize = true;
            this.MyFleetLabel.Location = new System.Drawing.Point(43, 68);
            this.MyFleetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MyFleetLabel.Name = "MyFleetLabel";
            this.MyFleetLabel.Size = new System.Drawing.Size(58, 16);
            this.MyFleetLabel.TabIndex = 4;
            this.MyFleetLabel.Text = "My Fleet";
            // 
            // EvidenceLabel
            // 
            this.EvidenceLabel.AutoSize = true;
            this.EvidenceLabel.Location = new System.Drawing.Point(516, 68);
            this.EvidenceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EvidenceLabel.Name = "EvidenceLabel";
            this.EvidenceLabel.Size = new System.Drawing.Size(85, 16);
            this.EvidenceLabel.TabIndex = 5;
            this.EvidenceLabel.Text = "My Evidence";
            // 
            // enemyLastTargetLabel
            // 
            this.enemyLastTargetLabel.AutoSize = true;
            this.enemyLastTargetLabel.Location = new System.Drawing.Point(133, 41);
            this.enemyLastTargetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enemyLastTargetLabel.Name = "enemyLastTargetLabel";
            this.enemyLastTargetLabel.Size = new System.Drawing.Size(72, 16);
            this.enemyLastTargetLabel.TabIndex = 6;
            this.enemyLastTargetLabel.Text = "Last target:";
            // 
            // myShipsLabel
            // 
            this.myShipsLabel.AutoSize = true;
            this.myShipsLabel.Location = new System.Drawing.Point(253, 41);
            this.myShipsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.myShipsLabel.Name = "myShipsLabel";
            this.myShipsLabel.Size = new System.Drawing.Size(64, 16);
            this.myShipsLabel.TabIndex = 7;
            this.myShipsLabel.Text = "Ships left:";
            // 
            // mySquaresLabel
            // 
            this.mySquaresLabel.AutoSize = true;
            this.mySquaresLabel.Location = new System.Drawing.Point(373, 41);
            this.mySquaresLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mySquaresLabel.Name = "mySquaresLabel";
            this.mySquaresLabel.Size = new System.Drawing.Size(81, 16);
            this.mySquaresLabel.TabIndex = 8;
            this.mySquaresLabel.Text = "Squares left:";
            // 
            // myLastTargetLabel
            // 
            this.myLastTargetLabel.AutoSize = true;
            this.myLastTargetLabel.Location = new System.Drawing.Point(613, 41);
            this.myLastTargetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.myLastTargetLabel.Name = "myLastTargetLabel";
            this.myLastTargetLabel.Size = new System.Drawing.Size(72, 16);
            this.myLastTargetLabel.TabIndex = 9;
            this.myLastTargetLabel.Text = "Last target:";
            // 
            // enemyShipsLabel
            // 
            this.enemyShipsLabel.AutoSize = true;
            this.enemyShipsLabel.Location = new System.Drawing.Point(733, 41);
            this.enemyShipsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enemyShipsLabel.Name = "enemyShipsLabel";
            this.enemyShipsLabel.Size = new System.Drawing.Size(64, 16);
            this.enemyShipsLabel.TabIndex = 10;
            this.enemyShipsLabel.Text = "Ships left:";
            // 
            // enemySquaresLabel
            // 
            this.enemySquaresLabel.AutoSize = true;
            this.enemySquaresLabel.Location = new System.Drawing.Point(853, 41);
            this.enemySquaresLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.enemySquaresLabel.Name = "enemySquaresLabel";
            this.enemySquaresLabel.Size = new System.Drawing.Size(81, 16);
            this.enemySquaresLabel.TabIndex = 11;
            this.enemySquaresLabel.Text = "Squares left:";
            // 
            // evidenceGridControl1
            // 
            this.evidenceGridControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.evidenceGridControl1.Enabled = false;
            this.evidenceGridControl1.Location = new System.Drawing.Point(520, 74);
            this.evidenceGridControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.evidenceGridControl1.Name = "evidenceGridControl1";
            this.evidenceGridControl1.Size = new System.Drawing.Size(466, 430);
            this.evidenceGridControl1.TabIndex = 13;
            this.evidenceGridControl1.ButtonClick += new System.EventHandler(this.evidenceGridControl1_ButtonClick);
            this.evidenceGridControl1.Load += new System.EventHandler(this.evidenceGridControl1_Load);
            // 
            // fleetGridControl1
            // 
            this.fleetGridControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fleetGridControl1.Enabled = false;
            this.fleetGridControl1.Location = new System.Drawing.Point(47, 74);
            this.fleetGridControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.fleetGridControl1.Name = "fleetGridControl1";
            this.fleetGridControl1.Size = new System.Drawing.Size(466, 430);
            this.fleetGridControl1.TabIndex = 12;
            // 
            // VerifyPlacementButton
            // 
            this.VerifyPlacementButton.Location = new System.Drawing.Point(137, 524);
            this.VerifyPlacementButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.VerifyPlacementButton.Name = "VerifyPlacementButton";
            this.VerifyPlacementButton.Size = new System.Drawing.Size(165, 28);
            this.VerifyPlacementButton.TabIndex = 14;
            this.VerifyPlacementButton.Text = "Verify placement";
            this.VerifyPlacementButton.UseVisualStyleBackColor = true;
            this.VerifyPlacementButton.Click += new System.EventHandler(this.VerifyPlacementButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 567);
            this.Controls.Add(this.VerifyPlacementButton);
            this.Controls.Add(this.EvidenceLabel);
            this.Controls.Add(this.evidenceGridControl1);
            this.Controls.Add(this.MyFleetLabel);
            this.Controls.Add(this.fleetGridControl1);
            this.Controls.Add(this.enemySquaresLabel);
            this.Controls.Add(this.enemyShipsLabel);
            this.Controls.Add(this.myLastTargetLabel);
            this.Controls.Add(this.mySquaresLabel);
            this.Controls.Add(this.myShipsLabel);
            this.Controls.Add(this.enemyLastTargetLabel);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.PlaceFleetButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "Battleship";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button PlaceFleetButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label MyFleetLabel;
        private System.Windows.Forms.Label EvidenceLabel;
        private System.Windows.Forms.Label enemyLastTargetLabel;
        private System.Windows.Forms.Label myShipsLabel;
        private System.Windows.Forms.Label mySquaresLabel;
        private System.Windows.Forms.Label myLastTargetLabel;
        private System.Windows.Forms.Label enemyShipsLabel;
        private System.Windows.Forms.Label enemySquaresLabel;
        private FleetGridControl fleetGridControl1;
        private EvidenceGridControl evidenceGridControl1;
        private System.Windows.Forms.Button VerifyPlacementButton;
    }
}

