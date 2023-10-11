
namespace LibraryManagementApp.Core
{
    public class Book : Document
    {
        public string ISBN { get; set; }
        public int Pages { get; set; }

        public Book(string title, int year, string genre, string location, bool status, string[] authors, string isbn, int pages) : base(title, year, genre, location, status, authors)
        {
            ISBN = isbn;
            Pages = pages;
        }
        public override string ToString()
        {
            string authors = string.Join(", ", Authors);
            return $"{Title}, {Year}, {Genre}, {Location}, {Status}, {authors}, {ISBN}, {Pages}";
        }
    }
}