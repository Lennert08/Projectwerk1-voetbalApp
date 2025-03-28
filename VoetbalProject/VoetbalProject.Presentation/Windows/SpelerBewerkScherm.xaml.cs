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
using VoetbalProject.Domain.Models;

namespace VoetbalProject.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for SpelerBewerkScherm.xaml
    /// </summary>
    public partial class SpelerBewerkScherm : Window
    {
        private Speler _oldSpeler;
        private Speler _newSpeler;
        public SpelerBewerkScherm(Speler speler)
        {
            InitializeComponent();
            _oldSpeler = speler;
            SpelerTitel.Content =speler.VolleNaam;
            VoornaamTextBox.Text = speler.Voornaam;
            AchternaamTextBox.Text= speler.Achternaam;
            RugNummerTextBox.Text = speler.RugNummer.ToString();
        }
        private void SaveSpelerButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Probeer het rugnummer te parsen naar een long en maak een nieuwe speler
                long rugNummer = long.Parse(RugNummerTextBox.Text);

                // Maak de nieuwe speler met de ingevulde gegevens
                _newSpeler = new Speler(_oldSpeler.Id, VoornaamTextBox.Text, AchternaamTextBox.Text, rugNummer);

                UseDomainManager._manager.UpdateSpeler(_oldSpeler.Id, _newSpeler);

                DialogResult = true;
                this.Close();
            }
            catch (FormatException ex)
            {
                // Fout bij het omzetten van het rugnummer naar een long
                MessageBox.Show("Het rugnummer is niet geldig. Voer een geldig nummer in.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                // Algemene foutafhandeling
                MessageBox.Show($"Er is een fout opgetreden bij het opslaan van de speler: {ex.Message}", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Stel de DialogResult in op false als de gebruiker annuleert
            DialogResult = false;
            this.Close();
        }
    }
}
