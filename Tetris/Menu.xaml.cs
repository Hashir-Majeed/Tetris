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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        Frame Contents;
        public Menu(Frame pageFrame)
        {
            InitializeComponent();
            Contents = pageFrame;
        }

        private void Play_AI(object sender, RoutedEventArgs e)
        {
            Window w = new Heuristics();
            w.Show();
        }

        private void Play_Game(object sender, RoutedEventArgs e)
        {
            Window w = new TestGame();
            w.Show();
        }

        private void High_Scores_Page(object sender, RoutedEventArgs e)
        {
            Window w = new HighScores();
            w.Show();
        }
        
    }
}
