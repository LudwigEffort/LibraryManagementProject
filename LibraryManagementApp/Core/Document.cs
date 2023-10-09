namespace LibraryManagementApp.Core
{
    abstract class Document
    {
        private string Title, Year, Genre, Location;
        private bool Status;
        List<string> Authors;
    }
}