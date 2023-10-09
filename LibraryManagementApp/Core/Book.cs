
namespace LibraryManagementApp.Core
{
    class Book : Document
    {
        string ISBN, Pages;

        public Book(string title, string year, string genre, string location, bool status, List<string> authors, string isbn, string pages) : base(title, year, genre, location, status, authors)
        {
            ISBN = isbn;
            Pages = pages;
        }
    }
}