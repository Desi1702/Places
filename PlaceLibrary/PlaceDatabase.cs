using MySql.Data.MySqlClient;
using Places;

namespace PlaatsNamen
{
    public class PlaceDatabase : IDisposable
    {
        private MySqlConnection connection;

        public PlaceDatabase(string databaseName,
                     string server = "localhost", uint port = 3307,
                     string userId = "root", string password = "")
        {
            var connectionString = new MySqlConnectionStringBuilder
            {
                Server = server,
                Port = port,
                Database = databaseName,
                UserID = userId,
                Password = password
            }.ConnectionString;

            connection = new MySqlConnection(connectionString);
            connection.Open();
        }
        public void Clear()
        {
            using var command = connection.CreateCommand();
            command.CommandText = "TRUNCATE TABLE places;";
            command.ExecuteNonQuery();
        }

        public void Dispose()
        {
            connection?.Dispose();
            GC.SuppressFinalize(this);
        }


        public void Write(Place place)
        {
            using var command = connection.CreateCommand();
            command.CommandText =
                "insert into places " +
                "(ID, Woonplaatsen, Woonplaatscode_1, Naam_2, Code_3, Naam_4, Code_5, Naam_6, Code_7) values " +
                "(@ID, @Woonplaatsen, @Woonplaatscode_1, @Naam_2, @Code_3, @Naam_4, @Code_5, @Naam_6, @Code_7)";
            command.Parameters.AddWithValue("ID", place.ID);
            command.Parameters.AddWithValue("Woonplaatsen", place.Woonplaatsen);
            command.Parameters.AddWithValue("Woonplaatscode_1", place.Woonplaatscode_1);
            command.Parameters.AddWithValue("Naam_2", place.Naam_2);
            command.Parameters.AddWithValue("Code_3", place.Code_3);
            command.Parameters.AddWithValue("Naam_4", place.Naam_4);
            command.Parameters.AddWithValue("Code_5", place.Code_5);
            command.Parameters.AddWithValue("Naam_6", place.Naam_6);
            command.Parameters.AddWithValue("Code_7", place.Code_7);


            command.ExecuteNonQuery();

        }

        public List<Place> Search(string searchText)
        {
            var result = new List<Place>();
            using var command = connection.CreateCommand();
            command.CommandText = "select distinct(Naam_2) from places where Naam_2 like @searchText";
            command.Parameters.AddWithValue("searchText", searchText + '%');
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Place
                {
                    Naam_2 = reader.GetString("Naam_2"),
                });
            }
            return result;
        }

        public IEnumerable<string> AllPlaces()
        {
            var result = new List<string>();
            using var command = connection.CreateCommand();
            command.CommandText = "select distinct(Naam_2) from places";
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(reader.GetString("Naam_2"));
            }
            return result;

        }
    }

}




