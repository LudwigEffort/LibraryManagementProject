namespace LibraryManagementApp.Core
{
    public static class Parsing
    {
        public const string inputBooksDb = "../LibraryManagementApp/Database/Books.csv";

        public static IEnumerable<Book> Read()
        {
            using var input = File.OpenText(inputBooksDb);
            var books = new List<Book>();
            input.ReadLine();

            while (true)
            {
                string? line = input.ReadLine();

                if (line is null)
                {
                    return books;
                }

                var chunks = line.Split(',');

                string title = chunks[0][2..]; //? skip first two char
                int year = Convert.ToInt32(chunks[1]);
                string genre = chunks[2];
                string location = chunks[3];
                bool status = Convert.ToBoolean(chunks[4]);
                string[] authors = chunks[5].Split(';');
                string isbn = chunks[6];
                int pages = Convert.ToInt32(chunks[7]);

                var book = new Book(title, year, genre, location, status, authors, isbn, pages);

                books.Add(book);
            }
        }

        public static void ChangeStatus(string isbn, string newStatus)
        {
            try
            {
                var lines = File.ReadAllLines(inputBooksDb);
                bool found = false;

                for (int i = 1; i < lines.Length; i++)
                {
                    var chunks = lines[i].Split(',');

                    if (chunks.Length >= 7 && chunks[6].Trim().ToLower() == isbn.Trim().ToLower())
                    {
                        chunks[4] = newStatus.ToString();
                        lines[i] = string.Join(',', chunks);
                        found = true;
                        break;
                    }

                }

                if (!found) //? NOT FOUND
                {
                    Console.WriteLine($"Book with ISBN {isbn} not found.");
                    return;
                }

                File.WriteAllLines(inputBooksDb, lines);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error...");
            }

        }
    }
}