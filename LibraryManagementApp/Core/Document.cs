namespace LibraryManagementApp.Core
{
    public class Document
    {
        public string Title, Genre, Location;
        public int Year;
        public bool Status;
        public string[] Authors;

        public Document(string title, int year, string genre, string location, bool status, string[] authors)
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