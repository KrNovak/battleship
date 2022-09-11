using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Vsite.Oom.Battleship.Model;

namespace GUI
{
    public partial class MainForm : Form
    { 
        public MainForm()
        {
            InitializeComponent();
        }
        private void CreateFleet()  
        {
            myFleet = shipwright.CreateFleet();
            Thread.Sleep(100); 
            gunnery = new Gunnery(10, 10, new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
            enemyFleet = shipwright.CreateFleet();
        }
        
        private static T RandomEnumValue<T>()
        {
            var ply = Enum.GetValues(typeof(T));
            return (T)ply.GetValue(rnd.Next(ply.Length));
        }

       
        private void StartGame()
        {
            UpdateLabels();
            playerOnMove = RandomEnumValue<CurrentPlayer>();
            switch (playerOnMove)
            {
                case CurrentPlayer.LivePerson:
                    MessageBox.Show("You start first!", "Player selection"); 
                    break;
                case CurrentPlayer.Computer:
                    MessageBox.Show("Computer starts first!", "Player selection");
                    ComputerShoots(); 
                    break;
                default:
                    break;
            }
            //if (mySingleton)
            //{
            //    CreateFleet();
            //}

        }
      
        void HandleYourShot(int row, int column)
        {
            var hitResult = enemyFleet.Shoot(row, column);
          
            switch (hitResult)
            {
                case HitResult.Missed:
                    evidenceGridControl1.AnimateColor(row, column, Color.White);
                    break;
                case HitResult.Hit:
                    --enemySquaresLeft;
                    UpdateLabels();
                    evidenceGridControl1.AnimateColor(row, column, Color.Red);
                    break;
                case HitResult.Sunken:
                    --enemySquaresLeft;
                    --enemyShipsLeft;
                    UpdateLabels();
                    evidenceGridControl1.AnimateColor(row, column, Color.Red);
                    MessageBox.Show("Ship sunken!");
                    if (enemyShipsLeft == 0) 
                    {
                        MessageBox.Show("You won!", "Winner");
                        ResetLabels(); 
                       
                        StartButton.Enabled = false;
                    }
                    break;
                default:
                    break;
            }
            ComputerShoots();
        }
        void ComputerShoots()
        {
            try
            {
                var square = gunnery.NextTarget();
                var hitResult = myFleet.Shoot(square.Row, square.Column);
                int adjust = square.Row + 1;
                enemyLastTarget = ((char)(square.Column + 'A')).ToString() + "-" + adjust.ToString();
                gunnery.ProcessShootingResult(hitResult); 
                                                          
                switch (hitResult)                        
                {                                         
                    case HitResult.Missed:               
                        fleetGridControl1.AnimateColor(square.Row, square.Column, Color.White);  
                        break;                                                                  
                    case HitResult.Hit:
                        --mySquaresLeft;
                        UpdateLabels();
                        fleetGridControl1.AnimateColor(square.Row, square.Column, Color.Red);

                        break;
                    case HitResult.Sunken:
                        --mySquaresLeft;
                        --myShipsLeft;
                        UpdateLabels();
                        fleetGridControl1.AnimateColor(square.Row, square.Column, Color.Red);
                        if (myShipsLeft == 0) 
                        {
                            MessageBox.Show("Computer won!", "Winner");
                            ResetLabels(); 
                            
                            StartButton.Enabled = false;
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (System.ArgumentOutOfRangeException)
            {
            }

        }

        private void ResetLabels()
        {
            mySquaresLeft = 30;enemySquaresLeft = 30;
            myShipsLeft = 10;enemyShipsLeft = 10;
            myLastTarget = "";enemyLastTarget = "";
            UpdateLabels();
        }
        private void UpdateLabels()
        {
            myShipsLabel.Text = "Ships left: " + myShipsLeft.ToString();
            mySquaresLabel.Text = "Squares left: " + mySquaresLeft.ToString();
            myLastTargetLabel.Text = "Last target: " + myLastTarget;
            enemyShipsLabel.Text = "Ships left: " + enemyShipsLeft.ToString();
            enemySquaresLabel.Text = "Squares left: " + enemySquaresLeft.ToString();
            enemyLastTargetLabel.Text = "Last target: " + enemyLastTarget;
        }

        private static readonly Shipwright shipwright = new Shipwright(10, 10, new int[] {5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
        private Gunnery gunnery; 
        private Fleet enemyFleet; 
        private Fleet myFleet;
        static readonly Random rnd = new Random();
       
        private int mySquaresLeft = 30, enemySquaresLeft = 30;
        private int myShipsLeft = 10, enemyShipsLeft = 10;
        private string myLastTarget, enemyLastTarget;
        CurrentPlayer playerOnMove;
        enum CurrentPlayer
        {
            LivePerson,
            Computer
        }


        private void PlaceFleetButton_Click(object sender, EventArgs e)
        {
            if (StartButton.Enabled == false)
            {
                CreateFleet();
            }
            fleetGridControl1.PlaceFleet(myFleet);
            try
            {
                evidenceGridControl1.PlaceFleet(enemyFleet);
            }
            catch (System.NullReferenceException) 
            {                                     
            }                                     

        }

        private void evidenceGridControl1_Load(object sender, EventArgs e)
        {

        }

        private void VerifyPlacementButton_Click(object sender, EventArgs e)
        {
            StartButton.Enabled = true;
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            evidenceGridControl1.Enabled = true;
            fleetGridControl1.Enabled = true;
            StartGame();
        }

        private void evidenceGridControl1_ButtonClick(object sender, EventArgs e)
        {
            UpdateLabels();
           
            if (sender is GridButton button)
            {
                int row = button.Row;
                int column = button.Column;
                HandleYourShot(row, column);
                ++row;
                myLastTarget = ((char)(column + 'A')).ToString() + "-" + row.ToString();
            }
        }

    }
}
