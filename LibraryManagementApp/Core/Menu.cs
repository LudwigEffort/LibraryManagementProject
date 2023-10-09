namespace LibraryManagementApp.Core
{
    class Menu
    {
        public static void StartMenu()
        {
            string[] option = { "1. Guest", "2. Admin", "0. Exit" };
            int selectOption;

            Console.WriteLine($"Library Manager");

            do
            {
                ShowsMenu(option);
                selectOption = ReadChoise();
                switch (selectOption)
                {
                    case 1:
                        Console.Clear();
                        //TODO: check password
                        Console.WriteLine($"Your are Gueset!");
                        Console.WriteLine($"");
                        //TODO: print all availabe document
                        Menu.SubMenuGuest();
                        break;
                    case 2:
                        Console.Clear();
                        //TODO: check password
                        Console.WriteLine($"Your are Admin!");
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"Exit from program...");
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 0);

        }

        public static void SubMenuGuest()
        {
            string[] option = { "1. Print all itmes", "2. Print by", "0. Back" };
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
                        Console.WriteLine($"Printing all items...");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Print by...!");
                        SubMenuSearch();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"Back...");
                        Menu.StartMenu();
                        break;
                    default:
                        Console.WriteLine($"Wrong option!");
                        break;
                }
            } while (selectOption != 1 && selectOption != 2 && selectOption != 0);

        }

        public static void SubMenuSearch()
        {
            string[] option = { "1. Print by Title", "2. Print by ISBN or Serial Numbers", "0. Back" };
            int selectOption;

            Console.WriteLine($":");

            do
            {
                ShowsMenu(option);
                selectOption = ReadChoise();
                switch (selectOption)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Printing all items...");
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Your Booked!");
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine($"Back...");
                        Menu.StartMenu();
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
    }

}