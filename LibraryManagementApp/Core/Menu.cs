namespace LibraryManagementApp.Core
{
    class Menu
    {
        public static void StartMenu()
        {
            string[] option = { "1. Guest", "2. Admin", "3. New user", "0. Exit" };
            int selectOption;

            List<User> users = Parsing.ReadUser();
            List<Book> books = Parsing.Read();
            List<DVD> dvds = Parsing.ReadDvd();

            //Console.Clear();
            Figlet.PrintProgramTitle();
            Console.WriteLine($"Who are you?");

            do
            {
                ShowsMenu(option);
                selectOption = ReadChoise();
                //List<User> userLogin = Parsing.ReadUser();
                switch (selectOption)
                {
                    case 1: //? guest login (now user login)
                        Console.Clear();
                        Login(users, books, dvds);
                        break;
                    case 2: //? admin login
                        Console.Clear();
                        //TODO: add admin login
                        break;
                    case 3: //? new user
                        Console.Clear();
                        User user = SignUpForm(); //? make new user instance
                        Parsing.NewUser(user); //? save user instance in db
                        StartMenu(); //? back to main menu...
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"Exit from program...");
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 3 && selectOption != 0);

        }

        public static void SubMenuGuest(List<Book> books, List<DVD> dvds)
        {
            string[] option = { "1. Booking item", "2. Print my booking", "0. Back" };
            int selectOption;

            Console.WriteLine($"You're Guest!");
            Console.WriteLine();
            Console.WriteLine($"What you wanna do?");

            do
            {
                ShowsMenu(option);
                selectOption = ReadChoise();
                switch (selectOption)
                {
                    case 1:
                        Console.Clear();
                        SubMenuItem(books, dvds);
                        //Console.WriteLine($"Not implemented");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Not implemented");
                        break;
                    case 0:
                        Console.Clear();
                        StartMenu();
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 0);

        }

        public static void SubMenuItem(List<Book> books, List<DVD> dvds)
        {
            string[] option = { "1. Book", "2. DVD", "0. Back" };
            int selectOption;
            bool isBook = true;

            Console.WriteLine($"What you wanna booking?");

            do
            {
                ShowsMenu(option);
                selectOption = ReadChoise();
                switch (selectOption)
                {
                    case 1:
                        Console.Clear();
                        SubMenuSearch(books, dvds, isBook);
                        break;
                    case 2:
                        Console.Clear();
                        isBook = false;
                        SubMenuSearch(books, dvds, isBook);
                        break;
                    case 0:
                        Console.Clear();
                        SubMenuGuest(books, dvds); //TODO: add if for manage guest or admin
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 0);

        }

        public static void SubMenuSearch(List<Book> books, List<DVD> dvds, bool isBook)
        {
            string bookOrDvd = "";
            string item = "";
            if (isBook == true)
            {
                item = "book";
                bookOrDvd = "3. Search book by ISBN";
            }
            else
            {
                item = "DVD";
                bookOrDvd = "3. Search DVD by Serial Numbers";
            }
            string[] option = { "1. Print all available", "2. Search by Title", bookOrDvd, "0. Back" };
            int selectOption;

            Console.WriteLine($"You booking {item}:");

            do
            {
                ShowsMenu(option);
                selectOption = ReadChoise();

                //List<Book> books = Parsing.Read();
                //List<DVD> dvds = Parsing.ReadDvd();

                switch (selectOption)
                {
                    case 1:
                        Console.Clear();
                        if (isBook == true)
                        {
                            PrintBook(books); //? Print all available books
                            //TODO: add loan methods
                        }
                        else
                        {
                            PrintDVD(dvds); //? Print all available dvds
                            //TODO: add loan methods
                        }
                        break;
                    case 2:
                        Console.Clear();
                        if (isBook == true)
                        {
                            SearchByTitle(books, dvds, isBook); //? Print books by title
                            //TODO: add loan methods
                        }
                        else
                        {
                            SearchByTitleDvd(books, dvds, isBook); //? Print dvds by title
                            //TODO: add loan methods
                        }
                        break;
                    case 3:
                        Console.Clear();
                        if (isBook == true)
                        {
                            SearchByIsbn(books, dvds, isBook); //? Print book by isbn
                            //TODO: add loan methods
                        }
                        else
                        {
                            SearchBySerialNum(books, dvds, isBook);
                            //TODO: add loan methods
                        }
                        break;
                    case 0:
                        Console.Clear();
                        SubMenuItem(books, dvds);
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 3 && selectOption != 0);

        }

        public static void ShowsMenu(string[] options)
        {
            foreach (var item in options)
            {
                Console.WriteLine(item);
            }
        }

        public static int ReadChoise()
        {
            int selectOption;
            Console.WriteLine($"Select a option with 1-2:");
            while (!int.TryParse(Console.ReadLine(), out selectOption))
            {
                Console.WriteLine($"Wrong Option!");
                Console.WriteLine($"Select a option with 1-2:");
            }
            return selectOption;
        }

        //* Utils book

        //? Print all available books
        public static void PrintBook(List<Book> books)
        {
            Console.WriteLine($"Available books: ");
            foreach (var book in books)
            {
                if (book.Status == true)
                {
                    Console.WriteLine(book.ToString());
                }
            }
        }

        //? Print available books by Title
        public static void SearchByTitle(List<Book> books, List<DVD> dvds, bool isBook)
        {
            Console.WriteLine($"Search by title.");
            Console.WriteLine($"Enter a title: ");
            string? searchTitle = Console.ReadLine();

            if (searchTitle != null && searchTitle != "")
            {
                List<Book> filteredTitle = books.Where(book => book.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase)).ToList();
                Console.WriteLine($"Books that contains ({searchTitle}) are: ");
                foreach (var book in filteredTitle)
                {
                    if (book.Status == true)
                    {
                        Console.WriteLine(book.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine($"Wrong title inserted!");
                SubMenuSearch(books, dvds, isBook);
            }
        }

        //? Print available books by ISBN
        public static void SearchByIsbn(List<Book> books, List<DVD> dvds, bool isBook)
        {
            Console.WriteLine($"Search by ISBN.");
            Console.WriteLine($"Enter a ISBN: ");
            string? searchISBN = Console.ReadLine();

            if (searchISBN != null && searchISBN != "")
            {
                List<Book> filteredIsbn = books.Where(book => book.ISBN.Contains(searchISBN, StringComparison.OrdinalIgnoreCase)).ToList();
                Console.WriteLine($"Books that contains ({searchISBN}) are: ");
                foreach (var book in filteredIsbn)
                {
                    if (book.Status == true)
                    {
                        Console.WriteLine(book.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine($"Wrong ISBN inserted!");
                SubMenuSearch(books, dvds, isBook);
            }
        }

        //* Utils dvds

        //? Print all avaialble dvds
        public static void PrintDVD(List<DVD> dvds)
        {
            Console.WriteLine($"Available dvds: ");
            foreach (var dvd in dvds)
            {
                if (dvd.Status == true)
                {
                    Console.WriteLine(dvd.ToString());
                }
            }
        }

        //? Print available dvds by Title
        public static void SearchByTitleDvd(List<Book> books, List<DVD> dvds, bool isBook)
        {
            Console.WriteLine($"Search by title.");
            Console.WriteLine($"Enter a title: ");
            string? searchTitle = Console.ReadLine();

            if (searchTitle != null && searchTitle != "")
            {
                List<DVD> filteredTitle = dvds.Where(dvd => dvd.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase)).ToList();
                Console.WriteLine($"DVDs that contains ({searchTitle}) are: ");
                foreach (var dvd in filteredTitle)
                {
                    if (dvd.Status == true)
                    {
                        Console.WriteLine(dvd.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine($"Wrong title inserted!");
                SubMenuSearch(books, dvds, isBook);
            }
        }

        //? Print available dvds by Serial Numbers
        public static void SearchBySerialNum(List<Book> books, List<DVD> dvds, bool isBook)
        {
            Console.WriteLine($"Search by Serial Numbers.");
            Console.WriteLine($"Enter a Serial Numbers: ");
            string? SearchBySerialNum = Console.ReadLine();

            if (SearchBySerialNum != null && SearchBySerialNum != "")
            {
                List<DVD> filteredSerialNum = dvds.Where(dvd => dvd.SerialNumber.Contains(SearchBySerialNum, StringComparison.OrdinalIgnoreCase)).ToList();
                Console.WriteLine($"DVDs that contains ({SearchBySerialNum}) are: ");
                foreach (var dvd in filteredSerialNum)
                {
                    if (dvd.Status == true)
                    {
                        Console.WriteLine(dvd.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine($"Wrong Serial Numbers inserted!");
                SubMenuSearch(books, dvds, isBook);
            }
        }

        //* Utils loan

        //TODO: make a method to set parameters for MakeNewLoan methods

        // public static Loan MakeNewLoan() //? methods for instance a Loan
        // {
        //     //? for now ask email user for identify user for make a loan
        //     List<User> users = Parsing.ReadUser();
        //     List<Book> books = Parsing.Read();
        //     List<DVD> dvds = Parsing.ReadDvd();



        //     return;

        // }

        //* Utils user
        static public User SignUpForm() //?TODO: while loops for wrong field 
        {
            bool permission = false;

            Console.WriteLine($"User Form.");

            Console.WriteLine($"Enter your email: ");
            string? email = Console.ReadLine();

            Console.WriteLine($"Enter your password: ");
            string? password = Console.ReadLine();

            Console.WriteLine($"Enter your name: ");
            string? name = Console.ReadLine();

            Console.WriteLine($"Enter your last name: ");
            string? lastname = Console.ReadLine();

            Console.WriteLine($"Enter your phone number: ");
            string? phoneNumber = Console.ReadLine();

            Console.WriteLine($"You are admin?");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char answer = keyInfo.KeyChar;

            if (answer == 'y')
            {
                permission = true;
            }
            //Console.WriteLine($"");
            Console.Clear();

            return new User(email, password, name, lastname, phoneNumber, permission);
        }

        static void Login(List<User> users, List<Book> books, List<DVD> dvds)
        {
            Console.WriteLine($"Enter email: ");
            string? email = Console.ReadLine();

            Console.WriteLine($"Enter password: ");
            string? password = Console.ReadLine();

            User loggedInUser = users.Find(user => user.Email == email && user.Password == password); //TODO: resolve it!

            if (loggedInUser != null)
            {
                Console.Clear();
                Console.WriteLine($"Login succesful. Welcome {loggedInUser.Name} {loggedInUser.Lastname}");
                SubMenuGuest(books, dvds);
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Invalid email or password!");
                StartMenu();
            }

        }

    }

}
