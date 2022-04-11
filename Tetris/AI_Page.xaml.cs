using System;
using System.IO;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    /// 

    /*  
     * AI PAGE GUI
     * 
     * This is the main page that gets data from the AI and displays it for the 
     * AI simulation based off the chosen heuristic values.
     * 
     * */
    public partial class AI_Page : Window
    {

        private AI bestPlayer;
        Dictionary<int, SolidColorBrush> colourMatch = new Dictionary<int, SolidColorBrush>();
        Rectangle[] nextPieceUI;
        Rectangle[] holdPieceUI;
        public AI_Page(double holeWeight, double bumpinessWeight, double heightWeight, double linesWeight)
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

            // Creation of the AI
            bestPlayer = new AI(holeWeight, bumpinessWeight, heightWeight, linesWeight);
            Update();

        }

        private async void StartGame(object sender, RoutedEventArgs e)
        {
            await PlayGame();
        }

        private async Task PlayGame()
        {
            // Ticker Timer to sequentially execute moves
            int delay = 2250;
            while (!bestPlayer.IsLost())
            {
                await Task.Delay(delay);
                // Make Move
                bestPlayer.ComputeMove();
                delay = bestPlayer.GetDelay();
                Update();

            }
            MessageBox.Show("Game Over!");
            // Write score to the High Scores File
            try
            {
                using (StreamWriter writer = new StreamWriter("C:\\Users\\hashi\\OneDrive\\Desktop\\Scores.txt", append:true))
                {
                    writer.WriteLine("A" + bestPlayer.GetScore() + ";");
                }
            }
            catch
            {
                MessageBox.Show("Error writing to file");
            }

        }


        private void Update()
        {
            // Updating the GUI using data binding

            Square[] tempBoard = bestPlayer.GetBoard().GetUIBoard();
            SolidColorBrush[] bindingVals = new SolidColorBrush[252];
            Tetramino nextPiece = bestPlayer.GetNextPiece();

            UpdateNextPiece(nextPiece, nextPieceUI);

            for (int i = 0; i < bindingVals.Length; i++)
            {
                bindingVals[i] = colourMatch[tempBoard[i].getType()];
            }

            Score.Text = "Score: " + bestPlayer.GetScore();
            Level.Text = "Level: " + bestPlayer.GetLevel();
            DataContext = bindingVals;
        }


        private void UpdateNextPiece(Tetramino nextPiece, Rectangle[] UI)
        {
            // Update the Next Piece GUI manually

            Coordinates[] pieceCoords = nextPiece.getPiece();
            int[] newIndexes = new int[pieceCoords.Length];
            for (int i = 0; i < pieceCoords.Length; i++)
            {
                newIndexes[i] = (pieceCoords[i].GetX() - 1) * 4 + pieceCoords[i].GetY() - 1;
            }
            int colour = nextPiece.getColour();

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
