using System.Data.SQLite;

namespace TP3.Models
{
    public class Personal_info
    {
        public List<Person> GetAllPerson()
        {
            List<Person> list = new List<Person>();
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=D:\\Temp\\database.db;");
            dbCon.Open();

            using (dbCon)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info", dbCon);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        list.Add(new Person((int)reader["id"], (string)reader["first_name"], (string)reader["last_name"], (string)reader["email"], (string)reader["image"], (string)reader["country"]));
                    }
                }
            }

            return list;
        }
        public Person? GetPerson(int id)
        {
            SQLiteConnection dbCon = new SQLiteConnection("Data Source=D:\\Temp\\database.db;");
            dbCon.Open();

            using (dbCon)
            {
                SQLiteCommand cmd = new SQLiteCommand("SELECT * FROM personal_info WHERE id=@id", dbCon);
                cmd.Parameters.AddWithValue("id", id);
                SQLiteDataReader reader = cmd.ExecuteReader();
                using (reader)
                {
                    if (reader.Read())
                    {
                        return new Person((int)reader["id"], (string)reader["first_name"], (string)reader["last_name"], (string)reader["email"], (string)reader["image"], (string)reader["country"]);
                    }
                }
            }

            return null;
        }
    }
}
