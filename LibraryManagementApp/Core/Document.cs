namespace LibraryManagementApp.Core
{
    abstract class Document
    {
        private string Title, Year, Genre, Location;
        private bool Status;
        List<string> Authors;

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