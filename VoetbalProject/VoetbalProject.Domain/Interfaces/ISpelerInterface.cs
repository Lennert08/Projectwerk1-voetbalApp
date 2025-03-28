using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoetbalProject.Domain.Models;

namespace VoetbalProject.Domain.Interfaces
{
    public interface ISpelerInterface
    {
        void AddSpeler(Speler speler);
        void UpdateSpeler(long oldSpelerId, Speler newSpeler);
        List<Speler> GetAllPlayerByGroup(Groep group);

        void DeleteSpeler(long spelerId);
        Speler GetSpelerById(long spelerId);
    }
}
