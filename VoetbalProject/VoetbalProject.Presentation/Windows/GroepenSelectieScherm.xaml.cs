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
    /// Interaction logic for GroepenSelectieScherm.xaml
    /// </summary>
    public partial class GroepenSelectieScherm : Window
    {
       
        public GroepenSelectieScherm()
        {
            InitializeComponent();
            ListGroepen.ItemsSource = UseDomainManager._manager.GetAllGroepen(); //vul list in van groepen via de mapper
        }

        private void ListGroepen_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (sender is ListBox list && list.SelectedItem != null)
            {
                if (list.SelectedItem is Groep selectedGroup)
                {
                    Groep group = new(selectedGroup.GroepNaam);
                    GeselecteerdeGroepClass.CurrentGroup = group;
                    SchermManager.GoToHomeScherm(this);
                }
            }
        }
    }
}
