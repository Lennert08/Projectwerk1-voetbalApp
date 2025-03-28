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
    /// Interaction logic for OverzichtScherm.xaml
    /// </summary>
    public partial class OverzichtScherm : Window
    {
        private OverzichtSpelersScherm _overzichtSpelersWindow;
        public OverzichtScherm()
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

        private void TraininInfoListItemClicked(object sender, MouseButtonEventArgs e)
        {
            if (TrainingInfoList.SelectedItem is Training training && TrainingInfoList.SelectedItem != null)
            {
                SchermManager.GoToOverzichtSpelersWindow(this, training);
            }
        }

        private void SpelerListBoxSelected(object sender, SelectionChangedEventArgs e)
        {
            if (TrainingInfoList.SelectedItem == null) // No one selected
            {
                VerwijderButton.IsEnabled = false;
            }
            else // Someone is selected
            {
                VerwijderButton.IsEnabled = true;
            }
        }

        private void VerwijderButtonClicked(object sender, RoutedEventArgs e)
        {
            if (TrainingInfoList.SelectedItem is Training training && TrainingInfoList.SelectedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Weet je zeker dat je deze training wilt verwijderen?", "Verwijderen", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    UseDomainManager._manager.DeleteTraining(training);
                    UpdateList();
                }
            }
        }

        private void UpdateList()
        {
            List<Training> trainingList = UseDomainManager._manager.GetAlleTrainingenByGroep(GeselecteerdeGroepClass.CurrentGroup);
            TrainingenDatumList.ItemsSource = trainingList;
            TrainingInfoList.ItemsSource = trainingList;
        }






        // Synchroniseer scrollen bij ScrollChanged
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            // Controleer of de verandering afkomstig is van de DatumScrollViewer
            if (sender == DatumScrollViewer)
            {
                // Als de DatumScrollViewer verschuift, willen we dat de ThemaScrollViewer
                // hetzelfde doet. Dit gebeurt door de verticale offset van ThemaScrollViewer
                // gelijk te stellen aan de offset van DatumScrollViewer.
                ThemaScrollViewer.ScrollToVerticalOffset(e.VerticalOffset);
            }
            // Controleer of de verandering afkomstig is van de ThemaScrollViewer
            else if (sender == ThemaScrollViewer)
            {
                // Als de ThemaScrollViewer verschuift, willen we dat de DatumScrollViewer
                // hetzelfde doet. Dit gebeurt door de verticale offset van DatumScrollViewer
                // gelijk te stellen aan de offset van ThemaScrollViewer.
                DatumScrollViewer.ScrollToVerticalOffset(e.VerticalOffset);
            }
        }


        // Synchroniseer scrollen bij muiswiel scrollen
        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            // Controleer of het muiswiel is gebruikt op de DatumScrollViewer
            if (sender == DatumScrollViewer)
            {
                // Als het muiswiel naar beneden wordt gedraaid (Delta < 0), verschuif de ThemaScrollViewer naar beneden
                // Als het muiswiel naar boven wordt gedraaid (Delta > 0), verschuif de ThemaScrollViewer naar boven
                ThemaScrollViewer.ScrollToVerticalOffset(DatumScrollViewer.VerticalOffset + (e.Delta > 0 ? -20 : 20));
            }
            // Controleer of het muiswiel is gebruikt op de ThemaScrollViewer
            else if (sender == ThemaScrollViewer)
            {
                // Als het muiswiel naar beneden wordt gedraaid (Delta < 0), verschuif de DatumScrollViewer naar beneden
                // Als het muiswiel naar boven wordt gedraaid (Delta > 0), verschuif de DatumScrollViewer naar boven
                DatumScrollViewer.ScrollToVerticalOffset(ThemaScrollViewer.VerticalOffset + (e.Delta > 0 ? -20 : 20));
            }
        }
    }
}
