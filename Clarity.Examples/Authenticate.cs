namespace Clarity.Examples
{
    public class Authenticate : Request
    {
        public Authenticate()
        {
        }

        public Authenticate(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Password { get; }

        public string Username { get; }
    }
}