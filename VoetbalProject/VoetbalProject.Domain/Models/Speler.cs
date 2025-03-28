using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace VoetbalProject.Domain.Models
{
    public class Speler
    {
        public long Id { get; set; }
        private string _standaardVoornaam = "Jan";
        private string _standaardAchterNaam = "Janssens";
        private string _voornaam;
        private string _achternaam;
        private double _aanwezigheidsProcent;
        private long _rugNummer;

        public string Voornaam
        {
            get
            {
                return _voornaam;
            }
            set
            {
                if (value.Length > 15)
                {
                    throw new Exception("Voornaam mag niet langer zijn dan 15 karakters");
                }

                if (string.IsNullOrWhiteSpace(value))
                {
                    _voornaam = _standaardVoornaam;
                }
                else
                {
                    _voornaam = value;
                }
            }
        }
        public string Achternaam 
        {
            get
            {
                return _achternaam;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _achternaam = _standaardAchterNaam;
                }
                else
                {
                    _achternaam = value;
                }
            }
        }
        public string VolleNaam => $"{Voornaam} {Achternaam}";
        public long RugNummer
        {
            get
            {
                return _rugNummer;
            }
            set
            {
                if (value < 1 || value > 99)
                {
                    throw new Exception("Rugnummer moet tussen 1 en 99 liggen");
                }
                else
                {
                    _rugNummer = value;
                }
            }
        }
        public double AanwezigheidsProcent
        {
            get => _aanwezigheidsProcent;
            set => _aanwezigheidsProcent = Math.Round(value); // Rond af naar boven/benden gebaseerd op de input
        }
        public string GeformatteerdeProcent
        {
            get
            {
                if (_aanwezigheidsProcent == -1)
                {
                    return "n.v.t."; //geef niet van toepassing als er geen trainingen gelinked zijn
                }
                return $"{_aanwezigheidsProcent}%";
            }
        }


        public Speler(long id, string voornaam, string achternaam, long rugNummer)
        {
            Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            RugNummer = rugNummer;
        }

        public override string? ToString()
        {
            const int maxLength = 18; // Maximale lengte voor de volledige naam

            string fullName = $"{Voornaam} {Achternaam}"; // Samenvoegen van voornaam en achternaam in één string

            if (fullName.Length > maxLength) // Controleer of de lengte van de volledige naam groter is dan de maximale lengte
            {
                // Verkrijg de initialen van de achternaam
                string achternaamInitialen = string.Concat(Achternaam
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries) // Splits de achternaam op spaties en negeer lege waarden
                    .Select(word => word[0])); // Kies de eerste letter van elk woord in de achternaam

                // Verkort naar "Voornaam Initialen." (Voorbeeld: "Jan v. M.")
                return $"{Voornaam} {achternaamInitialen}.";
            }

            return fullName; // Als de volledige naam kort genoeg is, geef de volledige naam terug
        }


        public override bool Equals(object? obj)
        {
            return obj is Speler speler &&
                   Id == speler.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
