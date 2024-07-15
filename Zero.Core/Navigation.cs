namespace Zero.Core
{
    public class Navigation
    {
        Database database = new Database();

        public int currentRow = 0, maxRow = 0;
        private string index, show, current, total, rating;

        public Navigation()
        {
            try
            {
                Fetch();
            }
            catch (Exception)
            {
                InitializeDatabase();
            }
        }

        public void InitializeDatabase()
        {
            try
            {
                database.CreateTable();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        }

        public void Navigate(string choice = "")
        {
            if (choice == "next")
            {
                NextShow();
            }
            else if (choice == "back")
            {
                PreviousShow();
            }

            // If there are shows available, fetch data columns
            TryFetch();
        }

        private void TryFetch()
        {
            if (currentRow >= 0)
            {
                Fetch();
            }
        }

        private void Fetch(string searchIndex = "")
        {
            maxRow = database.GetNumberOfRows();
            string[] indexes = database.GetIndexArray();

            if (searchIndex != "")
            {
                currentRow = Array.IndexOf(indexes, searchIndex);
                if (currentRow == -1)
                {
                    currentRow = 0;
                }
            }
            else if (currentRow >= maxRow)
            {
                currentRow = 0;
            }

            if (maxRow > 0)
            {
                string[] data = database.Search(indexes[currentRow]);
                index = data[0];
                show = data[1];
                current = data[2];
                total = data[3];
                rating = data[4];
            }
        }

        public void NextShow()
        {
            if (currentRow < (maxRow - 1))
            {
                currentRow++;
            }
        }

        public void PreviousShow()
        {
            if (currentRow > 0)
            {
                currentRow--;
            }
        }

        public int GetMaxRow()
        {
            return maxRow;
        }

        public void Forward()
        {
            int currentEpisode = Arithmetic.ParseInt(GetCurrent());
            currentEpisode++;
            database.Update(GetIndex(), GetShow(), currentEpisode.ToString(), GetTotal(), GetRating());
        }

        public void Backward()
        {
            int currentEpisode = Arithmetic.ParseInt(GetCurrent());
            currentEpisode--;
            database.Update(GetIndex(), GetShow(), currentEpisode.ToString(), GetTotal(), GetRating());
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

            database.Insert(GetIndex(), GetShow(), GetCurrent(), GetTotal(), GetRating());

            currentRow = maxRow;
            maxRow++;
            Navigate("next");
        }

        public void Search(string index)
        {
            Fetch(index);
        }

        public void ResetProgress()
        {
            int currentEpisode = 0;
            database.Update(GetIndex(), GetShow(), currentEpisode.ToString(), GetTotal(), GetRating());
        }

        public void FinishProgress()
        {
            database.Update(GetIndex(), GetShow(), GetTotal(), GetTotal(), GetRating());
        }

        public void DeleteShow()
        {
            database.Delete(GetIndex());
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

        public string GetProgress()
        {
            var decProgress = Arithmetic.GetProgress(GetCurrent(), GetTotal());
            int progress = (int)decProgress;
            return progress.ToString();
        }
    }
}
