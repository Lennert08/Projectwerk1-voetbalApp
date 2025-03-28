using VoetbalProject.Domain;
using VoetbalProject.Presentation.Windows;

namespace VoetbalProject.Presentation
{
    public class VoetbalProjectApplicatie
    {
        public VoetbalProjectApplicatie (DomainManager domainManager)
        {
            UseDomainManager._manager = domainManager;
            SchermManager.OpenGroepenSchermStartUp();
            //RegistreerScherm scherm = new RegistreerScherm ();
            //scherm.Show();
        }

    }
}
