using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoetbalProject.Domain.Models;

namespace VoetbalProject.Domain.Interfaces
{
    public interface IAanwezigheidInterface
    {
        void AddAanwezigheden(long trainingId, Dictionary<Speler, string> aanwezigheden, SQLiteTransaction transaction);
        Dictionary<Speler, string> GetAanwezighedenByTrainingId(long trainingId);
        double GetPercentageBySpeler(Speler speler);
        void UpdateAanwezigheidStatus(Speler speler, string oudeStatus, string nieuweStatus, Training training);
    }
}
