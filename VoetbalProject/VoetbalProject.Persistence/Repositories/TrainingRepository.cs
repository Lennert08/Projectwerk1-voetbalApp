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
    public class TrainingRepository : ITrainingInterface
    {
        private const string _tableName = "Training";
        private static readonly string _connectionString = DbInfo.ConnectionString;
        private AanwezigheidRepository _aanwezigheidMapper = new AanwezigheidRepository();
        private GroepRepository _groepMapper = new GroepRepository();

        public void AddNewTraining(Training training)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Start een transactie
                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Query om de training in de Training tabel in te voegen
                            string query = $@"
                            INSERT INTO {_tableName} (TrainingDatum, ThemaNaam, GroepId) 
                            VALUES (@TrainingDatum, 
                            @ThemaNaam, 
                            (SELECT Id FROM Groep WHERE GroepNaam = @GroepNaam));";

                            using (SQLiteCommand command = new SQLiteCommand(query, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@TrainingDatum", training.TrainingDatum.ToString("yyyy-MM-dd"));
                                command.Parameters.AddWithValue("@ThemaNaam", training.Thema);
                                command.Parameters.AddWithValue("@GroepNaam", training.Groep.GroepNaam);

                                // Voer de query uit om de training toe te voegen
                                command.ExecuteNonQuery();
                            }

                            // Haal de laatst toegevoegde Id op
                            string idQuery = "SELECT last_insert_rowid();";
                            long trainingId;
                            using (SQLiteCommand idCommand = new SQLiteCommand(idQuery, connection, transaction))
                            {
                                trainingId = (long)idCommand.ExecuteScalar(); // Haal de Id op
                            }

                            // Nu kunnen we de aanwezigheid toevoegen met de juiste Id
                            _aanwezigheidMapper.AddAanwezigheden(trainingId, training.AanwezigHeden, transaction);

                            // Commit de transactie als alles succesvol is
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Rollback de transactie als er een fout optreedt
                            transaction.Rollback();
                            throw new Exception($"Fout bij het toevoegen van de training: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het openen van de database: {ex.Message}");
            }
        }



        public List<Training> GetAllTrainingByGroup(Groep group)
        {
            List<Training> result = new List<Training>();

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Query om trainingen op te halen voor de opgegeven groep, met ThemaNaam als string
                    string query = $@"
                    SELECT t.Id, t.TrainingDatum, t.ThemaNaam, t.GroepId
                    FROM {_tableName} t
                    INNER JOIN Groep g ON t.GroepId = g.Id
                    WHERE g.GroepNaam = @GroepNaam
                    ORDER BY TrainingDatum DESC;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GroepNaam", group.GroepNaam);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                long id = (long)reader["Id"];
                                DateOnly trainingDatum = DateOnly.Parse((string)reader["TrainingDatum"]); // Aangepast naar DateOnly
                                string themaNaam = (string)reader["ThemaNaam"];
                                long groepId = (long)reader["GroepId"]; // Gebruik long in plaats van int

                                // Haal de aanwezigheid op voor deze training
                                Dictionary<Speler, string> aanwezigheden = _aanwezigheidMapper.GetAanwezighedenByTrainingId(id);

                                // Haal de Groep op met het groepId
                                Groep groep = _groepMapper.GetGroepById(groepId);

                                // Maak een Training object met de opgehaalde gegevens, de aanwezigheid en de groep
                                Training training = new Training(id, trainingDatum, themaNaam, aanwezigheden, groep);
                                result.Add(training);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van trainingen voor de groep: {ex.Message}");
            }
            return result;
        }

        public void DeleteTraining(Training training)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Begin een transactie
                    using (SQLiteTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Verwijder de bijbehorende aanwezigheden
                            string deleteAanwezighedenQuery = "DELETE FROM Aanwezigheid WHERE TrainingId = @TrainingId;";
                            using (SQLiteCommand aanwezighedenCommand = new SQLiteCommand(deleteAanwezighedenQuery, connection, transaction))
                            {
                                aanwezighedenCommand.Parameters.AddWithValue("@TrainingId", training.Id);
                                aanwezighedenCommand.ExecuteNonQuery();
                            }

                            // Verwijder de training zelf
                            string deleteTrainingQuery = $"DELETE FROM {_tableName} WHERE Id = @TrainingId;";
                            using (SQLiteCommand trainingCommand = new SQLiteCommand(deleteTrainingQuery, connection, transaction))
                            {
                                trainingCommand.Parameters.AddWithValue("@TrainingId", training.Id);
                                trainingCommand.ExecuteNonQuery();
                            }

                            // Commit de transactie
                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            // Rollback bij een fout
                            transaction.Rollback();
                            throw new Exception($"Fout bij het verwijderen van de training: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het verbinden met de database: {ex.Message}");
            }
        }

        public void VerwijderSpelerUitTraining(Training training, Speler speler)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Query om de aanwezigheid van de speler in de training te verwijderen
                    string query = @"
                    DELETE FROM Aanwezigheid
                    WHERE TrainingId = @TrainingId AND SpelerId = @SpelerId;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainingId", training.Id);
                        command.Parameters.AddWithValue("@SpelerId", speler.Id);

                        // Voer de query uit
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            throw new Exception("De speler is niet gevonden in de opgegeven training.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het verwijderen van de speler uit de training: {ex.Message}");
            }
        }

        public Training GetTrainingById(long trainingId)
        {
            Training result = null;

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    // Query om de training op te halen op basis van de TrainingId
                    string query = @"
                    SELECT t.Id, t.TrainingDatum, t.ThemaNaam, t.GroepId
                    FROM Training t
                    WHERE t.Id = @TrainingId;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainingId", trainingId);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // Als we een resultaat hebben
                            {
                                long id = (long)reader["Id"];
                                DateOnly trainingDatum = DateOnly.Parse((string)reader["TrainingDatum"]);
                                string themaNaam = (string)reader["ThemaNaam"];
                                long groepId = (long)reader["GroepId"];

                                // Haal de aanwezigheid op voor deze training
                                Dictionary<Speler, string> aanwezigheden = _aanwezigheidMapper.GetAanwezighedenByTrainingId(id);

                                // Haal de Groep op met het groepId
                                Groep groep = _groepMapper.GetGroepById(groepId);

                                // Maak een Training object met de opgehaalde gegevens
                                result = new Training(id, trainingDatum, themaNaam, aanwezigheden, groep);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van de training met ID {trainingId}: {ex.Message}");
            }

            return result;
        }

        public Training GetTrainingByDatum(DateOnly trainingDatum, string groepNaam)
{
    Training result = null;

    try
    {
        using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
        {
            connection.Open();

            // Query met JOIN om groepNaam te gebruiken in plaats van GroepId
            string query = @"
                SELECT t.Id, t.TrainingDatum, t.ThemaNaam, t.GroepId
                FROM Training t
                INNER JOIN Groep g ON t.GroepId = g.Id
                WHERE t.TrainingDatum = @TrainingDatum AND g.GroepNaam = @GroepNaam
                LIMIT 1;"; // Beperk het resultaat tot 1 training

            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TrainingDatum", trainingDatum.ToString("yyyy-MM-dd"));
                command.Parameters.AddWithValue("@GroepNaam", groepNaam);

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read()) // Als we een resultaat hebben
                    {
                        long id = (long)reader["Id"];
                        DateOnly trainingDatumFromDb = DateOnly.Parse((string)reader["TrainingDatum"]);
                        string themaNaam = (string)reader["ThemaNaam"];
                        long groepId = (long)reader["GroepId"];

                        // Haal de aanwezigheid op voor deze training
                        Dictionary<Speler, string> aanwezigheden = _aanwezigheidMapper.GetAanwezighedenByTrainingId(id);

                        // Haal de Groep op met het groepId
                        Groep groep = _groepMapper.GetGroepById(groepId);

                        // Maak een Training object met de opgehaalde gegevens
                        result = new Training(id, trainingDatumFromDb, themaNaam, aanwezigheden, groep);
                    }
                }
            }
        }
    }
    catch (Exception ex)
    {
        throw new Exception($"Fout bij het ophalen van de training op datum {trainingDatum} en groep {groepNaam}: {ex.Message}");
    }

    return result; // Return null als er geen training is gevonden
}




    }
}
