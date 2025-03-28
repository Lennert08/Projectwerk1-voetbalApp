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
    public class AanwezigheidRepository : IAanwezigheidInterface
    {
        private const string _tableName = "Aanwezigheid";
        private static readonly string _connectionString = DbInfo.ConnectionString;
        private const long _heeftNooitGetraint = -1;

        //deze method word gebruikt om de dictonaries te maken met de info dat je krijgt uit de databank
        public Dictionary<Speler, string> GetAanwezighedenByTrainingId(long trainingId)
        {
            Dictionary<Speler, string> aanwezigheden = new();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();

                    string query = $@"
                    SELECT s.Id, s.Voornaam, s.Achternaam, s.RugNummer, a.Status
                    FROM Aanwezigheid a
                    INNER JOIN Speler s ON a.SpelerId = s.Id
                    WHERE a.TrainingId = @TrainingId;";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@TrainingId", trainingId);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    int spelerId = (int)(long)reader["Id"];
                                    string voornaam = (string)reader["Voornaam"];
                                    string achternaam = (string)reader["Achternaam"];
                                    int rugNummer = (int)(long)reader["RugNummer"];
                                    string status = (string)reader["Status"];

                                    Speler speler = new Speler(spelerId, voornaam, achternaam, rugNummer);
                                    aanwezigheden[speler] = status;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van aanwezigheden: {ex.Message}");
            }

            return aanwezigheden;
        }

        //deze method word gebruikt om de dictonaries te maken voor de traingen als het in databank moet ge add worden
        public void AddAanwezigheden(long trainingId, Dictionary<Speler, string> aanwezigheden, SQLiteTransaction transaction)
        {
            try
            {
                // Gebruik de bestaande verbinding en transactie
                foreach (KeyValuePair<Speler, string> aanwezigheid in aanwezigheden)
                {
                    Speler speler = aanwezigheid.Key;
                    string status = aanwezigheid.Value;

                    string aanwezigheidQuery = @"
                    INSERT INTO Aanwezigheid (TrainingId, SpelerId, Status) 
                    VALUES (@TrainingId, @SpelerId, @Status);";

                    using (SQLiteCommand aanwezigheidCommand = new SQLiteCommand(aanwezigheidQuery, transaction.Connection, transaction))
                    {
                        aanwezigheidCommand.Parameters.AddWithValue("@TrainingId", trainingId);
                        aanwezigheidCommand.Parameters.AddWithValue("@SpelerId", speler.Id);
                        aanwezigheidCommand.Parameters.AddWithValue("@Status", status);

                        // Voer de query uit
                        aanwezigheidCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het toevoegen van de aanwezigheden: {ex.Message}");
            }
        }


        public double GetPercentageBySpeler(Speler speler)
        {
            double percentagee = _heeftNooitGetraint;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
                {
                    connection.Open();
                    string query = $@"
                        Select Count(Status) as TotaalTrainingenPerSpeler,
                        SUM(CASE WHEN Status = 'Aanwezig' THEN 1 ELSE 0 END) AS Aanwezigheden
                        From Aanwezigheid
                        Where SpelerId = @id
                    ";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@id", speler.Id);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                while(reader.Read())
                                {
                                    long totaleTrainingen = reader.IsDBNull(0) ? 0 : (long)reader["TotaalTrainingenPerSpeler"];
                                    long aanwezigheden = reader.IsDBNull(1) ? 0 : (long)reader["Aanwezigheden"];

                                    if (totaleTrainingen != 0)
                                    {
                                        percentagee = ((double)aanwezigheden / totaleTrainingen) * 100;
                                        //Percentage voor aanwezigheidscalculaties
                                    }
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Fout bij het ophalen van de exportgegevens: {ex.Message}");
            }
            return percentagee;
        }

        public void UpdateAanwezigheidStatus(Speler speler, string oudeStatus, string nieuweStatus, Training training)
        {
            using (SQLiteConnection connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Controleer of de aanwezigheid met de gegeven oude status bestaat
                        string controleQuery = @"
                        SELECT COUNT(*) 
                        FROM Aanwezigheid 
                        WHERE TrainingId = @TrainingId AND SpelerId = @SpelerId AND Status = @OudeStatus;
                        ";

                        using (SQLiteCommand controleCommand = new SQLiteCommand(controleQuery, connection, transaction))
                        {
                            controleCommand.Parameters.AddWithValue("@TrainingId", training.Id);
                            controleCommand.Parameters.AddWithValue("@SpelerId", speler.Id);
                            controleCommand.Parameters.AddWithValue("@OudeStatus", oudeStatus);

                            long count = (long)controleCommand.ExecuteScalar();

                            if (count == 0)
                            {
                                throw new Exception("De opgegeven aanwezigheid met de oude status bestaat niet.");
                            }
                        }

                        // Update de aanwezigheid naar de nieuwe status
                        string updateQuery = @"
                        UPDATE Aanwezigheid
                        SET Status = @NieuweStatus
                        WHERE TrainingId = @TrainingId AND SpelerId = @SpelerId AND Status = @OudeStatus;
                        ";

                        using (SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection, transaction))
                        {
                            updateCommand.Parameters.AddWithValue("@NieuweStatus", nieuweStatus);
                            updateCommand.Parameters.AddWithValue("@TrainingId", training.Id);
                            updateCommand.Parameters.AddWithValue("@SpelerId", speler.Id);
                            updateCommand.Parameters.AddWithValue("@OudeStatus", oudeStatus);

                            int rowsAffected = updateCommand.ExecuteNonQuery();

                            if (rowsAffected == 0)
                            {
                                throw new Exception("Aanwezigheidsstatus kon niet worden bijgewerkt.");
                            }
                        }

                        // Commit de transactie als alles succesvol is
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        // Rollback de transactie bij een fout
                        transaction.Rollback();
                        throw new Exception($"Fout bij het bijwerken van de aanwezigheidsstatus: {ex.Message}");
                    }
                }
            }
        }

    }
}
