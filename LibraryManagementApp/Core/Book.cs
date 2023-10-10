
namespace LibraryManagementApp.Core
{
    public class Book : Document
    {
        string ISBN { get; set; }
        int Pages { get; set; }

        public Book(string title, int year, string genre, string location, bool status, string[] authors, string isbn, int pages) : base(title, year, genre, location, status, authors)
        {
            ISBN = isbn;
            Pages = pages;
        }
        //TODO: how to print List
        public override string ToString()
        {
            string authors = string.Join(", ", Authors);
            return $"{Title}, {Year}, {Genre}, {Location}, {Status}, {authors}, {ISBN}, {Pages}";
        }
    }
}