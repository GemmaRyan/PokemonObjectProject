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
    /// Interaction logic for P2Select.xaml
    /// </summary>
    public partial class P2Select : Window
    {
        public P2Select()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // this is to start the game
            //have to change the code to become an if statment with a hidden box f
            // for otherwise
            P1Battle b1Window = new P1Battle();
            b1Window.Show();

            this.Close();
        }
    }
}
