using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clarity.Examples
{
    public class Credential
    {
        public Credential(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Password { get; }

        public string Username { get; }
    }
}