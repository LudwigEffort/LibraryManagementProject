namespace LibraryManagementApp.Core
{
    class Menu
    {
        public static void StartMenu()
        {
            string[] option = { "1. Teacher", "2. Student", "0. Exit" };
            int selectOption;

            Console.WriteLine($"Computer Labs Manager");

            do
            {
                ShowsMenu(option);
                selectOption = ReadChoise();
                switch (selectOption)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Your are Teacher!");
                        Menu.SubMenu();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine($"Your are Student!");
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

        public static void SubMenu()
        {
            string[] option = { "1. Booking", "2. Unbooking", "0. Back" };
            int selectOption;

            Console.WriteLine($"Booking Labs:");

            do
            {
                ShowsMenu(option);
                selectOption = ReadChoise();
                switch (selectOption)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine($"Your Booked!");
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