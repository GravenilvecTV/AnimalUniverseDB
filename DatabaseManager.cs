using System.Data;
using MySqlConnector;

namespace Database
{

    public class DatabaseManager()
    {

        private MySqlConnection connection;

        public void InsererAnimal(string nom, string color, int population)
        {
            if (connection == null) return;
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT into animals(name, color, population) VALUES(@name, @color, @population)";
            cmd.Parameters.AddWithValue("@name", nom);
            cmd.Parameters.AddWithValue("@color", color);
            cmd.Parameters.AddWithValue("@population", population);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Vous venez d'inserer {nom} dans la base");
        }

        public List<string> RecupererListeAnimaux() {
            List<string> nomDesAnimaux = new List<string>();

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM animals";
            MySqlDataReader reader = cmd.ExecuteReader();
            
            while(reader.Read()) {
                nomDesAnimaux.Add(reader.GetString("name"));
            }
            reader.Close();

            return nomDesAnimaux;
        }

        public async Task ConnectAsync()
        {

            var builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                UserID = "root",
                Password = "",
                Database = "animals",
            };
            try
            {

                // open a connection asynchronously
                connection = new MySqlConnection(builder.ConnectionString);
                await connection.OpenAsync();
                Console.WriteLine("Connection Okay !");

            }
            catch (MySqlException e)
            {
                Console.WriteLine($"Erreur {e}");
            }
        }

    }

}