using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoetbalProject.Domain.Models;
using VoetbalProject.Domain.Interfaces;

namespace VoetbalProject.Persistence.Repositories
{
    public class GroepRepository : IGroepInterface
    {
        private const string _tableName = "Groep";
        private static readonly string _connectionString = DbInfo.ConnectionString;
        private SpelerRepository _spelerMapper = new SpelerRepository();

        public List<Groep> GetGroepen()
        {
            List<Groep> groepen = new List<Groep>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT GroepNaam FROM Groep";  // We halen alleen GroepNaam op

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string groepNaam = (string)reader["GroepNaam"];

                                // Maak een Groep object met alleen de GroepNaam
                                Groep groep = new Groep(groepNaam);
                                groepen.Add(groep);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van groepen: {ex.Message}");
            }

            return groepen;
        }


        public Groep GetGroepById(long groepId)
        {
            Groep groep = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = $@"
                    SELECT g.GroepNaam
                    FROM {_tableName} g
                    WHERE g.Id = @GroepId";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GroepId", groepId);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string groepNaam = (string)reader["GroepNaam"];
                                groep = new Groep(groepNaam);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van de groep: {ex.Message}");
            }
            return groep;
        }

        public int GetGroupSpelerCount(Groep groep)
        {
            int spelerCount = 0;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = $@"
                    SELECT COUNT(*) AS SpelerCount
                    FROM Speler s
                    INNER JOIN Groep g ON s.GroepId = g.Id
                    WHERE g.GroepNaam = @GroepNaam
                    AND s.IsDeleted = false"; // Alleen checken of de speler niet verwijderd is

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GroepNaam", groep.GroepNaam);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                spelerCount = reader.GetInt32(0); // Het eerste veld bevat het aantal spelers
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van het aantal spelers in de groep '{groep.GroepNaam}': {ex.Message}");
            }

            return spelerCount;
        }



    }
}
