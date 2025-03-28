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

namespace VoetbalProject.Presentation.Windows
{
    /// <summary>
    /// Interaction logic for AfwezigheidScherm.xaml
    /// </summary>
    public partial class AfwezigheidScherm : Window
    {
        public string AfwezigheidReden { get; set; }
        public AfwezigheidScherm(bool isEditMode)
        {
            InitializeComponent();
            if (isEditMode) // dit zorgt ervoor dat de aanwezig button er is als we in edit mode zijn
            {
                AanwezigTextBlock.Visibility = Visibility.Visible;
                AanwezigRadioButton.Visibility = Visibility.Visible;
                OtherTextBox.Height = 45; // textblock beneden verkleinen voor meer plaats
            }
        }

        private void RedenButtonSelected(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton)
            {
                AfwezigheidReden = radioButton.Tag.ToString();
                SaveButton.IsEnabled = true;
                OtherTextBox.IsEnabled = false;
                OtherTextBox.Text = ""; // tekst van overige reden leegmaken
            } 
        }
        private void OtherButtonSelected(object sender, RoutedEventArgs e)
        {
            SaveButton.IsEnabled = true;
            OtherTextBox.IsEnabled = true;
        }

        private void SaveButtonClicked(object sender, RoutedEventArgs e)
        {
            if (OtherTextBox.IsEnabled)
            {
                AfwezigheidReden = OtherTextBox.Text;
            }
            this.DialogResult = true;
            this.Close();
        }
    }
}
