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
        object[] Pages = new object[3];
        public MainWindow()
        {
            InitializeComponent();
            Pages[0] = new Menu(Contents, Pages);
            Pages[1] = new AI_Page(Contents, Pages);
            Pages[2] = new PlayerGame(Contents, Pages);
            //Pages[3] = new Heuristics(Contents, Pages);

            Contents.Navigate(Pages[0]);
        }

        

    }
}
