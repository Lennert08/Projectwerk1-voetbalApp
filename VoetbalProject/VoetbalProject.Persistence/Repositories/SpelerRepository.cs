using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoetbalProject.Domain.Models;
using VoetbalProject.Domain.Interfaces;

namespace VoetbalProject.Persistence.Repositories
{
    public class SpelerRepository : ISpelerInterface
    {
        private const string _tableName = "Speler";
        private static readonly string _connectionString = DbInfo.ConnectionString;

        public List<Speler> GetAllPlayerByGroup(Groep group)
        {
            List<Speler> Result = new();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = $@"
                    SELECT s.Id, s.Voornaam, s.Achternaam, s.RugNummer
                    FROM {_tableName} s
                    INNER JOIN Groep g ON s.GroepId = g.Id
                    WHERE g.GroepNaam = @GroepNaam AND s.IsDeleted = 0;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GroepNaam", group.GroepNaam);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    long id = (long)reader["Id"];
                                    string voornaam = (string)reader["Voornaam"];
                                    string achternaam = (string)reader["Achternaam"];
                                    long rugNummer = (long)reader["RugNummer"];

                                    Speler speler = new(id, voornaam, achternaam, rugNummer);
                                    Result.Add(speler);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Fout bij het laden van de database: " + ex.Message);
            }

            return Result;
        }

        public void AddSpeler(Speler speler)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string query = $@"
                    INSERT INTO {_tableName} (Voornaam, Achternaam, RugNummer, GroepId) 
                    VALUES (@Voornaam, @Achternaam, @RugNummer, 
                    (SELECT Id FROM Groep WHERE GroepNaam = @GroepNaam));";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Voornaam", speler.Voornaam);
                        command.Parameters.AddWithValue("@Achternaam", speler.Achternaam);
                        command.Parameters.AddWithValue("@RugNummer", speler.RugNummer);
                        command.Parameters.AddWithValue("@GroepNaam", GeselecteerdeGroepClass.CurrentGroup.GroepNaam);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het toevoegen van de speler: {ex.Message}");
            }
        }

        public void UpdateSpeler(long oldSpelerId, Speler newSpeler)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Query om de spelergegevens bij te werken
                    string query = $@"
                    UPDATE {_tableName} 
                    SET 
                    Voornaam = @NieuweVoornaam,
                    Achternaam = @NieuweAchternaam,
                    RugNummer = @NieuweRugNummer,
                    GroepId = (SELECT Id FROM Groep WHERE GroepNaam = @GroepNaam)
                    WHERE 
                    Id = @SpelerId;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Parametriseer de query
                        command.Parameters.AddWithValue("@NieuweVoornaam", newSpeler.Voornaam);
                        command.Parameters.AddWithValue("@NieuweAchternaam", newSpeler.Achternaam);
                        command.Parameters.AddWithValue("@NieuweRugNummer", newSpeler.RugNummer);
                        command.Parameters.AddWithValue("@GroepNaam", GeselecteerdeGroepClass.CurrentGroup.GroepNaam);
                        command.Parameters.AddWithValue("@SpelerId", oldSpelerId);

                        // Voer de update uit
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het bijwerken van de speler: {ex.Message}");
            }
        }

        public void DeleteSpeler(long spelerId)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = $@"
                    UPDATE {_tableName} 
                    SET IsDeleted = 1
                    WHERE Id = @SpelerId;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SpelerId", spelerId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het verwijderen van de speler: {ex.Message}");
            }
        }

        public Speler GetSpelerById(long spelerId)
        {
            Speler speler = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = $@"SELECT Id, Voornaam, Achternaam, RugNummer FROM {_tableName} WHERE Id = @SpelerId AND IsDeleted = 0;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@SpelerId", spelerId);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows && reader.Read())
                            {
                                long id = (long)reader["Id"];
                                string voornaam = (string)reader["Voornaam"];
                                string achternaam = (string)reader["Achternaam"];
                                long rugNummer = (long)reader["RugNummer"];

                                speler = new Speler(id, voornaam, achternaam, rugNummer);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van de speler: {ex.Message}");
            }

            return speler;
        }
    }
}
