namespace LibraryManagementApp.Core
{
    abstract class Document
    {
        public string Title, Year, Genre, Location;
        public bool Status;
        public List<string> Authors;

        public Document(string title, string year, string genre, string location, bool status, List<string> authors)
        {
            Title = title;
            Year = year;
            Genre = genre;
            Location = location;
            Status = status;
            Authors = authors;
        }
    }
}