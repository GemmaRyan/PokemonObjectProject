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

        public P1Battle()  // Constructor that takes the Pokémon
        {
            InitializeComponent();
            DisplayPokemonData();  // Method to display the data
        }

        public Pokemon P2SelectedPokemon { get; set; }
        public Pokemon P1SelectedPokemon { get; set; }  // Public property to receive data

        private void DisplayPokemonData()
        {
            if (P1SelectedPokemon != null && P2SelectedPokemon != null)
            {
                // Display the data in your controls
                P1Namelb.Content = P1SelectedPokemon.PokemonName;
                P1img.Source = new BitmapImage(new Uri(P1SelectedPokemon.ImageURL_Front));


                P2Namelb.Content = P2SelectedPokemon.PokemonName;
                P1img.Source = new BitmapImage(new Uri(P1SelectedPokemon.ImageURL_Front));

            }
        }
    }
}
