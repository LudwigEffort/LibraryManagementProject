using System;
using System.Net.WebSockets;
using LibraryManagementApp.Core;

class Library
{
    static void Main(string[] args)
    {
        //Menu.StartMenu();

        var books = Parsing.Read();

        // foreach (var book in books)
        // {
        //     if (book.Status == true)
        //     {
        //         Console.WriteLine(book.ToString());
        //     }
        // }

        Parsing.ChangeStatus("978-0316769480", "false");


        // List<string> authorBook1 = new List<string> { "tolkien", "tolkien son" };
        // Book book1 = new Book("LOTR", "1950", "fantasy", "5A", false, authorBook1, "1234567890A", "1000");
        // Book book2 = new Book("prova1", "1950", "fantasy", "5A", false, authorBook1, "1234567890A", "1000");
        // Book book3 = new Book("prova3", "1950", "horror", "5A", false, authorBook1, "1234567890A", "1000");
        // Book book4 = new Book("prova4", "1950", "fantasy", "5A", false, authorBook1, "1234567890A", "1000");
        // Book book5 = new Book("prova5", "1950", "fantasy", "5A", false, authorBook1, "1234567890A", "1000");
        // Book book6 = new Book("prova6", "1950", "fantasy", "5A", false, authorBook1, "1234567890A", "1000");

        // List<Book> test = new List<Book> { book1, book2, book3, book4, book5, book6 };

        /*  foreach (var item in test)
          {
              Console.WriteLine(item.ToString());
          }*/
        // Console.WriteLine("Ricerca per genere");
        // string input = Console.ReadLine();

        //Tolowercase
        // Console.WriteLine(input);
        // foreach (var item in test)
        // {
        //     if (item.Genre == input.ToLower())
        //     {
        //         Console.WriteLine(item.ToString());
        //     }
        //     else { Console.WriteLine("non ha trovato il genere ricercato"); }
        // }


        // Console.WriteLine("Ricerca per codice");
    }
}
