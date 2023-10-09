
namespace LibraryManagementApp.Core
{
    class Book : Document
    {
        string ISBN {get;set;}
        string Pages{get;set;}

        public Book(string title, string year, string genre, string location, bool status, List<string> authors, string isbn, string pages) : base(title, year, genre, location, status, authors)
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