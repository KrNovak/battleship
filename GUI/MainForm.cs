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
        private void CreateFleet()  //async
        {
            myFleet = shipwright.CreateFleet();
            Thread.Sleep(100); //da izbjegnem generiranje identičnih flota za oba igrača
            gunnery = new Gunnery(10, 10, new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
            enemyFleet = shipwright.CreateFleet();
        }
        
        private static T RandomEnumValue<T>()
        {
            var ply = Enum.GetValues(typeof(T));
            return (T)ply.GetValue(rnd.Next(ply.Length));
        }

        // WHEN START GAME BUTTON IS CLICKED
        private void StartGame()
        {
            UpdateLabels();
            playerOnMove = RandomEnumValue<CurrentPlayer>(); //odabir igrača
            switch (playerOnMove)
            {
                case CurrentPlayer.LivePerson:
                    MessageBox.Show("You start first!", "Player selection"); //mi startmo klikom na evidenceGrid kontrolu
                    break;
                case CurrentPlayer.Computer:
                    MessageBox.Show("Computer starts first!", "Player selection");
                    ComputerShoots(); //poziv poteza računala
                    break;
                default:
                    break;
            }
            //if (mySingleton)
            //{
            //    CreateFleet();
            //}

        }
        // When player clicks on evidenceGrid
        void HandleYourShot(int row, int column)
        {
            var hitResult = enemyFleet.Shoot(row, column);
            //:depending on hit result colour corresponding button
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
                    if (enemyShipsLeft == 0) //uvjet za završiti igru
                    {
                        MessageBox.Show("You won!", "Winner");
                        ResetLabels(); //priprema za novu igru u istom prozoru
                        //mySingleton = true;
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
                gunnery.ProcessShootingResult(hitResult); //try blok je zbog ove linije 2 su problema nakon pogodka premjeni stanje u surrounding 
                                                          //no sljedeću iteraciju ga zaboravi i opet je na random to sam vas htio pitat u call-u
                switch (hitResult)                        //druga stvar je da se RandomShooting class-i nakon jedno 30 iteracija dogodi 
                {                                         //ArgumentOutOfRangeException linija 26: var index = random.Next(candidates.Count());
                    case HitResult.Missed:                //dok igrate grešku ćete prepoznati kad računalo prestane pucati a mozete i maknit try blok
                        fleetGridControl1.AnimateColor(square.Row, square.Column, Color.White);  //no ako pobjedite ponovo namistite flotu i krenete
                        break;                                                                   // racunalo ce opet pucati dok nedode preljev
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
                        if (myShipsLeft == 0) //uvjet za završiti igru
                        {
                            MessageBox.Show("Computer won!", "Winner");
                            ResetLabels(); //pripremi stanje za newGame
                            //mySingleton = true;
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
        private Gunnery gunnery; //kad pokeremo igru onda konstruktor pozvat
        private Fleet enemyFleet; 
        private Fleet myFleet;
        static readonly Random rnd = new Random();
        //private bool mySingleton = false; //ovo sam koristio u jednom od prethodnih rjesenja za CreateFleet()
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
            catch (System.NullReferenceException) //ovo se događa zbog uvođenja Task.Delay jer se naredba u try 
            {                                     //ide pozvati dok je stvaranje enemyFleet u CreateFleet() delay-ano 
            }                                     //no nakon isteka vremena sve radi i igra teče uredno

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
            //GridButton button = sender as GridButton;
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
