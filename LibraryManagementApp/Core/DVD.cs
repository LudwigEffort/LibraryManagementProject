
namespace LibraryManagementApp.Core
{
    class DVD : Document
    {
        string SerialNumber, Duration;

        public DVD(string title, int year, string genre, string location, bool status, string[] authors, string serialNumber, string duration) : base(title, year, genre, location, status, authors)
        {
            SerialNumber = serialNumber;
            Duration = duration;
        }
    }

}