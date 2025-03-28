using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoetbalProject.Domain.Models
{
    public class Training
    {
        public long Id { get; set; }
        public DateOnly TrainingDatum { get; set; }
        public string Thema { get; set; }
        public Dictionary<Speler, string> AanwezigHeden { get; set; } // hier houden we de aanwezigheid van de spelers bij
        public Groep Groep { get; set; }
        public string GeformatteerdeDatum => TrainingDatum.ToString("dd/MM/yyyy");

        public Training(long id, DateOnly trainingDatum, string thema, Dictionary<Speler, string> aanwezigHeden, Groep groep)
        {
            Id = id;
            TrainingDatum = trainingDatum;
            Thema = thema;
            AanwezigHeden = aanwezigHeden;
            Groep = groep;
        }

        public Training(DateOnly trainingDatum, string thema, Dictionary<Speler, string> aanwezigHeden, Groep groep)
        {
            TrainingDatum = trainingDatum;
            Thema = thema;
            AanwezigHeden = aanwezigHeden;
            Groep = groep;
        }

        public override bool Equals(object? obj)
        {
            return obj is Training training &&
                   Id == training.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"{Thema}";
        }
    }
}
