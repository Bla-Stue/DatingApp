using System;
using System.Collections.Generic;
using System.Text;

namespace DatingApp
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Brugernavn { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool isAdmin { get; set; }
        public bool loggedIn { get; set; }
    }
}
