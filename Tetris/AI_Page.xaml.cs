using System;
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
    public partial class AI_Page : Page
    {
        Frame Contents;
        object[] Pages;

        private AI BestPlayer;
        Dictionary<int, SolidColorBrush> ColourMatch = new Dictionary<int, SolidColorBrush>();
        Rectangle[] NextPieceUI;
        Rectangle[] HoldPieceUI;
        public AI_Page(Frame pageFrame, object[] allPages)
        {

            InitializeComponent();
            Contents = pageFrame;
            Pages = allPages;

            NextPieceUI = new Rectangle[] { NextPiece0, NextPiece1, NextPiece2, NextPiece3, NextPiece4, NextPiece5, NextPiece6, NextPiece7, NextPiece8, NextPiece9, NextPiece10, NextPiece11, NextPiece12, NextPiece13, NextPiece14, NextPiece15 };
            HoldPieceUI = new Rectangle[] { HoldPiece0, HoldPiece1, HoldPiece2, HoldPiece3, HoldPiece4, HoldPiece5, HoldPiece6, HoldPiece7, HoldPiece8, HoldPiece9, HoldPiece10, HoldPiece11, HoldPiece12, HoldPiece13, HoldPiece14, HoldPiece15 };
            ColourMatch.Add(-1, new SolidColorBrush(Colors.Black));
            ColourMatch.Add(0, new SolidColorBrush(Colors.LightGray));
            ColourMatch.Add(1, new SolidColorBrush(Colors.YellowGreen));
            ColourMatch.Add(2, new SolidColorBrush(Colors.OrangeRed));
            ColourMatch.Add(3, new SolidColorBrush(Colors.Purple));
            ColourMatch.Add(4, new SolidColorBrush(Colors.DarkBlue));
            ColourMatch.Add(5, new SolidColorBrush(Colors.Orange));
            ColourMatch.Add(6, new SolidColorBrush(Colors.ForestGreen));
            ColourMatch.Add(7, new SolidColorBrush(Colors.Red));
            /*SolidColorBrush[] bindingVals = new SolidColorBrush[200];
            for (int i = 0; i < 200; i++)
            {
                bindingVals[i] = new SolidColorBrush(Colors.Blue);
            }*/
            //DataContext = bindingVals;

            BestPlayer = new AI();
            Update();
            //DataContext = testtext;

        }

        private async void StartGame(object sender, RoutedEventArgs e)
        {
            await PlayGame();
        }

        private async Task PlayGame()
        {
            int delay = 2250;
            while (!BestPlayer.IsLost())
            {

                await Task.Delay(delay);
                //BestPlayer.ShiftDown();
                BestPlayer.ComputeMove();
                delay = BestPlayer.GetDelay();
                Update();

            }

        }


        private void Update()
        {
            Square[] tempBoard = BestPlayer.GetBoard().GetUIBoard();
            SolidColorBrush[] bindingVals = new SolidColorBrush[252];
            Tetramino nextPiece = BestPlayer.GetNextPiece();


            UpdateNextPiece(nextPiece, NextPieceUI);


            for (int i = 0; i < bindingVals.Length; i++)
            {
                bindingVals[i] = ColourMatch[tempBoard[i].getType()];
            }

            Score.Text = "Score: " + BestPlayer.GetScore();
            Level.Text = "Level: " + BestPlayer.GetLevel();
            DataContext = bindingVals;
        }


        private void UpdateNextPiece(Tetramino nextPiece, Rectangle[] UI)
        {
            Coordinates[] pieceCoords = nextPiece.getPiece();
            int[] newIndexes = new int[pieceCoords.Length];
            for (int i = 0; i < pieceCoords.Length; i++)
            {
                newIndexes[i] = (pieceCoords[i].getX() - 1) * 4 + pieceCoords[i].getY() - 1;
            }
            int colour = nextPiece.getColour();

            for (int i = 0; i < UI.Length; i++)
            {
                if (newIndexes.Contains(i))
                {
                    UI[i].Fill = ColourMatch[colour];
                }
                else
                {
                    UI[i].Fill = new SolidColorBrush(Colors.Transparent);
                }

            }

        }

    }
}
