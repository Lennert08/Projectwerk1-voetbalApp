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
    /// Interaction logic for SpelerAanmakenScherm.xaml
    /// </summary>
    public partial class SpelerAanmakenScherm : Window
    {
        public SpelerAanmakenScherm()
        {
            InitializeComponent();
        }




        private void CreateSpeler(object sender, RoutedEventArgs e)
        {
            try
            {
                string ingegevenVoornaam = IngegevenVoornaam.Text;
                string ingegevenAchternaam = IngegevenAchternaam.Text;
                int aantalSpelers = UseDomainManager._manager.GetGroupSpelerCount(GeselecteerdeGroepClass.CurrentGroup);
                int maxAantalSpeler = 30;
                int ingegevenRugnummer;
                bool isGeldigRugnummer = int.TryParse(IngegevenRugnummer.Text, out ingegevenRugnummer);

                if (!isGeldigRugnummer)
                {
                    throw new FormatException("Het rugnummer is niet geldig. Voer een geldig nummer in.");
                }

                if (aantalSpelers >= maxAantalSpeler)
                {
                    MessageBox.Show("De groep heeft al het maximale aantal spelers bereikt.", "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; //Stop de volgende methodes
                }

                Speler nieuweSpeler = new Speler(-1, ingegevenVoornaam, ingegevenAchternaam, ingegevenRugnummer);
                UseDomainManager._manager.AddSpeler(nieuweSpeler);
                MessageBox.Show("Speler was aangemaakt", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fout", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
