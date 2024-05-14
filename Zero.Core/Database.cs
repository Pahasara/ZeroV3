using System.Data.SQLite;

namespace Zero.Core
{
    public class Database
    {
        // define default table name
        private string table = "ShowInfo";

        public void ExecuteSQL(SQLiteConnection conn, string command)
        {
            conn.Open();
            SQLiteCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = command;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void CreateTable(SQLiteConnection conn)
        {
            ExecuteSQL(conn, 
                $"CREATE TABLE {table} " +
                $"(id VARCHAR(12) PRIMARY KEY NOT NULL, show VARCHAR(64), current INTEGER, total INTEGER, rating INTEGER);");
        }

        public void Insert(SQLiteConnection conn, string index, string show, string current, string total, string rating)
        {
            ExecuteSQL(conn, 
                $"INSERT INTO {table} (id, show, current, total, rating) " +
                $"VALUES ('{index}', '{show}', {current}, {total}, {rating});");
        }

        public void Update(SQLiteConnection conn, string index, string show, string current, string total, string rating)
        {
            ExecuteSQL(conn, 
                $"UPDATE {table} " +
                $"SET id='{index}', show='{show}', current={current}, total={total}, rating={rating} " +
                $"WHERE id='{index}';");
        }

        public void Delete(SQLiteConnection conn, string index)
        {
            ExecuteSQL(conn,
                $"DELETE FROM {table} " +
                $"WHERE id='{index}';");
        }

        public int GetNumberOfRows(SQLiteConnection conn)
        {
            SQLiteDataReader reader;
            SQLiteCommand cmd;
            int numberOfRows=0;

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT COUNT(id) FROM {table};"; 
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                numberOfRows =  reader.GetInt32(0);
            }
            
            return numberOfRows;
        }

        public string[] GetIndexArray(SQLiteConnection conn)
        {
            SQLiteDataReader reader;
            SQLiteCommand cmd;
            int numberOfRows = GetNumberOfRows(conn);
            string[] indexes = new string[numberOfRows];
            int count = 0; // to set indexes[count]

            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT id FROM {table} ORDER BY id;";
            try
            {
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    indexes[count] = reader.GetString(0);
                    count++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing SQL query: {ex.Message}");
            }
            conn.Close();
            return indexes;
        }

        public string[] Search(SQLiteConnection conn, string index)
        {
            SQLiteDataReader reader;
            SQLiteCommand cmd;
            conn.Open();
            cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {table} WHERE id = '{index}';";

            string[] column = new string[5];

            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                column[0] = reader.GetString(0);
                column[1] = reader.GetString(1);
                column[2] = reader.GetInt32(2).ToString();
                column[3] = reader.GetInt32(3).ToString();
                column[4] = reader.GetInt32(4).ToString();
            }
            conn.Close();
            return column;
        }
    }
}
