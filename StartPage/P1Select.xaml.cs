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
    /// Interaction logic for P1Select.xaml
    /// </summary>
    public partial class P1Select : Window
    {
        public P1Select()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            P2Select p2Window = new P2Select();
            p2Window.Show();

            this.Close();
        }
    }
}
