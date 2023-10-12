namespace LibraryManagementApp.Core
{
    public class User
    {
        //public string? Email, Password, Name, Lastname, PhoneNumber;
        public string? Email { get; set; }
        private string? Password { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? PhoneNumber { get; set; }
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

        public string? GetPassword()
        {
            return Password;
        }

        public void SetPassword(string? newPassword)
        {
            Password = newPassword;
        }

        public bool CheckPassword(string inputPassword)
        {
            return Password == inputPassword;
        }

        public override string ToString()
        {
            return $"{Email}, {Password}, {Name}, {Lastname}, {PhoneNumber}, {Permission}";
        }


    }
}