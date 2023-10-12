namespace LibraryManagementApp.Core
{
    public class DVD : Document
    {
        public string SerialNumber { get; set; }
        public int Duration { get; set; }

        public DVD(string title, int year, string genre, string location, bool status, string[] authors, string serialNumber, int duration) : base(title, year, genre, location, status, authors)
        {
            SerialNumber = serialNumber;
            Duration = duration;
        }
        public override string ToString()
        {
            string authors = string.Join(", ", Authors);
            return $"{Title}, {Year}, {Genre}, {Location}, {Status}, {authors}, {SerialNumber}, {Duration}";
        }
    }
}

