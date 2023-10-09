namespace LibraryManagementApp.Core
{
    class Guest : User
    {
        public Guest(string? email, string? password, string? name, string? lastname, string? phoneNumber, bool permission) : base(email, password, name, lastname, phoneNumber, permission)
        {
        }
    }
}