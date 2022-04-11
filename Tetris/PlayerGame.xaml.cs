using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for TestGame.xaml
    /// </summary>
    /// 

    /*
     * PLAYER GAME GUI 
     * User Interface for creating a Tetris Game and updating the UI
     * through data binding
     */
    public partial class PlayerGame : Window
    {
        private TetrisGame game;
        Dictionary<int, SolidColorBrush> colourMatch = new Dictionary<int, SolidColorBrush>();
        Rectangle[] nextPieceUI;
        Rectangle[] holdPieceUI;
        public PlayerGame()
        {

            InitializeComponent();
            // Initialise UI elements and colours
            nextPieceUI = new Rectangle[] { NextPiece0, NextPiece1, NextPiece2, NextPiece3, NextPiece4, NextPiece5, NextPiece6, NextPiece7, NextPiece8, NextPiece9, NextPiece10, NextPiece11, NextPiece12, NextPiece13, NextPiece14, NextPiece15 };
            holdPieceUI = new Rectangle[] { HoldPiece0, HoldPiece1, HoldPiece2, HoldPiece3, HoldPiece4, HoldPiece5, HoldPiece6, HoldPiece7, HoldPiece8, HoldPiece9, HoldPiece10, HoldPiece11, HoldPiece12, HoldPiece13, HoldPiece14, HoldPiece15 };
            colourMatch.Add(-1, new SolidColorBrush(Colors.Black));
            colourMatch.Add(0, new SolidColorBrush(Colors.LightGray));
            colourMatch.Add(1, new SolidColorBrush(Colors.YellowGreen));
            colourMatch.Add(2, new SolidColorBrush(Colors.OrangeRed));
            colourMatch.Add(3, new SolidColorBrush(Colors.Purple));
            colourMatch.Add(4, new SolidColorBrush(Colors.DarkBlue));
            colourMatch.Add(5, new SolidColorBrush(Colors.Orange));
            colourMatch.Add(6, new SolidColorBrush(Colors.ForestGreen));
            colourMatch.Add(7, new SolidColorBrush(Colors.Red));
            // Create a player game
            game = new TetrisGame();
            Update();

        }

        private void Key_Pressed(object sender, KeyEventArgs e)
        {
            // On user input events, fire a function call
            if (e.Key == Key.Up)
            {     
                game.RotatePiece();
            }
            if (e.Key == Key.Right)
            {
                game.ShiftRight();
            }
            if (e.Key == Key.Left)
            {
                game.ShiftLeft();
            }
            if (e.Key == Key.Down)
            {
                game.ShiftDown();
            }
            if (e.Key == Key.Space)
            {
                game.DropPiece();
            }
            if (e.Key == Key.D)
            {
                if (game.CanUserHold())
                {
                    game.HoldPiece();
                    UpdateNextPiece(game.GetHoldPiece(), holdPieceUI);
                }

            }
            Update();
        }
        private async void StartGame(object sender, RoutedEventArgs e)
        {
            await PlayGame();
        }

        private async Task PlayGame()
        {
            int delay = 2250;
            while (!game.IsLost())
            {
                await Task.Delay(delay);
                // Sequentially shift pieces down on the ticker timer event
                game.ShiftDown();
                delay = game.GetDelay();
                Update();

            }
            MessageBox.Show("Game Over!");

            // After the game is over, save score to the High Scores file
            try
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\hashi\\OneDrive\\Desktop\\Scores.txt", append:true))
                {
                    writer.WriteLine("P" + game.GetScore() + ";");
                }
            }
            catch
            {
                MessageBox.Show("Error writing to file");
            }

        }


        private void Update()
        {
            // Update board through data binding
            Square[] tempBoard = game.GetBoard().GetUIBoard();
            SolidColorBrush[] bindingVals = new SolidColorBrush[252];
            Tetramino nextPiece = game.GetNextPiece();


            UpdateNextPiece(nextPiece, nextPieceUI);


            for (int i = 0; i < bindingVals.Length; i++)
            {
                bindingVals[i] = colourMatch[tempBoard[i].GetSquareType()];
            }

            Score.Text = "Score: " + game.GetScore();
            Level.Text = "Level: " + game.GetLevel();
            DataContext = bindingVals;
        }


        private void UpdateNextPiece(Tetramino nextPiece, Rectangle[] UI)
        {
            // Update extra UI elements manually
            Coordinates[] pieceCoords = nextPiece.GetPiece();
            int[] newIndexes = new int[pieceCoords.Length];
            for (int i = 0; i < pieceCoords.Length; i++)
            {
                newIndexes[i] = (pieceCoords[i].GetX() - 1) * 4 + pieceCoords[i].GetY() - 1;
            }
            int colour = nextPiece.GetColour();

            for (int i = 0; i < UI.Length; i++)
            {
                if (newIndexes.Contains(i))
                {
                    UI[i].Fill = colourMatch[colour];
                }
                else
                {
                    UI[i].Fill = new SolidColorBrush(Colors.Transparent);
                }

            }

        }
    }
}
