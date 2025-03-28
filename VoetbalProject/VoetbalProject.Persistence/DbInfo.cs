using System;
using System.IO;

namespace VoetbalProject.Persistence
{
    internal class DbInfo
    {
        // Eigenschap die het pad naar de database bevat
        public static string DatabasePath { get; private set; }

        // Eigenschap die de connectiestring retourneert
        public static string ConnectionString //conncetionstring
        {
            get
            {
                return $"Data Source={DatabasePath};Version=3;";
            }
        }

        // Statische constructor om de database-instellingen in te stellen
        static DbInfo()
        {
            // Bepaal de locatie van de database
            string databaseFolder = "database";
            string databaseName = "VoetbalProject.db";

            // Bouw het volledige pad op basis van de huidige directory
            DatabasePath = Path.Combine(Environment.CurrentDirectory, databaseFolder, databaseName);
        }
    }
}
