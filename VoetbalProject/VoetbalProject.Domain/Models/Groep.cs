using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoetbalProject.Domain.Models
{
    public class Groep : IComparable<Groep>
    {
        private string groepNaam;
        private List<Speler> _spelers;

        public string GroepNaam { get => groepNaam; set => groepNaam = value; }

        public Groep(string groepNaam)
        {
            GroepNaam = groepNaam;
        }

        

        public override string? ToString()
        {
            return GroepNaam;
        }
        public int CompareTo(Groep other)
        {
            return groepNaam.CompareTo(other.groepNaam); //compareToMethod
        }

        public override bool Equals(object? obj)
        {
            return obj is Groep groep &&
                   groepNaam == groep.groepNaam &&
                   EqualityComparer<List<Speler>>.Default.Equals(_spelers, groep._spelers) &&
                   GroepNaam == groep.GroepNaam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(groepNaam, _spelers, GroepNaam);
        }
    }

}
