using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using VoetbalProject.Domain.Models;

namespace VoetbalProject.Presentation.Windows
{
    public partial class DatumTrainingScherm : Window
    {
        // De lijst met trainingsdatums
        public static List<DateTime> TrainingDatums = new List<DateTime>
        {
            new DateTime(2024, 12, 10),
            new DateTime(2024, 12, 15),
            new DateTime(2024, 12, 20)
        };

        public DatumTrainingScherm()
        {
            InitializeComponent();
            GroepNaam.Text = GeselecteerdeGroepClass.CurrentGroup.GroepNaam;
        }


        // Gebeurtenis voor de selectie van datums
        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is Calendar calendar)
            {
                DateTime? time = calendar.SelectedDate;
                if (time != null)
                {
                    DateOnly dateOnly = DateOnly.FromDateTime(time.Value);
                    Training traininToCheck = UseDomainManager._manager.GetTrainingByDatum(dateOnly, GeselecteerdeGroepClass.CurrentGroup.GroepNaam);

                    if (time.Value.Date > DateTime.Now.Date)
                    {
                        MessageBox.Show(
                            "Je kunt geen toekomstige datums selecteren.", // Bericht
                            "Ongeldige Datum", // Titel van de MessageBox
                            MessageBoxButton.OK, // Opties voor de gebruiker
                            MessageBoxImage.Warning); // Pictogram voor waarschuwing
                        return; // Stop de methode
                    }

                    if (traininToCheck == null)
                    {
                        string formattedTime = time.Value.ToString("dd-MM-yyyy"); //formatteert de string in dag/maand/jaar formaat
                        SchermManager.GoToThemaScherm(this, formattedTime);
                    } else
                    {
                        MessageBoxResult result = MessageBox.Show(
                        "Deze training bestaat al. Wil je hier naartoe gaan?", // Bericht
                        "Training Bestaand", // Titel van de MessageBox
                        MessageBoxButton.YesNo, // Opties voor de gebruiker
                        MessageBoxImage.Question); // Pictogram voor de vraag

                        if (result == MessageBoxResult.Yes)
                        {
                            SchermManager.GoToOverzichtSpelersWindow(this, traininToCheck);
                        } 
                    }
                }
            }
        }
    }
}
