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
    /// Interaction logic for Split.xaml
    /// </summary>
    public partial class Split : Window
    {
        public Split()
        {
            InitializeComponent();
        }

        private void P1Btn_Click(object sender, RoutedEventArgs e)
        {
            var p1Select = new P1Select(1); // Indicate Player 1
            p1Select.Show();
            this.Close();
        }

        private void P2Btn_Click(object sender, RoutedEventArgs e)
        {
            var p2Select = new P1Select(2); // Indicate Player 2
            p2Select.Show();
            this.Close();
        }
    }
}
