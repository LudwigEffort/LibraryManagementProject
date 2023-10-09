using System;
using System.Net.WebSockets;
using LibraryManagementApp.Core;

class Library
{
    static void Main(string[] args)
    {
        //Menu.StartMenu();
        List<string> authorBook1 = new List<string> { "tolkien", "tolkien son" };
        Book book1 = new Book("LOTR", "1950", "Fantasy", "5A", false, authorBook1, "1234567890A", "1000");
        Book book2 = new Book("LOTR", "1950", "Fantasy", "5A", false, authorBook1, "1234567890A", "1000");

        List<Book> test = new List<Book> { book1, book1 };

        foreach (var item in test)
        {
            Console.WriteLine(item.ToString());
        }
    }
}
