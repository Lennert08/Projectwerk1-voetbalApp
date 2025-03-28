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
    /// Interaction logic for OverzichtSpelersScherm.xaml
    /// </summary>
    /// 
    public partial class OverzichtSpelersScherm : Window
    {
        private Training _training;
        public OverzichtSpelersScherm(Training training)
        {
            InitializeComponent();
            _training = training;
            TrainingThemaTitel.Text = training.Thema;
            DatumText.Text = training.GeformatteerdeDatum;
            UpdateLists();
        }

        private void NavigateToNextWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                SchermManager.NavigateToNextWindow(this, button.Tag as string);
            }
        }

        private void SelectionChangedListBox(object sender, SelectionChangedEventArgs e)
        {
            // Zorg ervoor dat de VerwijderButton alleen ingeschakeld is als een speler is geselecteerd in de PlayerList
            if (PlayerList.SelectedItem == null) // Geen selectie
            {
                VerwijderButton.IsEnabled = false;
            }
            else // Er is een selectie (speler)
            {
                VerwijderButton.IsEnabled = true;
            }
            AanwezigheidList.SelectedItem = null; // zorgt ervoor dat de AanwezigheidList geen selectie heeft
        }


        private void AanwezigheidList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Zorg ervoor dat de VerwijderButton altijd uitgeschakeld is bij selectie in AanwezigheidList
            VerwijderButton.IsEnabled = false;
            PlayerList.SelectedItem = null; // zorgt ervoor dat de AanwezigheidList geen selectie heeft
        }




        private void VerwijderButtonClicked(object sender, RoutedEventArgs e)
        {
            // Krijg de geselecteerde speler uit de PlayerList (dit is een Key-Value pair)
            if (PlayerList.SelectedItem is KeyValuePair<Speler, string> selectedItem)
            {
                Speler speler = selectedItem.Key;

                MessageBoxResult result = MessageBox.Show("Weet je zeker dat je deze speler wilt verwijderen?", "Verwijderen", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    UseDomainManager._manager.VerwijderSpelerUitTraining(_training, speler);
                    UpdateLists();
                }
            }
        }

        private void UpdateLists()
        {
            _training = UseDomainManager._manager.GetTrainingById(_training.Id);

            // Direct de Dictionary gebruiken als ItemsSource
            PlayerList.ItemsSource = _training.AanwezigHeden;
            AanwezigheidList.ItemsSource = _training.AanwezigHeden;
        }

        private void AanwezigheidList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (AanwezigheidList.SelectedItem is KeyValuePair<Speler, string> selectedItem)
            {
                Speler speler = selectedItem.Key;
                string oudeStatus = selectedItem.Value;
                AfwezigheidScherm afwezigheidScherm = new AfwezigheidScherm(true);
                bool? isGelukt = SchermManager.OpenAfwezigheidDialog(this, speler, afwezigheidScherm);

                if (isGelukt == true)
                {
                    UseDomainManager._manager.UpdateAanwezigheidStatus(speler, oudeStatus, afwezigheidScherm.AfwezigheidReden, _training);
                    UpdateLists();
                    this.Show();
                } else
                {
                    this.Show();
                }
            }
        }

        // Synchroniseer scrollen bij ScrollChanged
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            // Controleer of de verandering afkomstig is van de NaamScrollViewer
            if (sender == NaamScrollViewer)
            {
                // Als de NaamScrollViewer verschuift, willen we dat de StatusScrollViewer
                // hetzelfde doet. Dit gebeurt door de verticale offset van StatusScrollViewer
                // gelijk te stellen aan de offset van NaamScrollViewer.
                StatusScrollViewer.ScrollToVerticalOffset(e.VerticalOffset);
            }
            // Controleer of de verandering afkomstig is van de StatusScrollViewer
            else if (sender == StatusScrollViewer)
            {
                // Als de StatusScrollViewer verschuift, willen we dat de NaamScrollViewer
                // hetzelfde doet. Dit gebeurt door de verticale offset van NaamScrollViewer
                // gelijk te stellen aan de offset van StatusScrollViewer.
                NaamScrollViewer.ScrollToVerticalOffset(e.VerticalOffset);
            }
        }

        // Synchroniseer scrollen bij muiswiel scrollen
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Controleer of het muiswiel is gebruikt op de NaamScrollViewer
            if (sender == NaamScrollViewer)
            {
                // Als het muiswiel naar beneden wordt gedraaid (Delta < 0), verschuif de StatusScrollViewer naar beneden
                // Als het muiswiel naar boven wordt gedraaid (Delta > 0), verschuif de StatusScrollViewer naar boven
                StatusScrollViewer.ScrollToVerticalOffset(NaamScrollViewer.VerticalOffset + (e.Delta > 0 ? -20 : 20));
            }
            // Controleer of het muiswiel is gebruikt op de StatusScrollViewer
            else if (sender == StatusScrollViewer)
            {
                // Als het muiswiel naar beneden wordt gedraaid (Delta < 0), verschuif de NaamScrollViewer naar beneden
                // Als het muiswiel naar boven wordt gedraaid (Delta > 0), verschuif de NaamScrollViewer naar boven
                NaamScrollViewer.ScrollToVerticalOffset(StatusScrollViewer.VerticalOffset + (e.Delta > 0 ? -20 : 20));
            }
        }

    }
}
