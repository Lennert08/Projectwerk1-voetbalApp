using VoetbalProject.Domain.Models;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Vergelijkt_Groepen()
        {
            // Test dat CompareTo een negatieve waarde gaat geven als groepA alfabetisch voor groepB komt
            var groepA = new Groep("Barcelona");
            var groepB = new Groep("Real madrid");

            var resultaat = groepA.CompareTo(groepB);

            Assert.True(resultaat < 0);
        }

        [Fact]
        public void ToString_GeeftGroepNaam()
        {
            // Test dat ToString() de juiste groepsnaam terug geeft
            var groep = new Groep("GroepA");

            var resultaat = groep.ToString();

            Assert.Equal("GroepA", resultaat);
        }

        [Fact]
        public void ToString_GeeftVolledigeNaam()
        {
            // Test dat ToString() de volledige naam van een speler terug geeft
            var speler = new Speler(1, "Majdi", "Salem", 10);

            var resultaat = speler.ToString();

            Assert.Equal("Majdi Salem", resultaat);
        }

        [Fact]
        public void ToString_GeeftAfgekorteNaam()
        {
            // Test dat lange achternamen correct worden afgekort
            var speler = new Speler(1, "Majdi", "Salem Idrees Ramadan", 10);

            var resultaat = speler.ToString();

            Assert.Equal("Majdi SIR.", resultaat);
        }

        [Fact]
        public void Spelers_ZijnGelijkOpId()
        {
            // Test dat twee spelers met dezelfde Id als gelijk worden beschouwd
            var speler1 = new Speler(1, "Mikail", "Shaun", 10);
            var speler2 = new Speler(1, "John", "Smith", 11);

            var resultaat = speler1.Equals(speler2);

            Assert.True(resultaat);
        }

        [Fact]
        public void Spelers_ZijnNietGelijkOpId()
        {
            // Test dat twee spelers met verschillende Id's niet als gelijk worden beschouwd
            var speler1 = new Speler(1, "Jane", "Smith", 10);
            var speler2 = new Speler(2, "Jane", "Smith", 10);

            var resultaat = speler1.Equals(speler2);

            Assert.False(resultaat);
        }

        [Fact]
        public void HashCode_IsGelijkVoorZelfdeId()
        {
            // Test dat spelers met dezelfde Id dezelfde hashcode hebben
            var speler1 = new Speler(1, "Lennert", "Salem", 10);
            var speler2 = new Speler(1, "Lennert", "Idrees", 11);

            var hash1 = speler1.GetHashCode();
            var hash2 = speler2.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        [Fact]
        public void HuidigeGroep_WerktCorrect()
        {
            // Test dat de huidige groep correct wordt opgeslagen in het GeselecteerdeGroepClass
            var groep = new Groep("GroepA");

            GeselecteerdeGroepClass.CurrentGroup = groep;

            Assert.Equal(groep, GeselecteerdeGroepClass.CurrentGroup);
        }


        [Fact]
        public void Speler_LegeVelden()
        {
            // Test op Speler met lege velden
            var speler = new Speler(1, "", "", 10);

            Assert.Equal("Jan Janssens", speler.ToString()); // moet standaard naam geven
            Assert.NotNull(speler);
        }
    }
}