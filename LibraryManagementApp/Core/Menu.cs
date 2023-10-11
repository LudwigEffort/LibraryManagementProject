namespace LibraryManagementApp.Core
{
    class Menu
    {
        public static void StartMenu()
        {
            string[] option = { "1. Guest", "2. Admin", "3. New user", "0. Exit" };
            int selectOption;

            Console.Clear();
            Figlet.PrintProgramTitle();
            Console.WriteLine($"How are you?");

            do
            {
                ShowsMenu(option);
                selectOption = ReadChoise();
                switch (selectOption)
                {
                    case 1: //? guest login (now user login)
                        Console.Clear();
                        List<User> userLogin = Parsing.ReadUser();
                        Login(userLogin);
                        break;
                    case 2: //? admin login
                        Console.Clear();
                        //TODO: check password
                        Console.WriteLine($"Your are Admin!");
                        break;
                    case 3: //? new user
                        Console.Clear();
                        User user = SignUpForm();
                        Parsing.NewUser(user);
                        StartMenu();
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

        public static void SubMenuGuest()
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
                        SubMenuItem();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Print my booking...");
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

        public static void SubMenuItem()
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
                        SubMenuSearch(isBook);
                        break;
                    case 2:
                        Console.Clear();
                        isBook = false;
                        //Console.WriteLine($"Print by...!");
                        SubMenuSearch(isBook);
                        break;
                    case 0:
                        Console.Clear();
                        SubMenuGuest(); //TODO: add if for manage guest or admin
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 0);

        }

        public static void SubMenuSearch(bool isBook)
        {
            string bookOrDvd = "";
            string item = "";
            if (isBook == true)
            {
                item = "book";
                bookOrDvd = "2. Search book by ISBN";
            }
            else
            {
                item = "DVD";
                bookOrDvd = "2. Search DVD by Serial Numbers";
            }
            string[] option = { "1. Search by Title", bookOrDvd, "0. Back" };
            int selectOption;

            Console.WriteLine($"You booking {item}:");

            do
            {
                ShowsMenu(option);
                selectOption = ReadChoise();
                switch (selectOption)
                {
                    //DO: add if to filter by book o dvd
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Searching by Title...");
                        //TODO: insert booking methods
                        break;
                    case 2:
                        Console.Clear();
                        if (isBook == true)
                        {
                            Console.WriteLine($"Searching book by ISBN...");
                        }
                        else
                        {
                            Console.WriteLine($"Searching DVD by Serial Numbers...");
                        }
                        //TODO: insert booking methods
                        break;
                    case 0:
                        Console.Clear();
                        SubMenuItem();
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 0);

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

            Console.WriteLine($"");

            return new User(email, password, name, lastname, phoneNumber, permission);
        }

        static void Login(List<User> users)
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
                SubMenuGuest();
            }
            else
            {
                Console.WriteLine($"Invalid email or password!");
            }

        }

    }

}
