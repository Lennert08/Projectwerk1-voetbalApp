using VoetbalProject.Domain.Models;
using VoetbalProject.Domain.Interfaces;
using System.Data.Entity.Migrations.Model;

namespace VoetbalProject.Domain
{
    public class DomainManager
    {
        private const double _heeftNooitGetraint = -1;
        private readonly IGroepInterface _groepInterface;
        private readonly ISpelerInterface _spelerInterface;
        private readonly ITrainingInterface _trainingInterface;
        private readonly IAanwezigheidInterface _aanwezigheidInterface;

        public DomainManager(IGroepInterface groepInterface, ISpelerInterface spelerInterface, ITrainingInterface trainingInterface, IAanwezigheidInterface aanwezigheidInterface)
        {
            _groepInterface = groepInterface;
            _spelerInterface = spelerInterface;
            _trainingInterface = trainingInterface;
            _aanwezigheidInterface = aanwezigheidInterface;
        }

        public List<Groep> GetAllGroepen()
        {
            return _groepInterface.GetGroepen();
        }

        public List<Speler> GetAllSpelersByGroep(Groep groep)
        {

            return _spelerInterface.GetAllPlayerByGroup(groep);
        }

        public void UpdateSpeler(long oldSpelerId, Speler newSpeler)
        {
            _spelerInterface.UpdateSpeler(oldSpelerId, newSpeler);
        }

        public void AddSpeler(Speler speler)
        {
            _spelerInterface.AddSpeler(speler);
        }

        public void VoegNieuweTrainingToe(Training training)
        {
            _trainingInterface.AddNewTraining(training);
        }

        public List<Training> GetAlleTrainingenByGroep(Groep groep)
        {
            return _trainingInterface.GetAllTrainingByGroup(groep);
        }

        public string Exporteer_NaarTextFile(Groep groep)
        {
            Dictionary<Speler, double> aanwezigheidPercentages = new();
            List<Speler> spelers = _spelerInterface.GetAllPlayerByGroup(groep);
            foreach (Speler speler in spelers)
            {
                double percentage = _aanwezigheidInterface.GetPercentageBySpeler(speler);
                if (percentage != _heeftNooitGetraint)
                {
                    aanwezigheidPercentages.Add(speler, percentage);
                }
            }

            List<string> lines = new List<string>
            {
                "Naam;Percentage"
            };

            foreach (var aanwezigheidLine in aanwezigheidPercentages)
            {
                string line = $"{aanwezigheidLine.Key.VolleNaam};{aanwezigheidLine.Value:F2}";
                lines.Add(line);
            }

            return string.Join("\n", lines);
        }

        public void DeleteTraining(Training training)
        {
            _trainingInterface.DeleteTraining(training);
        }

        public void DeleteSpeler(long spelerId)
        {
            _spelerInterface.DeleteSpeler(spelerId);
        }

        public void VerwijderSpelerUitTraining(Training training, Speler speler)
        {
            _trainingInterface.VerwijderSpelerUitTraining(training, speler);
        }

        public Training GetTrainingById(long trainingId)
        {
            return _trainingInterface.GetTrainingById(trainingId);
        }

        public Training GetTrainingByDatum(DateOnly trainingDatum, string groepNaam)
        {
            return _trainingInterface.GetTrainingByDatum(trainingDatum,groepNaam);
        }

        public void UpdateAanwezigheidStatus(Speler speler, string oudeStatus, string nieuweStatus, Training training)
        {
            _aanwezigheidInterface.UpdateAanwezigheidStatus(speler, oudeStatus, nieuweStatus, training);
        }
        public List<Speler> VulAanwezigheidsProcentIn(List<Speler> spelers)
        {
            foreach (Speler speler in spelers)
            {
                double percentage = _aanwezigheidInterface.GetPercentageBySpeler(speler);
                speler.AanwezigheidsProcent = percentage;
            }
            return spelers;
        }
        public int GetGroupSpelerCount(Groep groep)
        {
            return _groepInterface.GetGroupSpelerCount(groep);
        }
        public Speler GetSpelerById(long spelerId)
        {
            return _spelerInterface.GetSpelerById(spelerId);
        }
    }
}
