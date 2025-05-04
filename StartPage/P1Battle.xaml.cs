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
    /// Interaction logic for P1Battle.xaml
    /// </summary>
    public partial class P1Battle : Window
    {
        //initalising the selected pokemons through the app componant 
        //cause its global data that can be stored across the entire project
        //creating non static health variables too 
        Pokemon p1 = App.P1Selected;
        Pokemon p2 = App.P2Selected;

        int p1Health, p2Health;
        bool p1Turn = true;

        public P1Battle()
        {
            InitializeComponent();
            p1Health = p1.Health;       //initialising the health
            p2Health = p2.Health;
            AddingtheImagry();
        }

        private void Move_Click(object sender, RoutedEventArgs e)
        {
            int effective = 2;
            var move = (sender as Button).Tag as Moves;
            if (move == null) return;

            //adding in whose turn it is and effective types
            if (p1Turn)
            {
                if(p1.Types.PokeType == p2.Types.Weakness)
                {
                    p2Health -= (move.AttackDamage * effective) ;
                }
                else { p2Health -= move.AttackDamage; }
                
            }
            else
            {
                if (p2.Types.PokeType == p1.Types.Weakness)
                {
                    p1Health -= (move.AttackDamage * effective);
                }
                else { p1Health -= move.AttackDamage; }
                
            }
                
            //which ever pokemon hits 0 health or lower loses -- finding the winner
            if (p1Health <= 0 || p2Health <= 0)
            {
                string winner = p1Health > 0 ? p1.PokemonName : p2.PokemonName;
                string winnerURL = p1Health > 0 ? p1.ImageURL_Front : p2.ImageURL_Front;
                new Winner(winner , winnerURL).Show();
                this.Close();
            }
            else
            {
                p1Turn = !p1Turn;
                AddingtheImagry();
            }
        }

        private void AddingtheImagry()
        {
            //code found online to help find out whose turn it is to be able to change the active pokemon 
            Pokemon active = p1Turn ? p1 : p2;
            Pokemon opponent = p1Turn ? p2 : p1;
            int activeHP = p1Turn ? p1Health : p2Health;
            int opponentHP = p1Turn ? p2Health : p1Health;

            //Displays the name, image and health of the active pokemon
            ActiveName.Text = active.PokemonName;
            ActiveHealth.Maximum = active.Health;
            ActiveHealth.Value = activeHP;
            ActiveImg.Source = new BitmapImage(new Uri(active.ImageURL_Back, UriKind.Absolute));

            //Displays the name, image and health of the opposing pokemon
            OpponentName.Text = opponent.PokemonName;
            OpponentHealth.Maximum = opponent.Health;
            OpponentHealth.Value = opponentHP;
            OpponentImg.Source = new BitmapImage(new Uri(opponent.ImageURL_Front, UriKind.Absolute));

            //add the moves to a temporary array to assingn them buttons 
            var moves = active.Moves.ToList();
            var buttons = new[] { Move1Btn, Move2Btn, Move3Btn, Move4Btn };

            for (int i = 0; i < buttons.Length; i++)
            {
                if (i < moves.Count)
                {
                    buttons[i].Content = moves[i].MoveName;
                    buttons[i].Tag = moves[i];
                    buttons[i].IsEnabled = true;
                }
                else
                {
                    buttons[i].Content = "No Move Avaiable";
                    buttons[i].IsEnabled = false;
                }
            }
        }
    }
}
