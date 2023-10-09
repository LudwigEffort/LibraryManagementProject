namespace LibraryManagementApp.Core
{
    class Admin : User
    {
        public Admin(string? email, string? password, string? name, string? lastname, string? phoneNumber, bool permission) : base(email, password, name, lastname, phoneNumber, permission)
        {
        }
        //? maybe change void in string?
        public void AddDocument() { }
        public void RemoveDocument() { }
        public void EditDocument() { }
    }
}