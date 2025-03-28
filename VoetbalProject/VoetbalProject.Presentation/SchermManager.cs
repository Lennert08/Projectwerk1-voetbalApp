using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VoetbalProject.Domain.Models;
using VoetbalProject.Presentation.Windows;

namespace VoetbalProject.Presentation
{
    internal static class SchermManager
    {

        public static void NavigateToNextWindow(Window huidigeScherm, string VolgendeScherm)
        {
            switch (VolgendeScherm)
            {
                case "HomeScherm":
                    GoToHomeScherm(huidigeScherm);
                    break;
                case "OverzichtScherm":
                    GoToOverzicht(huidigeScherm);
                    break;
                case "SpelerScherm":
                    GoToSpelerScherm(huidigeScherm);
                    break;
                case "GroepScherm":
                    GoToGroepenSelectieScherm(huidigeScherm);
                    break;
                case "SpelerAanmakenScherm":
                    GoToSpelerAanmakenScherm(huidigeScherm);
                    break;
                case "DatumTrainingScherm":
                    GoToDatumTrainingScherm(huidigeScherm);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Ongeldige scherm");
            }
        }
        public static void OpenGroepenSchermStartUp()
        {
            GroepenSelectieScherm GroepSelectieWindow = new GroepenSelectieScherm();
            GroepSelectieWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            GroepSelectieWindow.Show();
        }

        public static void GoToHomeScherm(Window huidigeScherm)
        {
            HomeScherm homeScherm = new HomeScherm();
            homeScherm.Left = huidigeScherm.Left;
            homeScherm.Top = huidigeScherm.Top;
            homeScherm.Show();
            huidigeScherm.Close();
        }

        public static void GoToOverzicht(Window huidigeScherm)
        {
            OverzichtScherm _overzichtScherm = new OverzichtScherm();
            _overzichtScherm.Left = huidigeScherm.Left;
            _overzichtScherm.Top = huidigeScherm.Top;
            _overzichtScherm.Show();
            huidigeScherm.Close();
        }

        public static void GoToSpelerScherm(Window huidigeScherm)
        {
            SpelerScherm spelerScherm = new SpelerScherm();
            spelerScherm.Left = huidigeScherm.Left;
            spelerScherm.Top = huidigeScherm.Top;
            spelerScherm.Show();
            huidigeScherm.Close();
        }

        public static void GoToGroepenSelectieScherm(Window huidigeScherm)
        {
            GroepenSelectieScherm groepenSelectieScherm = new GroepenSelectieScherm();
            groepenSelectieScherm.Left = huidigeScherm.Left;
            groepenSelectieScherm.Top = huidigeScherm.Top;
            groepenSelectieScherm.Show();
            huidigeScherm.Close();
        }

        public static void GoToDatumTrainingScherm(Window huidigeScherm)
        {
            DatumTrainingScherm datumTrainingScherm = new DatumTrainingScherm();
            datumTrainingScherm.Left = huidigeScherm.Left;
            datumTrainingScherm.Top = huidigeScherm.Top;
            datumTrainingScherm.Show();
            huidigeScherm.Close();
        }

        public static void GoToMainWindow(Window huidigeScherm, string geformateerdeTijd, string thema)
        {
            MainScherm mainScherm = new MainScherm(geformateerdeTijd, thema);
            mainScherm.Left = huidigeScherm.Left;
            mainScherm.Top = huidigeScherm.Top;
            mainScherm.Show();
            huidigeScherm.Close();
        }

        public static void GoToThemaScherm(Window huidigeScherm, string geformateerdeTijd)
        {
            ThemaSelectieScherm themaScherm = new ThemaSelectieScherm(geformateerdeTijd);
            themaScherm.Left = huidigeScherm.Left;
            themaScherm.Top = huidigeScherm.Top;
            themaScherm.Show();
            huidigeScherm.Close();
        }


        public static void GoToOverzichtSpelersWindow(Window huidigeScherm, Training training)
        {
            OverzichtSpelersScherm overzichtSpelersScherm = new OverzichtSpelersScherm(training);
            overzichtSpelersScherm.Left = huidigeScherm.Left;
            overzichtSpelersScherm.Top = huidigeScherm.Top;
            overzichtSpelersScherm.Show();
            huidigeScherm.Close();
        }

        public static bool? GoToSpelerAanmakenScherm(Window huidigeScherm)
        {
            SpelerAanmakenScherm afwezigheidScherm = new SpelerAanmakenScherm
            {
                Left = huidigeScherm.Left,
                Top = huidigeScherm.Top
            };

            huidigeScherm.Hide(); // Verberg de huidige window
            bool? resultaat = afwezigheidScherm.ShowDialog();

            if (resultaat != true)
            {
                huidigeScherm.Show(); // Laat de huidige window opnieuw zien als de dialoog wordt geannuleerd
            }

            return resultaat; // Geeft true, false of null terug afhankelijk van de dialoogresultaat
        }

        public static bool? GoToSpelerBewerkenScherm(Window huidigeScherm, Speler MeegegevenSpeler)
        {
            SpelerBewerkScherm spelerBewerkScherm = new SpelerBewerkScherm(MeegegevenSpeler)
            {
                Left = huidigeScherm.Left,
                Top = huidigeScherm.Top
            };

            huidigeScherm.Hide(); // Verberg de huidige window
            bool? resultaat = spelerBewerkScherm.ShowDialog();

            if (resultaat != true)
            {
                huidigeScherm.Show(); // Laat de huidige window opnieuw zien als de dialoog wordt geannuleerd
            }

            return resultaat; // Geeft true, false of null terug afhankelijk van de dialoogresultaat
        }

        public static bool? OpenAfwezigheidDialog(Window huidigeScherm, Speler speler, AfwezigheidScherm afwezigheidScherm)
        {
            afwezigheidScherm.Left = huidigeScherm.Left;
            afwezigheidScherm.Top = huidigeScherm.Top;

            afwezigheidScherm.SelectedPlayerText.Text = speler.ToString();
            huidigeScherm.Hide(); // Verberg de huidige window
            bool? resultaat = afwezigheidScherm.ShowDialog();

            if (resultaat != true)
            {
                huidigeScherm.Show(); // Laat de huidige window opnieuw zien als de dialoog wordt geannuleerd
            }

            return resultaat; // Geeft true, false of null terug afhankelijk van de dialoogresultaat
        }
    }
}
