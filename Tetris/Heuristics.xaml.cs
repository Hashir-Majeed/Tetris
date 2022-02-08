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
    /// Interaction logic for Heuristics.xaml
    /// </summary>
    public partial class Heuristics : Window
    {
        double holeWeight;
        double bumpinessWeight;
        double linesWeight;
        double heightWeight;
        public Heuristics()
        {
            InitializeComponent();
            holeWeight = 0;
            bumpinessWeight = 0;
            heightWeight = 0;
            linesWeight = 0;
        }

        private void ValChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            bumpinessWeight = Bumpiness.Value * 0.01;
            holeWeight = Holes.Value * 0.01;
            heightWeight = Height.Value * 0.01;
            linesWeight = Lines.Value * 0.01;
        }

        private void StartAI(object sender, RoutedEventArgs e)
        {
            Window AI = new AI_Page(holeWeight, bumpinessWeight, heightWeight, linesWeight);
            AI.Show();
        }
    }
}
