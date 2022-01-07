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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TetrisGame game;
        Dictionary<int, SolidColorBrush> ColourMatch = new Dictionary<int, SolidColorBrush>();
        Rectangle[] NextPieceUI;
        public MainWindow()
        {
            
            InitializeComponent();
            NextPieceUI = new Rectangle[] {NextPiece0, NextPiece1, NextPiece2, NextPiece3, NextPiece4, NextPiece5, NextPiece6, NextPiece7, NextPiece8, NextPiece9, NextPiece10, NextPiece11, NextPiece12, NextPiece13, NextPiece14, NextPiece15 };
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

            game = new TetrisGame();           
            Update();
            //DataContext = testtext;

        }

        private void Key_Pressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                //game.RotatePiece();       
                game.RotatePiece();
            }
            if (e.Key == Key.Right)
            {
                //game.ShiftRight();
                game.ShiftRight();
            }
            if (e.Key == Key.Left)
            {
                //game.ShiftLeft();
                game.ShiftLeft();
            }
            if (e.Key == Key.Down)
            {
                //game.ShiftDown();
                game.ShiftDown();
            }
            if (e.Key == Key.Space)
            {
                game.DropPiece();
            }
            Update();
        }
        private async void StartGame(object sender, RoutedEventArgs e)
        {
            await PlayGame();
        }
        private async Task PlayGame()
        {
            int delay = 750;
            while (!game.IsLost())
            {
                
                await Task.Delay(delay);
                game.ShiftDown();
                delay = game.GetDelay();
                Update();
              
            }
            
        }

        private void Update()
        {
            Square[] tempBoard = game.GetBoard().GetUIBoard();
            SolidColorBrush[] bindingVals = new SolidColorBrush[252];
            Tetramino nextPiece = game.GetNextPiece();
            UpdateNextPiece(nextPiece);
            

            for (int i = 0; i < bindingVals.Length; i++)
            {
                bindingVals[i] = ColourMatch[tempBoard[i].getType()];
            }

            Score.Text = "Score: " + game.getScore();
            DataContext = bindingVals;
        }

        private void UpdateNextPiece(Tetramino nextPiece)
        {
            Coordinates[] pieceCoords = nextPiece.getPiece();
            int[] newIndexes = new int[pieceCoords.Length];
            for (int i = 0; i < pieceCoords.Length; i++)
            {
                newIndexes[i] = (pieceCoords[i].getX() - 1) * 4 + pieceCoords[i].getY() - 1;
            }
            int colour = nextPiece.getColour();
            
            for (int i = 0; i < NextPieceUI.Length; i++)
            {
                if (newIndexes.Contains(i))
                {
                    NextPieceUI[i].Fill = ColourMatch[colour];
                }
                else
                {
                    NextPieceUI[i].Fill = new SolidColorBrush(Colors.Transparent);
                }
                
            }

        }


        private void S1_Click(object sender, RoutedEventArgs e)
        {
            string[] testtext = new string[1];
            testtext[0] = "Binding";
            //game.Update();
            DataContext = testtext;
        }

        
    }
}
