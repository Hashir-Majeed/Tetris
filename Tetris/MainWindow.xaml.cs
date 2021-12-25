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
        
        public MainWindow()
        {
            
            InitializeComponent();
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
            if (e.Key == Key.Space)
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
            Update();
        }
        private async void StartGame(object sender, RoutedEventArgs e)
        {
            await PlayGame();
        }
        private async Task PlayGame()
        {
            while (true)
            {
                int delay = 1000;
                await Task.Delay(delay);
                game.ShiftDown();
                Update();
            }
            
        }

        private void Update()
        {
            Square[] tempBoard = game.GetBoard().GetUIBoard();
            SolidColorBrush[] bindingVals = new SolidColorBrush[252];
            
            Dictionary<int, SolidColorBrush> ColourMatch = new Dictionary<int, SolidColorBrush>();
            ColourMatch.Add(-1, new SolidColorBrush(Colors.Black));
            ColourMatch.Add(0, new SolidColorBrush(Colors.LightGray));
            ColourMatch.Add(1, new SolidColorBrush(Colors.YellowGreen));
            ColourMatch.Add(2, new SolidColorBrush(Colors.LightBlue));
            ColourMatch.Add(3, new SolidColorBrush(Colors.Purple));
            ColourMatch.Add(4, new SolidColorBrush(Colors.DarkBlue));
            ColourMatch.Add(5, new SolidColorBrush(Colors.Orange));
            ColourMatch.Add(6, new SolidColorBrush(Colors.ForestGreen));
            ColourMatch.Add(7, new SolidColorBrush(Colors.Red));

            for (int i = 0; i < bindingVals.Length; i++)
            {
                bindingVals[i] = ColourMatch[tempBoard[i].getType()];
            }

            Score.Text = "Score: " + game.getScore();
            DataContext = bindingVals;
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
