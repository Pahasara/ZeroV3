using System.Data.SQLite;

namespace Zero.Core
{
    public class Database
    {
        private string connectionString = "Data Source=.zero.db; Version=3; New=True; Compress=True;";
        private string table = "ShowInfo";

        private void ExecuteSQL(Action<SQLiteConnection> action)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                action(conn);
            }
        }

        public void CreateTable()
        {
            ExecuteSQL((conn) =>
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"CREATE TABLE IF NOT EXISTS {table} " +
                                      $"(id VARCHAR(12) PRIMARY KEY NOT NULL, show VARCHAR(64), current INTEGER, total INTEGER, rating INTEGER);";
                    cmd.ExecuteNonQuery();
                }
            });
        }

        public void Insert(string index, string show, string current, string total, string rating)
        {
            ExecuteSQL((conn) =>
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"INSERT INTO {table} (id, show, current, total, rating) " +
                                      $"VALUES ('{index}', '{show}', {current}, {total}, {rating});";
                    cmd.ExecuteNonQuery();
                }
            });
        }

        public void Update(string index, string show, string current, string total, string rating)
        {
            ExecuteSQL((conn) =>
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"UPDATE {table} " +
                                      $"SET show='{show}', current={current}, total={total}, rating={rating} " +
                                      $"WHERE id='{index}';";
                    cmd.ExecuteNonQuery();
                }
            });
        }

        public void Delete(string index)
        {
            ExecuteSQL((conn) =>
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"DELETE FROM {table} " +
                                      $"WHERE id='{index}';";
                    cmd.ExecuteNonQuery();
                }
            });
        }

        public int GetNumberOfRows()
        {
            int numberOfRows = 0;
            ExecuteSQL((conn) =>
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT COUNT(id) FROM {table};";
                    numberOfRows = Convert.ToInt32(cmd.ExecuteScalar());
                }
            });
            return numberOfRows;
        }

        public string[] GetIndexArray()
        {
            string[] indexes = new string[0]; // Initialize an empty array

            ExecuteSQL((conn) =>
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT id FROM {table} ORDER BY id;";
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        System.Collections.Generic.List<string> indexList = new System.Collections.Generic.List<string>();
                        while (reader.Read())
                        {
                            indexList.Add(reader.GetString(0));
                        }
                        indexes = indexList.ToArray();
                    }
                }
            });

            return indexes;
        }

        public string[] Search(string index)
        {
            string[] column = new string[5]; // Initialize an array to hold result

            ExecuteSQL((conn) =>
            {
                using (SQLiteCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT * FROM {table} WHERE id = '{index}';";
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            column[0] = reader.GetString(0);
                            column[1] = reader.GetString(1);
                            column[2] = reader.GetInt32(2).ToString();
                            column[3] = reader.GetInt32(3).ToString();
                            column[4] = reader.GetInt32(4).ToString();
                        }
                    }
                }
            });

            return column;
        }
    }
}
