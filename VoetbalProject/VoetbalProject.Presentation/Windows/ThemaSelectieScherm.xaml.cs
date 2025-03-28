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
    /// Interaction logic for ThemaSelectieScherm.xaml
    /// </summary>
    public partial class ThemaSelectieScherm : Window
    {
        private string _formattedTime;
        private Button _previousButton;
        private string _thema;
        public ThemaSelectieScherm(string formattedTime)
        {
            InitializeComponent();
            _formattedTime = formattedTime;
            DatumText.Text = formattedTime;
            GroupName.Text = GeselecteerdeGroepClass.CurrentGroup.GroepNaam;
        }

        private void NavigateToNextWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                SchermManager.NavigateToNextWindow(this, button.Tag as string);
            }
        }

        private void ThemaButtonClicked(object sender, RoutedEventArgs e)  // hier gebruiken we de ChangeButtonStyle als er op een button wordt geklikt
        {                                                                  // en we passen de thema string aan naar de content van de button en zetten de andere textbox leeg
            if (sender is Button button)
            {
                ChangeButtonStyle(button);
                button.Background = Brushes.SpringGreen;
                _previousButton = button;

                _thema = button.Content.ToString();
                OtherTextBox.Text = "";
                VolgendeButton.IsEnabled = true;
            }
        }

        private void UserSelectesTextBox(object sender, RoutedEventArgs e) 
        {                                                                   
            if (sender is TextBox textBox)
            {
                ChangeButtonStyle(null); 
                VolgendeButton.IsEnabled = false;
            }
        }

        private void CheckOfUserInputNietLeegIs(object sender, RoutedEventArgs e) //checken of de textbox niet leeg is
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text.Length > 0)
                {
                    VolgendeButton.IsEnabled = true;
                    _thema = textBox.Text; // we passen de thema string aan naar de text in de textbox
                }
                else
                {
                    VolgendeButton.IsEnabled = false;
                }
            }
        }

        private void ChangeButtonStyle(Button button) // Als er op een thema button wordt geklikt wordt de button groen en de vorige button weer grijs
        {                                             // behalve bij de grijze button
            if (_previousButton != null)
            {
                if (_previousButton.Content.ToString() == "Geen thema")
                {
                    _previousButton.Background = Brushes.Gray;
                }
                else
                {
                    _previousButton.Background = Brushes.ForestGreen;
                }
            }
        }

        private void VolgendeButtonClicked(object sender, RoutedEventArgs e)
        {
            SchermManager.GoToMainWindow(this, _formattedTime, _thema);
        }
    }
}
