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
                    if (!string.IsNullOrEmpty(selectedPokemon.ImageURL_Front))
                    {
                        var imagePath = selectedPokemon.ImageURL_Front;

                        var bitmap = new BitmapImage();
                        bitmap.BeginInit();

                        // Check if the path is a URI (http/https) or a local file path
                        if (imagePath.StartsWith("http", StringComparison.OrdinalIgnoreCase))
                        {
                            bitmap.UriSource = new Uri(imagePath, UriKind.Absolute);
                        }
                        else
                        {
                            // For local paths, you might need to adjust this based on your actual path structure
                            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
                        }

                        bitmap.CacheOption = BitmapCacheOption.OnLoad;
                        bitmap.EndInit();

                        ImgBx.Source = bitmap;
                    }
                    else
                    {
                        ImgBx.Source = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Image loading error: " + ex.Message);
                    ImgBx.Source = null;
                }
            }
            else
            {
                ImgBx.Source = null;
            }
        }
    }
}
