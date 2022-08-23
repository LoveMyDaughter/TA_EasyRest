namespace TestFramework.Tools.GetData
{
    public class RoleCredentials
    {
        public RoleCredentials(string RoleName, string Email, string Password)
        {
            this.RoleName = RoleName;
            this.Email = Email;
            this.Password = Password;
        }

        public string RoleName { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}
