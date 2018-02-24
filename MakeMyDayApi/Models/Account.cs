using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMyDayApi.Models
{
    public class Account
    {      
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid Guid { get; set;  }

        public Account(string login, string password)
        {
            Login = login;
            Password = password;
            Guid = GenerateSuperToken();
        }

        public Account(string login, string password, string guid)
        {
            Login = login;
            Password = password;
            Guid = new Guid(guid);
        }

        public Account(DataBase.Accounts account)
        {
            this.Login = account.Login;
            this.Password = account.Password.ToString();
            if (account.Guid != null)
                this.Guid = Guid.Parse(account.Guid);
        }

        private Guid GenerateSuperToken()
        {
            return Guid.NewGuid();
        } 
    }
}
