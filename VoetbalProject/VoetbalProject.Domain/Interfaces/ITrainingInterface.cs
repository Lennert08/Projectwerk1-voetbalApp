using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoetbalProject.Domain.Models;

namespace VoetbalProject.Domain.Interfaces
{
    public interface ITrainingInterface
    {
        void AddNewTraining(Training training);
        List<Training> GetAllTrainingByGroup(Groep groep);
        void DeleteTraining(Training training);
        void VerwijderSpelerUitTraining(Training training, Speler speler);
        Training GetTrainingById(long trainingId);
        Training GetTrainingByDatum(DateOnly trainingDatum, string groepNaam);
    }
}
