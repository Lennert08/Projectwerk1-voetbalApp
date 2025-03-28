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
    /// Interaction logic for SpelerScherm.xaml
    /// </summary>
    public partial class SpelerScherm : Window
    {
        public SpelerScherm()
        {
            InitializeComponent();
            UpdateList();
        }

        private void NavigateToNextWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                SchermManager.NavigateToNextWindow(this, button.Tag as string);
            }
        }

        private void BewerkButtonClicked(object sender, RoutedEventArgs e)
        {
            if (PlayerList.SelectedItem is Speler speler)
            {
                speler = UseDomainManager._manager.GetSpelerById(speler.Id); // Haal de nieuwste versie van de speler op
                bool? isGelukt = SchermManager.GoToSpelerBewerkenScherm(this, speler);

                if (isGelukt.GetValueOrDefault(false))
                {
                    UpdateList(); // Lijst opnieuw updaten na succesvolle bewerking
                    this.Show();
                }
                else
                {
                    this.Show();
                }
            }
        }


        private void VerwijderButton_Click(object sender, RoutedEventArgs e)
        {
            if (PlayerList.SelectedItem is Speler speler && PlayerList.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Weet je zeker dat je deze speler wilt verwijderen?", "Verwijderen", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    UseDomainManager._manager.DeleteSpeler(speler.Id);
                    UpdateList();
                }
            }
        }

        private void SpelerListBoxSelected(object sender, SelectionChangedEventArgs e)
        {
            if (PlayerList.SelectedItem == null) // No one selected
            {
                BewerkButton.IsEnabled = false;
                VerwijderButton.IsEnabled = false;
            }
            else // Someone is selected
            {
                BewerkButton.IsEnabled = true;
                VerwijderButton.IsEnabled = true;
            }
        }

        private void UpdateList()
        {
            List<Speler> spelers = UseDomainManager._manager.GetAllSpelersByGroep(GeselecteerdeGroepClass.CurrentGroup);
            List<Speler> updatedAanwezigheidSpelers = UseDomainManager._manager.VulAanwezigheidsProcentIn(spelers);
            PlayerList.ItemsSource = updatedAanwezigheidSpelers;
            RugNummerList.ItemsSource = updatedAanwezigheidSpelers;
            AanwezigheidsProcentList.ItemsSource = updatedAanwezigheidSpelers;
        }

        // Synchroniseer scrollen bij ScrollChanged
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            // Controleer of de verandering afkomstig is van de NaamScrollViewer
            if (sender == NaamScrollViewer)
            {
                // Als de NaamScrollViewer verschuift, willen we dat de RugNrScrollViewer en AanwScrollViewer
                // hetzelfde doen. Dit gebeurt door de verticale offset van RugNrScrollViewer en AanwScrollViewer
                // gelijk te stellen aan de offset van NaamScrollViewer.
                RugNrScrollViewer.ScrollToVerticalOffset(e.VerticalOffset);
                AanwScrollViewer.ScrollToVerticalOffset(e.VerticalOffset);
            }
            // Controleer of de verandering afkomstig is van de RugNrScrollViewer
            else if (sender == RugNrScrollViewer)
            {
                // Als de RugNrScrollViewer verschuift, willen we dat de NaamScrollViewer en AanwScrollViewer
                // hetzelfde doen. Dit gebeurt door de verticale offset van NaamScrollViewer en AanwScrollViewer
                // gelijk te stellen aan de offset van RugNrScrollViewer.
                NaamScrollViewer.ScrollToVerticalOffset(e.VerticalOffset);
                AanwScrollViewer.ScrollToVerticalOffset(e.VerticalOffset);
            }
            // Controleer of de verandering afkomstig is van de AanwScrollViewer
            else if (sender == AanwScrollViewer)
            {
                // Als de AanwScrollViewer verschuift, willen we dat de NaamScrollViewer en RugNrScrollViewer
                // hetzelfde doen. Dit gebeurt door de verticale offset van NaamScrollViewer en RugNrScrollViewer
                // gelijk te stellen aan de offset van AanwScrollViewer.
                NaamScrollViewer.ScrollToVerticalOffset(e.VerticalOffset);
                RugNrScrollViewer.ScrollToVerticalOffset(e.VerticalOffset);
            }
        }

        // Synchroniseer scrollen bij muiswiel scrollen
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Controleer of het muiswiel is gebruikt op de NaamScrollViewer
            if (sender == NaamScrollViewer)
            {
                // Als het muiswiel naar beneden wordt gedraaid (Delta < 0), verschuif de RugNrScrollViewer en AanwScrollViewer naar beneden
                // Als het muiswiel naar boven wordt gedraaid (Delta > 0), verschuif de RugNrScrollViewer en AanwScrollViewer naar boven
                RugNrScrollViewer.ScrollToVerticalOffset(NaamScrollViewer.VerticalOffset + (e.Delta > 0 ? -20 : 20));
                AanwScrollViewer.ScrollToVerticalOffset(NaamScrollViewer.VerticalOffset + (e.Delta > 0 ? -20 : 20));
            }
            // Controleer of het muiswiel is gebruikt op de RugNrScrollViewer
            else if (sender == RugNrScrollViewer)
            {
                // Als het muiswiel naar beneden wordt gedraaid (Delta < 0), verschuif de NaamScrollViewer naar beneden
                // Als het muiswiel naar boven wordt gedraaid (Delta > 0), verschuif de NaamScrollViewer naar boven
                NaamScrollViewer.ScrollToVerticalOffset(RugNrScrollViewer.VerticalOffset + (e.Delta > 0 ? -20 : 20));
                RugNrScrollViewer.ScrollToVerticalOffset(RugNrScrollViewer.VerticalOffset + (e.Delta > 0 ? -20 : 20));
            }
            // Controleer of het muiswiel is gebruikt op de AanwScrollViewer
            else if (sender == AanwScrollViewer)
            {
                // Als het muiswiel naar beneden wordt gedraaid (Delta < 0), verschuif de NaamScrollViewer en RugNrScrollViewer naar beneden
                // Als het muiswiel naar boven wordt gedraaid (Delta > 0), verschuif de NaamScrollViewer en RugNrScrollViewer naar boven
                NaamScrollViewer.ScrollToVerticalOffset(AanwScrollViewer.VerticalOffset + (e.Delta > 0 ? -20 : 20));
                RugNrScrollViewer.ScrollToVerticalOffset(AanwScrollViewer.VerticalOffset + (e.Delta > 0 ? -20 : 20));
            }
        }

    }
}
