using System.Data.SQLite;

namespace Zero.Core
{
    public class Navigation
    {
        SQLiteConnection conn = new SQLiteConnection("Data Source = database.db; version = 3; New = True; Compress = True;");
        Database database = new Database();
        
        public int currentRow = 0, maxRow = 0;
        private string  index, show, current, total, rating;

        public void Navigate(string choice="")
        {
            if (choice == "next")
            {
                NextShow();
            }
            else if (choice == "back")
            {
                PreviousShow();
            }

            Fetch(); // Fetch new data columns
        }

        private void Fetch()
        {
            conn.Open();
            maxRow = database.GetNumberOfRows(conn);
            string[] indexes = database.GetIndexArray(conn);
            string[] data = database.Search(conn, indexes[currentRow]);

            index = data[0];
            show = data[1];
            current = data[2];
            total = data[3];
            rating = data[4];
        }

        public int NextShow()
        {
            if (currentRow < (maxRow - 1))
            {
                currentRow++;
                return 0;
            }
            return -1;
        }

        public int PreviousShow()
        {
            if (currentRow > 0)
            {
                currentRow--;
                return 0;
            }
            return -1;
        }

        public void Forward()
        {
            int currentEpisode = Arithmetic.ParseInt(GetCurrent());
            currentEpisode++;
            database.Update(conn, GetIndex(), GetShow(), currentEpisode.ToString(), GetTotal(), GetRating());
        }

        public void Backward()
        {
            int currentEpisode = Arithmetic.ParseInt(GetCurrent());
            currentEpisode--;
            database.Update(conn, GetIndex(), GetShow(), currentEpisode.ToString(), GetTotal(), GetRating());
        }

        public void AddShow()
        {
            NewShow newShow = new NewShow();
            newShow.ShowMenu();
            string[] data = newShow.GetData();

            index = data[0];
            show = data[1];
            current = data[2];
            total = data[3];
            rating = data[4];

            database.Insert(conn, GetIndex(), GetShow(), GetCurrent(), GetTotal(), GetRating());
            newShow.Complete();
            currentRow = maxRow;
            maxRow++;
            Navigate("next");
        }

        public void ResetProgress()
        {
            int currentEpisode = 0;
            database.Update(conn, GetIndex(), GetShow(), currentEpisode.ToString(), GetTotal(), GetRating());
        }

        public void FinishProgress()
        {
            database.Update(conn, GetIndex(), GetShow(), GetTotal(), GetTotal(), GetRating());
        }

        public void DeleteShow()
        {
            database.Delete(conn, GetIndex());
            maxRow--;
            Navigate("back");
        }

        public string GetIndex()
        {
            return index;
        }

        public string GetShow()
        {
            return show;
        }

        public string GetCurrent()
        {
            return current;
        }

        public string GetTotal()
        {
            return total;
        }

        public string GetRating()
        {
            return rating;
        }
    }
}
