
namespace MakeMyDayApi.Models
{
    public class Account
    {      
        public string Login { get; set; }
        public string Password { get; set; }
        public string Guid { get; set;  }

        public Account()
        {

        }

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
            Guid = guid;
        }

        public Account(MakeMyDayDataBase.Accounts account)
        {
            if (account != null)
            {
                this.Login = account.Login;
                this.Password = account.Password.ToString();
                if (account.Guid != null)
                    Guid = account.Guid;
            }
        }

        private string GenerateSuperToken()
        {            
            return System.Guid.NewGuid() .ToString();
        } 
    }
}
