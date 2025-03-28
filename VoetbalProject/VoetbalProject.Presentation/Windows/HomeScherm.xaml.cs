using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for HomeScherm.xaml
    /// </summary>
    public partial class HomeScherm : Window
    {
        private SpelerAanmakenScherm _aanmaakSpeler;
        public HomeScherm()
        {
            InitializeComponent();
            groeplabel.Content = GeselecteerdeGroepClass.CurrentGroup;
        }
        //public HomeWindow(string groep, GroepenSelectieScherm groepenscherm)
        //{
        //    InitializeComponent();
        //    groeplabel.Content = groep;
        //    _groepenwindow = groepenscherm;
        //} Wordt momenteel nooit gebruikt
        private void NavigateToNextWindow(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                SchermManager.NavigateToNextWindow(this, button.Tag as string);
            }
        }

        private void Exporteer_NaarTekstFile(object sender, RoutedEventArgs e)
        {
            if(sender is Button button)
            {
                string export = UseDomainManager._manager.Exporteer_NaarTextFile(GeselecteerdeGroepClass.CurrentGroup);

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        File.WriteAllText(filePath, export);

                        MessageBox.Show(
                            "Het bestand is succesvol opgeslagen!",
                            "Succes",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information
                        );
                    }
                    catch
                    {
                        MessageBox.Show(
                            "Er is een fout opgetreden tijdens het opslaan van het bestand. Controleer of de locatie toegankelijk is en probeer het opnieuw.",
                            "Fout",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                        );
                    }
                }

            }
        }
        
    }
}
