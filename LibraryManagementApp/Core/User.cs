namespace LibraryManagementApp.Core
{
    public class User
    {
        public string? Email, Password, Name, Lastname, PhoneNumber;
        public bool Permission { get; set; }

        public User(string? email, string? password, string? name, string? lastname, string? phoneNumber, bool permission)
        {
            Email = email;
            Password = password;
            Name = name;
            Lastname = lastname;
            PhoneNumber = phoneNumber;
            Permission = permission;
        }

        public override string ToString()
        {
            return $"{Email}, {Password}, {Name}, {Lastname}, {PhoneNumber}, {Permission}";
        }


    }
}