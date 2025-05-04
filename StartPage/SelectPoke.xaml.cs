using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Contexts;
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
        //Adding the variables 
        private Pokemon selectedPokemon;
        private readonly int playerNumber;  // allows the user to use the one window to pick the pokemons 

        public P1Select(int playerNumber) // windows can be split and used continously only if their associated with a number
        {                                   // lets me make a seclection 1 and selection 2
            InitializeComponent();
            this.playerNumber = playerNumber;    
            LoadPokemonData();
        }
        private void LoadPokemonData()
        {
            using (var context = new PokeData())    //using the databse
            {
                nameBx.ItemsSource = context.Pokemon.Include("Types").Include("Moves").ToList();
                nameBx.DisplayMemberPath = "PokemonName";    // gets the names, types and moves from each pokemon
                                                             // then displays the anme in the box
            }
        }

        private void nameBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPokemon = nameBx.SelectedItem as Pokemon;// looking to see if a pokemon was selected 
            if (selectedPokemon != null)
            {
                ImgBx.Source = new BitmapImage(new Uri(selectedPokemon.ImageURL_Front, UriKind.Absolute));
                InfoBx.Items.Clear();           //displays more info about the pokemon to help the choice
                InfoBx.Items.Add("Type: " + selectedPokemon.Types.PokeType);
                InfoBx.Items.Add("Effective against: " + selectedPokemon.Types.Effective);
                InfoBx.Items.Add("Weak against: " + selectedPokemon.Types.Weakness);
                InfoBx.Items.Add("Health: " + selectedPokemon.Health);
            }
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (playerNumber == 1)     //Assigning rthe selected Pokemon to the Global App Properties to be used again later
                App.P1Selected = selectedPokemon;
            else
                App.P2Selected = selectedPokemon;

            if (App.P1Selected != null && App.P2Selected != null)   //prompting to pick a pokemon if not already picked
            {
                new P1Battle().Show();
                this.Close();
            }
            else
            {
                new P1Select(playerNumber == 1 ? 2 : 1).Show(); // if 2 was chosen first then swap to 1 and visa versa
                this.Close();
            }
            
            
        }

    }
}
