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
using System.Windows.Shapes;

namespace StartPage
{
    /// <summary>
    /// Interaction logic for Winner.xaml
    /// </summary>
    public partial class Winner : Window
    {
        public Winner(string winner, string winnerImageUrl)
        {
            //Yippee you win
            InitializeComponent();
            WinLb.Content = winner + " Wins!";
            WinnerImg.Source = new BitmapImage(new Uri(winnerImageUrl, UriKind.Absolute));
        }
    }
}
