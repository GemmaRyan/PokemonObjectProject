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
        public P1Select()
        {
            InitializeComponent();
            LoadPokemonData();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (NameBx.SelectedItem == null)
            {
                errorbx.Text = "Please select a Pokémon first!";
                errorbx.Foreground = Brushes.Red; 
            }
            else
            {
                
                P2Select p2Window = new P2Select();
                p2Window.Show();
                this.Close();
            }
        }
        private void LoadPokemonData()
        {
            using (var context = new PokeData())
            {
                // Load the complete Pokemon objects, not just names
                List<Pokemon> pokemonList = context.Pokemon.ToList();
                NameBx.ItemsSource = pokemonList;
                NameBx.DisplayMemberPath = "PokemonName"; // This tells the ListBox to display the name
            }
        }

        private void NameBx_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            if (NameBx.SelectedItem is Pokemon selectedPokemon)
            {
                try
                {
                    // Display the image (your existing code)
                    if (!string.IsNullOrEmpty(selectedPokemon.ImageURL_Front))
                    {
                        var bitmap = new BitmapImage(new Uri(selectedPokemon.ImageURL_Front));
                        ImgBx.Source = bitmap;
                    }

                    // Clear previous info
                    InfoBx.Items.Clear();

                    // Add Pokémon details to InfoBx
                    InfoBx.Items.Add(selectedPokemon);
                    InfoBx.Items.Add($"Type: {selectedPokemon.Types.PokeType}");
                    InfoBx.Items.Add($"Health: {selectedPokemon.Health}");
                    InfoBx.Items.Add($"Weak Against: {selectedPokemon.Types.Weakness}");
                    InfoBx.Items.Add($"Strong Against: {selectedPokemon.Types.Effective}");

                   
                }
                catch (Exception ex)
                {
                    InfoBx.Items.Add($"Error loading data: {ex.Message}");
                }
            }
            else
            {
                InfoBx.Items.Clear();
                InfoBx.Items.Add("No Pokémon selected");
            }
        }
    }
}
