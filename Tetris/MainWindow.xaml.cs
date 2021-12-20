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

        private void Update()
        {
            Square[] tempBoard = game.GetBoard().GetUIBoard();
            SolidColorBrush[] bindingVals = new SolidColorBrush[200];
            
            Dictionary<int, SolidColorBrush> ColourMatch = new Dictionary<int, SolidColorBrush>();
            ColourMatch.Add(0, new SolidColorBrush(Colors.LightGray));
            ColourMatch.Add(1, new SolidColorBrush(Colors.LightBlue));
            ColourMatch.Add(2, new SolidColorBrush(Colors.DarkBlue));
            ColourMatch.Add(3, new SolidColorBrush(Colors.Orange));
            ColourMatch.Add(4, new SolidColorBrush(Colors.Yellow));
            ColourMatch.Add(5, new SolidColorBrush(Colors.Green));
            ColourMatch.Add(6, new SolidColorBrush(Colors.Purple));
            ColourMatch.Add(7, new SolidColorBrush(Colors.Red));

            for (int i = 0; i < 200; i++)
            {
                bindingVals[i] = ColourMatch[tempBoard[i].getType()];
            }
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
