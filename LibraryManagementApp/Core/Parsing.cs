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
    }
}