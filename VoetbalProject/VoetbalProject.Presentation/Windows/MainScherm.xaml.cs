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
    /// Interaction logic for MainScherm.xaml
    /// </summary>
    public partial class MainScherm : Window
    {
        private AfwezigheidScherm _afwezigheidWindow;
        private Dictionary<Speler, string> _aanwezigheden = new();
        private DateOnly _trainingDatum;
        private Speler _selectedSpeler;
        private string _thema = "Geen thema";
        public MainScherm(string formattedTime,string thema)
        {
            InitializeComponent();
            List<Speler> spelers = UseDomainManager._manager.GetAllSpelersByGroep(GeselecteerdeGroepClass.CurrentGroup);
            PlayerList.ItemsSource = spelers;
            _trainingDatum = DateOnly.FromDateTime(DateTime.Parse(formattedTime));
            DatumText.Text = formattedTime;
            GroupName.Text = GeselecteerdeGroepClass.CurrentGroup.GroepNaam;
            ThemaText.Text = thema;
            _thema = thema;

            foreach (Speler speler in spelers)
            {
                _aanwezigheden[speler] = "Aanwezig"; // zet elke speler automatic op aanwezig
            }
        }


        private void AanwezigheidsWindowClicked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                // Haal het Speler-object op uit de DataContext van de RadioButton (dataContext is voor het object uit de datatemplate te halen)
                if (radioButton != null && radioButton.DataContext is Speler speler)
                {
                    if (_aanwezigheden.ContainsKey(speler))
                    {
                        _aanwezigheden[speler] = "Aanwezig"; // Speler aanwezig zetten
                    }

                }
            }
        }

        private void AfwezigheidsRadioButtonClicked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                // Haal het Speler-object op uit de DataContext van de RadioButton (dataContext is voor het object uit de datatemplate te halen)
                if (radioButton != null && radioButton.DataContext is Speler speler)
                {
                    _selectedSpeler = speler;
                    AfwezigheidScherm afwezigheidScherm = new(false);
                    bool? SuccesfullyCLickedOnSave = SchermManager.OpenAfwezigheidDialog(this, speler, afwezigheidScherm);

                    if (SuccesfullyCLickedOnSave == true)
                    {
                        if (_aanwezigheden.ContainsKey(speler))
                        {
                            _aanwezigheden[speler] = afwezigheidScherm.AfwezigheidReden; // Speler afewezig zetten met reden
                        }
                        this.Show();
                    }
                    else
                    {
                        this.Show();
                        radioButton.IsChecked = false;
                    }

                }
            }
        }
        private void SavePlayerAanwezighedenButton(object sender, RoutedEventArgs e)
        {
            Training training = new(_trainingDatum, _thema, _aanwezigheden, GeselecteerdeGroepClass.CurrentGroup);
            UseDomainManager._manager.VoegNieuweTrainingToe(training);
            SchermManager.GoToHomeScherm(this);
        }


        private void NavigateToNextWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                SchermManager.NavigateToNextWindow(this, button.Tag as string);
            }
        }


    }
}
