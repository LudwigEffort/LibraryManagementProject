namespace LibraryManagementApp.Core
{
    public class Parsing
    {
        public const string inputBooksDb = "../LibraryManagementApp/Database/Books.csv";
        public const string inputUser = "../LibraryManagementApp/Database/Users.csv";

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

        public static void ChangeStatus(string isbn)
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
                        if (Convert.ToBoolean(chunks[4]) == true)
                        {
                            chunks[4] = false.ToString().ToLower();
                        }
                        else
                        {
                            chunks[4] = true.ToString().ToLower();
                        }
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

        public static IEnumerable<User> ReadUser()
        {
            using var input = File.OpenText(inputUser);
            var users = new List<User>();
            input.ReadLine();

            while (true)
            {
                string? line = input.ReadLine();

                if (line is null)
                {
                    return users;
                }

                var chunks = line.Split(',');

                string email = chunks[0][2..];
                string password = chunks[1];
                string name = chunks[2];
                string lastname = chunks[3];
                string phoneNumber = chunks[4];
                bool permission = Convert.ToBoolean(chunks[5]);

                var user = new User(email, password, name, lastname, phoneNumber, permission);

                users.Add(user);
            }

        }

        public static void NewUser(User user)
        {
            //User user = new User("pippo", "pippo", "pippo", "pippo", "pippo", false);
            using var output = File.AppendText(inputUser);

            output.WriteLine($"- {user.Email}, {user.Password}, {user.Name}, {user.Lastname}, {user.PhoneNumber}, {user.Permission}");

        }
    }
}