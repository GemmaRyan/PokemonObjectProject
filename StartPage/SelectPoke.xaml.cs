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
        private Pokemon selectedPokemon;
        private readonly int playerNumber;

        public P1Select(int playerNumber)
        {
            InitializeComponent();
            this.playerNumber = playerNumber;    
            LoadPokemonData();
        }
        private void LoadPokemonData()
        {
            using (var context = new PokeData())
            {
                nameBx.ItemsSource = context.Pokemon.Include("Types").Include("Moves").ToList();
                nameBx.DisplayMemberPath = "PokemonName";
            }
        }

        private void nameBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedPokemon = nameBx.SelectedItem as Pokemon;
            if (selectedPokemon != null)
            {
                ImgBx.Source = new BitmapImage(new Uri(selectedPokemon.ImageURL_Front, UriKind.Absolute));
                InfoBx.Items.Clear();
                InfoBx.Items.Add("Type: " + selectedPokemon.Types.PokeType);
                InfoBx.Items.Add("Effective against: " + selectedPokemon.Types.Effective);
                InfoBx.Items.Add("Weak against: " + selectedPokemon.Types.Weakness);
                InfoBx.Items.Add("Health: " + selectedPokemon.Health);
            }
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            
            if (playerNumber == 1)
                App.P1Selected = selectedPokemon;
            else
                App.P2Selected = selectedPokemon;

            if (App.P1Selected != null && App.P2Selected != null)
            {
                new P1Battle().Show();
                this.Close();
            }
            else
            {
                new P1Select(playerNumber == 1 ? 2 : 1).Show();
                this.Close();
            }
            
            
        }

    }
}
