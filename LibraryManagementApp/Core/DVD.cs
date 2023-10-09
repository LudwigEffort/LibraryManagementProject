
namespace LibraryManagementApp.Core
{
    class DVD : Document
    {
        string SerialNumber, Duration;

        public DVD(string title, string year, string genre, string location, bool status, List<string> authors, string serialNumber, string duration) : base(title, year, genre, location, status, authors)
        {
            SerialNumber = serialNumber;
            Duration = duration;
        }
    }

}