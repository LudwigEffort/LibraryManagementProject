namespace LibraryManagementApp.Core
{
    public class Parsing
    {
        public const string inputBooksDb = "../LibraryManagementApp/Database/Books.csv";
        public const string inputDvdsDb = "../LibraryManagementApp/Database/DVDs.csv";
        public const string inputUser = "../LibraryManagementApp/Database/Users.csv";
        public const string inputLoan = "../LibraryManagementApp/Database/Loans.csv";

        //* BOOKS

        public static List<Book> Read() //? read from Books.csv
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
                string isbn = chunks[6].Trim(new char[] { ' ', '-' });
                int pages = Convert.ToInt32(chunks[7]);

                var book = new Book(title, year, genre, location, status, authors, isbn, pages);

                books.Add(book);
            }
        }

        public static void ChangeStatus(string isbn) //? change status book from Books.csv
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
            catch (Exception)
            {
                Console.WriteLine($"Error...");
            }

        }

        //* DVD

        public static List<DVD> ReadDvd() //? read from Books.csv
        {
            using var input = File.OpenText(inputDvdsDb);
            var dvds = new List<DVD>();
            input.ReadLine();

            while (true)
            {
                string? line = input.ReadLine();

                if (line is null)
                {
                    return dvds;
                }

                var chunks = line.Split(',');

                string title = chunks[0][2..]; //? skip first two char
                int year = Convert.ToInt32(chunks[1]);
                string genre = chunks[2];
                string location = chunks[3];
                bool status = Convert.ToBoolean(chunks[4]);
                string[] authors = chunks[5].Split(';');
                string serialNumber = chunks[6].Trim();
                int duration = Convert.ToInt32(chunks[7]);

                var dvd = new DVD(title, year, genre, location, status, authors, serialNumber, duration);

                dvds.Add(dvd);
            }
        }

        public static void ChangeStatusDvd(string serialNumber) //? change status dvd from Dvds.csv
        {
            try
            {
                var lines = File.ReadAllLines(inputDvdsDb);
                bool found = false;

                for (int i = 1; i < lines.Length; i++)
                {
                    var chunks = lines[i].Split(',');

                    if (chunks.Length >= 7 && chunks[6].Trim().ToLower() == serialNumber.Trim().ToLower())
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
                    Console.WriteLine($"Book with ISBN {serialNumber} not found.");
                    return;
                }

                File.WriteAllLines(inputDvdsDb, lines);
            }
            catch (Exception)
            {
                Console.WriteLine($"Error...");
            }

        }

        //* LOANS

        public static List<Loan> ReadLoan() //? read from Books.csv
        {
            using var input = File.OpenText(inputLoan);
            var loans = new List<Loan>();
            input.ReadLine();

            while (true)
            {
                string? line = input.ReadLine();

                if (line is null)
                {
                    return loans;
                }

                var chunks = line.Split(',');

                string email = chunks[0][2..].Trim();
                string password = chunks[1].Trim();
                string name = chunks[2].Trim();
                string lastname = chunks[3].Trim();
                string phoneNumber = chunks[4].Trim();
                bool permission = Convert.ToBoolean(chunks[5].Trim());

                User user = new User(email, password, name, lastname, phoneNumber, permission);

                Book book = null;

                DVD dvd = null;


                if (chunks[12].StartsWith("978-"))
                {
                    string title = chunks[6].Trim(); //? skip first two char
                    int year = Convert.ToInt32(chunks[7]);
                    string genre = chunks[8];
                    string location = chunks[9];
                    bool status = Convert.ToBoolean(chunks[10]);
                    string[] authors = chunks[11].Split(';');
                    string isbn = chunks[12].Trim(new char[] { ' ', '-' });
                    int pages = Convert.ToInt32(chunks[13]);

                    book = new Book(title, year, genre, location, status, authors, isbn, pages);

                    string id = chunks[14];
                    DateTime startTime = Convert.ToDateTime(chunks[15]);
                    DateTime endTime = Convert.ToDateTime(chunks[16]);

                    Loan loan = new(user, book, id, startTime, endTime);

                    loans.Add(loan);
                }
                else
                {
                    string title = chunks[6].Trim(); //? skip first two char
                    int year = Convert.ToInt32(chunks[7]);
                    string genre = chunks[8];
                    string location = chunks[9];
                    bool status = Convert.ToBoolean(chunks[10]);
                    string[] authors = chunks[11].Split(';');
                    string serialNumber = chunks[12].Trim();
                    int duration = Convert.ToInt32(chunks[13]);

                    dvd = new DVD(title, year, genre, location, status, authors, serialNumber, duration);

                    string id = chunks[14];
                    DateTime startTime = Convert.ToDateTime(chunks[15]);
                    DateTime endTime = Convert.ToDateTime(chunks[16]);

                    Loan loan = new(user, dvd, id, startTime, endTime);

                    loans.Add(loan);
                }
            }
        }

        public static void NewLoan(Loan loans)
        {
            using var output = File.AppendText(inputLoan);
            output.WriteLine($"- {loans.User}, {loans.LoanedDocument}, {loans.LoanId}, {loans.StartTime}, {loans.EndTime}");
        }

        //* USERS

        public static List<User> ReadUser() //? print all user from Users.csv
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

                string email = chunks[0][2..].Trim();
                string password = chunks[1].Trim();
                string name = chunks[2].Trim();
                string lastname = chunks[3].Trim();
                string phoneNumber = chunks[4].Trim();
                bool permission = Convert.ToBoolean(chunks[5].Trim());

                var user = new User(email, password, name, lastname, phoneNumber, permission);

                users.Add(user);
            }

        }

        public static void NewUser(User user) //? add new user into Users.csv
        {
            //User user = new User("pippo", "pippo", "pippo", "pippo", "pippo", false);
            using var output = File.AppendText(inputUser);

            output.WriteLine($"- {user.Email}, {user.GetPassword()}, {user.Name}, {user.Lastname}, {user.PhoneNumber}, {user.Permission}");

        }

    }
}