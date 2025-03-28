using System.Configuration;
using System.Data;
using System.Windows;
using VoetbalProject.Domain;
using VoetbalProject.Domain.Interfaces;
using VoetbalProject.Persistence;
using VoetbalProject.Persistence.Repositories;
using VoetbalProject.Presentation;

namespace VoetbalProject.Startup
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application //test
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {

            //UseDomainManager._manager = 
            //Persistence Layer
            ISpelerInterface spelerInterface = new SpelerRepository();
            IGroepInterface groepInterface = new GroepRepository();
            ITrainingInterface trainingInterface = new TrainingRepository();
            IAanwezigheidInterface aanwezigheidInterface = new AanwezigheidRepository();


            //Domain Layer
            DomainManager domainManager = new(groepInterface,spelerInterface,trainingInterface,aanwezigheidInterface);

            //Presentation Layer
            VoetbalProjectApplicatie voetbalProjectApplicatie = new(domainManager);


        }
    }

}
