namespace LibraryManagementApp.Core
{
    abstract class User
    {
        private string? Email, Password, Name, Lastname, PhoneNumber;
        private bool Permission;

        protected User(string? email, string? password, string? name, string? lastname, string? phoneNumber, bool permission)
        {
            Email = email;
            Password = password;
            Name = name;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            Permission = permission;
        }

        public void BookingDocument() { }
    }
}